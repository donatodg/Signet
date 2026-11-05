namespace VENET_WSFE_BL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Xml;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;

    public class LoginTicket
    {
        public uint UniqueId;
        public DateTime GenerationTime;
        public DateTime ExpirationTime;
        public string Service;
        public string Sign;
        public string Token;
        public long CuitEmisor;
        public XmlDocument XmlLoginTicketRequest = null;
        public XmlDocument XmlLoginTicketResponse = null;
        public string RutaDelCertificadoFirmante;
        public string XmlStrLoginTicketRequestTemplate = "<loginTicketRequest><header><uniqueId></uniqueId><generationTime></generationTime><expirationTime></expirationTime></header><service></service></loginTicketRequest>";
        private static uint _globalUniqueID = 0;

        //CREAR CONSTRUCTOR
        //guardar string loginTicketResponse
        //CARGAR VARIABLES de ultimo obtenerticket

        public string ObtenerTicket(int Id_Empresa)
        {
            //Version esta linea
            //  System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            //System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
            //************************************************************************************

            Empresas Empresa;
            using (GestionContext db = new GestionContext())
            {
                Empresa = new Empresas() { Id = Id_Empresa };
                db.Empresas.Attach(Empresa);
                db.Entry(Empresa).Reload();
            }

            if (Empresa.Id == 0) throw new ValidationException("Debe ingresar una empresa.");
            if (Empresa.RutaCertSigner == "" || Empresa.RutaCertSigner == null) throw new ValidationException("Debe ingresar la ruta del certificado para la empresa.");
            if (Empresa.ClaveCertSigner == "" || Empresa.ClaveCertSigner == null) throw new ValidationException("Debe ingresar la contraseña del certificado de la empresa.");

            string argRutaCertX509Firmante = Empresa.RutaCertSigner;
            string argClaveCertX509Firmante = Empresa.ClaveCertSigner;
            string argServicio = "wsfe";

            switch (Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.AFIP_WebService_Presentacion)))
            {
                case 1:
                    argServicio = "wsfe";
                    break;
                case 2:
                    argServicio = "wsmtxca";
                    break;
            }

            string argUrlWsaa = Parametro.ObtenerValor(Parametro.Param.AFIP_URL_WSAA);

            RutaDelCertificadoFirmante = argRutaCertX509Firmante;

            string cmsFirmadoBase64;
            string loginTicketResponse;

            XmlNode xmlNodoUniqueId;
            XmlNode xmlNodoGenerationTime;
            XmlNode xmlNodoExpirationTime;
            XmlNode xmlNodoService;

            // PASO 1: Genero el Login Ticket Request 
            try
            {
                XmlLoginTicketRequest = new XmlDocument();
                XmlLoginTicketRequest.LoadXml(XmlStrLoginTicketRequestTemplate);

                xmlNodoUniqueId = XmlLoginTicketRequest.SelectSingleNode("//uniqueId");
                xmlNodoGenerationTime = XmlLoginTicketRequest.SelectSingleNode("//generationTime");
                xmlNodoExpirationTime = XmlLoginTicketRequest.SelectSingleNode("//expirationTime");
                xmlNodoService = XmlLoginTicketRequest.SelectSingleNode("//service");

                xmlNodoGenerationTime.InnerText = DateTime.Now.AddMinutes(-10).ToString("s");
                xmlNodoExpirationTime.InnerText = DateTime.Now.AddMinutes(+10).ToString("s");
                xmlNodoUniqueId.InnerText = Convert.ToString(_globalUniqueID);
                xmlNodoService.InnerText = argServicio;
                Service = argServicio;

                _globalUniqueID += 1;
            }

            catch (Exception excepcionAlGenerarLoginTicketRequest)
            {
                throw new ValidationException("Error GENERANDO el LoginTicketRequest : " + excepcionAlGenerarLoginTicketRequest.Message);
            }

            // PASO 2: Firmo el Login Ticket Request 
            try
            {
                X509Certificate2 certFirmante = CertificadosX509Lib.ObtieneCertificadoDesdeArchivo(RutaDelCertificadoFirmante, argClaveCertX509Firmante);

                // Convierto el login ticket request a bytes, para firmar 
                Encoding EncodedMsg = Encoding.UTF8;
                byte[] msgBytes = EncodedMsg.GetBytes(XmlLoginTicketRequest.OuterXml);

                // Firmo el msg y paso a Base64 
                byte[] encodedSignedCms = CertificadosX509Lib.FirmaBytesMensaje(msgBytes, certFirmante);
                cmsFirmadoBase64 = Convert.ToBase64String(encodedSignedCms);
            }

            catch (Exception excepcionAlFirmar)
            {
                throw new ValidationException("Error FIRMANDO el LoginTicketRequest : " + excepcionAlFirmar.Message);
            }

            // PASO 3: Invoco al WSAA para obtener el Login Ticket Response 
            try
            {
                Wsaa.LoginCMSService servicioWsaa = new Wsaa.LoginCMSService();
                servicioWsaa.Url = argUrlWsaa;

                loginTicketResponse = servicioWsaa.loginCms(cmsFirmadoBase64);
            }

            catch (Exception excepcionAlInvocarWsaa)
            {
                throw new ValidationException("Error INVOCANDO al servicio WSAA : " + excepcionAlInvocarWsaa.Message);
            }

            // PASO 4: Analizo el Login Ticket Response recibido del WSAA 
            try
            {
                XmlLoginTicketResponse = new XmlDocument();
                XmlLoginTicketResponse.LoadXml(loginTicketResponse);

                UniqueId = uint.Parse(XmlLoginTicketResponse.SelectSingleNode("//uniqueId").InnerText);
                GenerationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//generationTime").InnerText);
                ExpirationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//expirationTime").InnerText);
                Sign = XmlLoginTicketResponse.SelectSingleNode("//sign").InnerText;
                Token = XmlLoginTicketResponse.SelectSingleNode("//token").InnerText;
                CuitEmisor = Convert.ToInt64(Empresa.Cuit.Replace("-", ""));
            }
            catch (Exception excepcionAlAnalizarLoginTicketResponse)
            {
                throw new ValidationException("Error Analizando el Ticket: " + excepcionAlAnalizarLoginTicketResponse.Message);
            }

            return loginTicketResponse;
        }

        public void ObtenerTablaIvaReceptor(LoginTicket objTicket)
        {

            Wsfev1.Service client = new Wsfev1.Service();
            client.Url = Parametro.ObtenerValor(Parametro.Param.AFIP_URL_WSFE); 
 
            Wsfev1.FEAuthRequest fe1 = new Wsfev1.FEAuthRequest();
            fe1.Cuit = objTicket.CuitEmisor; // CUIT DEL EMISOR
            fe1.Sign = objTicket.Sign; //SIGN DEL WSAA
            fe1.Token = objTicket.Token; //TOKEN DEL WSAA

            //Definición de la factura
            Wsfev1.FECAERequest fc = new Wsfev1.FECAERequest();

            var respuesta = client.FEParamGetCondicionIvaReceptor(fe1, null);

            respuesta = null;

        }

        public ComprobantesVentas PresentarComprobante(LoginTicket objTicket, int IdComprobanteVenta)
        {
            try
            {
                int TipoPresentacion = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.AFIP_WebService_Presentacion));
                ComprobantesVentas r = new ComprobantesVentas();

                switch (TipoPresentacion)
                {
                    case 1:
                        r = PresentarComprobanteWSFEV1(objTicket, IdComprobanteVenta);
                        break;
                    case 2:
                        r = PresentarComprobanteWSMTXCA(objTicket, IdComprobanteVenta);
                        break;
                }
                return r;
            }
            catch (ValidationException exv)
            {
                throw new ValidationException(exv.Message);
            }
            catch (Exception e)
            {
                throw new ValidationException(e.Message);
            }
        }

        public ComprobantesVentas PresentarComprobanteWSFEV1(LoginTicket objTicket, int IdComprobanteVenta)
        {
            try
            {
                //Presentación
                //WSFEv1
                //testing: https://wswhomo.afip.gov.ar/wsfev1/service.asmx
                //producción: https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL

                string strUrlWsfeWsdl = Parametro.ObtenerValor(Parametro.Param.AFIP_URL_WSFE);

                if (objTicket.ExpirationTime < DateTime.Now)
                    throw new ValidationException("Se debe generar un nuevo Ticket.");

                GestionContext db = new GestionContext();

                ComprobantesVentas Comprobante = new ComprobantesVentas() { Id = IdComprobanteVenta };
                db.ComprobantesVentas.Attach(Comprobante);
                db.Entry(Comprobante).Reload();

                if (Comprobante.Detalle == null)
                    db.Entry(Comprobante).Collection(p => p.Detalle).Load();

                if (Comprobante.Impuestos == null)
                    db.Entry(Comprobante).Collection(p => p.Impuestos).Load();

                //if (Comprobante.ResultadoCAE != "A" && (Comprobante.ResultadoCAE != "" && Comprobante.ResultadoCAE != null))
                if (Comprobante.AFIPCAE != null && Comprobante.AFIPCAE.Trim() != "")
                    throw new ValidationException("El comprobante ya ha sido procesado.");

                if (Comprobante.Id != (db.ComprobantesVentas.Where(t => t.UserDel == null && t.FechaAnulacion == null && t.Id_Sucursal == Comprobante.Id_Sucursal && t.Id_TalonariosComprobantes == Comprobante.Id_TalonariosComprobantes && (t.AFIPCAE == "" || t.AFIPCAE == null)).OrderBy(t => new { t.Fecha, t.Letra, t.PuntoVenta, t.NroComprobante }).Select(t => t.Id).FirstOrDefault()))
                    throw new ValidationException("Existen comprobantes anteriores sin procesar.");

                if (Comprobante.Fecha.AddDays(5) < Sistema.ObtenerFecha())
                    throw new ValidationException("La fecha del comprobante es anterior a 5 días.");

                Wsfev1.Service client = new Wsfev1.Service();
                client.Url = strUrlWsfeWsdl;

                double ImpTributos = Convert.ToDouble(Comprobante.OtrosImpuestos + Comprobante.PercepcionIIBB + Comprobante.PercepcionIva + Comprobante.Retenciones);
                ImpTributos += Convert.ToDouble(Comprobante.Impuestos.Where(t => t.UserDel == null).Select(t => t.Importe).Sum());

                Wsfev1.FEAuthRequest fe1 = new Wsfev1.FEAuthRequest();
                fe1.Cuit = objTicket.CuitEmisor; // CUIT DEL EMISOR
                fe1.Sign = objTicket.Sign; //SIGN DEL WSAA
                fe1.Token = objTicket.Token; //TOKEN DEL WSAA

                //Definición de la factura
                Wsfev1.FECAERequest fc = new Wsfev1.FECAERequest();

                //Encabezados
                Wsfev1.FECAECabRequest cabecera = new Wsfev1.FECAECabRequest();
                cabecera.CantReg = 1;// Comprobante.Detalle.Where(t => t.UserDel == null).Count();
                cabecera.CbteTipo = (from ac in db.AFIP_Comprobantes
                                     join tc in db.TalonariosComprobantes on ac.Id equals tc.Id_AFIP_Comprobante into listAC
                                     from a in listAC
                                     where a.Id == Comprobante.Id_TalonariosComprobantes
                                     select ac.Id).FirstOrDefault(); //Factura A (Ver tipos de comprobantes)
                cabecera.PtoVta = Convert.ToInt32(Comprobante.PuntoVenta); //Punto de venta a autorizar

                fc.FeCabReq = cabecera; // Asignar a la cabecera de la factura

                //Detalle
                Wsfev1.FECAEDetRequest detalle = new Wsfev1.FECAEDetRequest();

                detalle.Concepto = 1; // Concepto de comprbantes (Ver conceptos)

                detalle.DocTipo = 80;// Codigo de documento del comprador (Ver codigos de documentos)
                try
                {
                    detalle.DocNro = Comprobante.Id_TipoEntidad == Enums.TipoEntidad.Cliente ? Convert.ToInt64(db.Clientes.Where(c => c.Id == Comprobante.Id_Entidad).Select(c => c.Cuit).FirstOrDefault().Replace("-", ""))
                               : Comprobante.Id_TipoEntidad == Enums.TipoEntidad.Proveedor ? Convert.ToInt64(db.Proveedores.Where(c => c.Id == Comprobante.Id_Entidad).Select(c => c.Cuit).FirstOrDefault().Replace("-", ""))
                               : Comprobante.Id_TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? Convert.ToInt64(db.ProvFinancieros.Where(c => c.Id == Comprobante.Id_Entidad).Select(c => c.Cuit).FirstOrDefault().Replace("-", ""))
                               : Comprobante.Id_TipoEntidad == Enums.TipoEntidad.Personal ? Convert.ToInt64(db.Personal.Where(c => c.Id == Comprobante.Id_Entidad).Select(c => c.Cuit).FirstOrDefault().Replace("-", ""))
                                 : 0;
                }
                catch (Exception)
                {
                    throw new ValidationException("La entidad no posee un cuit cargado.");
                }
                if (detalle.DocNro == 0)
                    if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.AFIP_UtilizaDocumentoCeroASinCuit)))
                        detalle.DocTipo = 99;

                //SACAR DE https://wswhomo.afip.gov.ar/wsseg/service.asmx
                detalle.CondicionIVAReceptorId = 0;

                detalle.CbteDesde = Convert.ToInt64(Comprobante.NroComprobante); //Nro comprobante desde
                detalle.CbteHasta = Convert.ToInt64(Comprobante.NroComprobante); //Nro comprobante hasta
                detalle.CbteFch = Comprobante.Fecha.ToString("yyyyMMdd");
                detalle.ImpTotal = Convert.ToDouble(Comprobante.Importe); //Total = no gravado + exento + neto + todos los iva + tributos (ej. perc.iibb)
                                                                          //**************************************************************
                detalle.ImpNeto = Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null).Select(t => (t.ImporteUnitario * t.Cantidad) - ((t.ImporteUnitario * t.Cantidad) * t.PorcDescuento / 100)).Sum().ToString("N2")); // neto gravado
                                                                                                                                                                                                                                       //detalle.ImpNeto = Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null && t.ImporteIVA != 0).Select(t => (t.ImporteUnitario * t.Cantidad) - ((t.ImporteUnitario * t.Cantidad) * t.PorcDescuento / 100)).Sum().ToString("N2")); // neto gravado

                detalle.ImpTotConc = 0; //No gravado
                detalle.ImpOpEx = 0;//Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null && t.ImporteIVA == 0).Select(t => (t.ImporteUnitario * t.Cantidad) - ((t.ImporteUnitario * t.Cantidad) * t.PorcDescuento / 100)).Sum().ToString("N2"));  // Exento
                                    //detalle.ImpTotConc = Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null && t.ImporteIVA == 0).Select(t => (t.ImporteUnitario * t.Cantidad) - ((t.ImporteUnitario * t.Cantidad) * t.PorcDescuento / 100)).Sum().ToString("N2"));   //No gravado
                                    //detalle.ImpOpEx = 0;// Exento
                                    //**************************************************************

                detalle.ImpIVA = Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null && t.ImporteIVA != 0).Select(t => t.ImporteIVA).Sum().ToString("N2")); // suma de los importes del array de iva
                detalle.ImpTrib = ImpTributos; // suma de los importes del array de tributos, ej. perc iibb
                                               //detalle.FchServDesde = ""; // fecha inicio abono para servicios
                                               //detalle.FchServHasta = ""; // fecha fin abono para servicios
                                               //detalle.FchVtoPago = ""; // fecha vto para servicios
                detalle.MonId = "PES"; //moneda
                detalle.MonCotiz = 1; //cotizacion


                if (cabecera.CbteTipo == 2 || cabecera.CbteTipo == 3 || cabecera.CbteTipo == 7 || cabecera.CbteTipo == 8 ||
                  cabecera.CbteTipo == 12 || cabecera.CbteTipo == 13)
                {
                    if (Comprobante.Id_ComprobanteVenta_Asociado == null)
                        throw new ValidationException("Debe asociar un comprobante para Nota de Débito/Crédito.");
                    else
                    {
                        ComprobantesVentas Asociado = new ComprobantesVentas() { Id = Convert.ToInt32(Comprobante.Id_ComprobanteVenta_Asociado) };
                        db.Entry(Asociado).State = System.Data.Entity.EntityState.Unchanged;
                        db.Entry(Asociado).Reload();

                        detalle.CbtesAsoc = new Wsfev1.CbteAsoc[1];
                        detalle.CbtesAsoc[0] = new Wsfev1.CbteAsoc()
                        {
                            //CbteFch = "",
                            //Cuit = "",
                            Nro = Convert.ToInt32(Asociado.NroComprobante),
                            PtoVta = Convert.ToInt32(Asociado.PuntoVenta),
                            Tipo = (from ac in db.AFIP_Comprobantes
                                    join tc in db.TalonariosComprobantes on ac.Id equals tc.Id_AFIP_Comprobante into listAC
                                    from a in listAC
                                    where a.Id == Asociado.Id_TalonariosComprobantes
                                    select ac.Id).FirstOrDefault()
                        };
                    }
                }

                //como relacionarlo con fc.FeDetReq
                fc.FeDetReq = new Wsfev1.FECAEDetRequest[1];
                fc.FeDetReq[0] = detalle;

                //TRIBUTOS
                if (ImpTributos > 0)
                {
                    int ii = 0;
                    foreach (var r in Comprobante.Impuestos)
                    {
                        var _Id = db.TipoImpuestos.Where(t => t.Id == r.Id_Impuesto && t.UserDel == null).Select(t => t.Id_AFIP_Tributos).FirstOrDefault();



                        fc.FeDetReq[0].Tributos = new Wsfev1.Tributo[ii + 1];
                        fc.FeDetReq[0].Tributos[ii] = new Wsfev1.Tributo()
                        {
                            Alic = Convert.ToDouble(r.Alicuota),
                            BaseImp = Convert.ToDouble(r.ImporteBaseImponible),
                            Desc = "",
                            Id = Convert.ToInt16(db.TipoImpuestos.Where(t => t.Id == r.Id_Impuesto && t.UserDel == null).Select(t => t.Id_AFIP_Tributos).FirstOrDefault()),
                            Importe = Convert.ToDouble(r.Importe)
                        };

                    }
                    //fc.FeDetReq[0].Tributos = new Wsfev1.Tributo[1];
                    //fc.FeDetReq[0].Tributos[0] = new Wsfev1.Tributo() { Alic = 1, BaseImp = ImpTributos, Desc = "", Id = 1, Importe = ImpTributos };
                }

                //IVA
                // LISTADO PARAMETROS
                // IvaTipoResponse itr = client.FEParamGetTiposIva(fe1);

                int i = 0;
                fc.FeDetReq[0].Iva = new Wsfev1.AlicIva[Comprobante.Detalle.Where(t => t.UserDel == null).Select(t => t.AlicuotaIva).Distinct().Count()];

                foreach (decimal ai in Comprobante.Detalle.Where(t => t.UserDel == null).Select(t => t.AlicuotaIva).Distinct())
                {
                    if (ai == 0)
                    {
                        Wsfev1.AlicIva Iva = new Wsfev1.AlicIva();
                        Iva.Id = 3;
                        Iva.BaseImp = Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => (t.ImporteUnitario * t.Cantidad) - ((t.ImporteUnitario * t.Cantidad) * t.PorcDescuento / 100)).Sum().ToString("N2")); ;
                        Iva.Importe = 0;

                        fc.FeDetReq[0].Iva[i] = Iva;
                        i += 1;
                    }

                    if (ai == Convert.ToDecimal(10.5))
                    {
                        Wsfev1.AlicIva Iva = new Wsfev1.AlicIva();
                        Iva.Id = 4;
                        Iva.BaseImp = Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => (t.ImporteUnitario * t.Cantidad) - ((t.ImporteUnitario * t.Cantidad) * t.PorcDescuento / 100)).Sum().ToString("N2"));
                        Iva.Importe = Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => t.ImporteIVA).Sum().ToString("N2"));

                        fc.FeDetReq[0].Iva[i] = Iva;
                        i += 1;
                    }

                    if (ai == Convert.ToDecimal(21))
                    {
                        Wsfev1.AlicIva Iva = new Wsfev1.AlicIva();
                        Iva.Id = 5;
                        Iva.BaseImp = Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => (t.ImporteUnitario * t.Cantidad) - ((t.ImporteUnitario * t.Cantidad) * t.PorcDescuento / 100)).Sum().ToString("N2"));
                        Iva.Importe = Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => t.ImporteIVA).Sum().ToString("N2"));

                        fc.FeDetReq[0].Iva[i] = Iva;
                        i += 1;
                    }

                    if (ai == Convert.ToDecimal(27))
                    {
                        Wsfev1.AlicIva Iva = new Wsfev1.AlicIva();
                        Iva.Id = 6;
                        Iva.BaseImp = Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => (t.ImporteUnitario * t.Cantidad) - ((t.ImporteUnitario * t.Cantidad) * t.PorcDescuento / 100)).Sum().ToString("N2"));
                        Iva.Importe = Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => t.ImporteIVA).Sum().ToString("N2"));

                        fc.FeDetReq[0].Iva[i] = Iva;
                        i += 1;
                    }

                    if (ai == Convert.ToDecimal(5))
                    {
                        Wsfev1.AlicIva Iva = new Wsfev1.AlicIva();
                        Iva.Id = 8;
                        Iva.BaseImp = Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => (t.ImporteUnitario * t.Cantidad) - ((t.ImporteUnitario * t.Cantidad) * t.PorcDescuento / 100)).Sum().ToString("N2"));
                        Iva.Importe = Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => t.ImporteIVA).Sum().ToString("N2"));

                        fc.FeDetReq[0].Iva[i] = Iva;
                        i += 1;
                    }

                    if (ai == Convert.ToDecimal(2.5))
                    {
                        Wsfev1.AlicIva Iva = new Wsfev1.AlicIva();
                        Iva.Id = 9;
                        Iva.BaseImp = Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => (t.ImporteUnitario * t.Cantidad) - ((t.ImporteUnitario * t.Cantidad) * t.PorcDescuento / 100)).Sum().ToString("N2"));
                        Iva.Importe = Convert.ToDouble(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => t.ImporteIVA).Sum().ToString("N2"));

                        fc.FeDetReq[0].Iva[i] = Iva;
                        i += 1;
                    }
                }

                // Verificación ultimo Presentado
                //Wsfev1.FERecuperaLastCbteResponse ult1 = client.FECompUltimoAutorizado(fe1, cabecera.PtoVta, cabecera.CbteTipo);

                Wsfev1.FECAEResponse result = client.FECAESolicitar(fe1, fc);

                if (result.Errors != null)
                    foreach (var e in result.Errors)
                    {
                        if (e.Code == 10016)
                        {
                            Wsfev1.FERecuperaLastCbteResponse ult = client.FECompUltimoAutorizado(fe1, cabecera.PtoVta, cabecera.CbteTipo);
                            throw new ValidationException(string.Format("El último comprobante presentado fue {0} y se está presentando {1}.", ult.CbteNro.ToString("00000000"), Comprobante.NroComprobante));
                        }
                        else
                            throw new ValidationException(e.Code + " - " + e.Msg + "\r\n");
                    }

                string Mensajes = "";

                if (result.Events != null)
                    foreach (var e in result.Events)
                    {
                        Mensajes += e.Code + " - " + e.Msg + "\r\n";
                    }

                string Observaciones = "";

                if (result.FeDetResp[0].Observaciones != null)
                    foreach (var e in result.FeDetResp[0].Observaciones)
                    {
                        if (e.Code == 10016)
                        {
                            Wsfev1.FERecuperaLastCbteResponse ult = client.FECompUltimoAutorizado(fe1, cabecera.PtoVta, cabecera.CbteTipo);
                            throw new ValidationException(string.Format("El último comprobante presentado fue {0} y se está presentando {1}.", ult.CbteNro.ToString("00000000"), Comprobante.NroComprobante));
                        }
                        else
                            // throw new ValidationException(e.Code + " - " + e.Msg + "\r\n");
                            Observaciones += e.Code + " - " + e.Msg + "\r\n";
                    }

                Comprobante.AFIPCAE = result.FeDetResp[0].CAE;
                Comprobante.FechaVtoCAE = result.FeDetResp[0].CAEFchVto;
                Comprobante.ResultadoCAE = result.FeCabResp.Resultado;
                Comprobante.ObservacionesCAE = Observaciones;
                Comprobante.EventosCAE = Mensajes;

                db.SaveChanges();

                return Comprobante;
            }
            catch (Exception e)
            {
                objTicket.ExpirationTime = new DateTime(2001, 01, 01);
                throw new ValidationException("Error PRESENTANDO Comprobante: " + e.Message);
            }
        }

        public ComprobantesVentas PresentarComprobanteWSMTXCA(LoginTicket objTicket, int IdComprobanteVenta)
        {
            try
            {
                //Presentación
                //WSMTXCA
                //testing: https://fwshomo.afip.gov.ar/wsmtxca/services/MTXCAService  ?wsdl
                //producción: https://serviciosjava.afip.gob.ar/wsmtxca/services/MTXCAService  ?wsdl

                string strUrlWsfeWsdl = Parametro.ObtenerValor(Parametro.Param.AFIP_URL_WSFE);

                if (objTicket.ExpirationTime < DateTime.Now)
                    throw new ValidationException("Se debe generar un nuevo Ticket.");

                GestionContext db = new GestionContext();

                ComprobantesVentas Comprobante = new ComprobantesVentas() { Id = IdComprobanteVenta };
                db.ComprobantesVentas.Attach(Comprobante);
                db.Entry(Comprobante).Reload();

                if (Comprobante.Detalle == null)
                    db.Entry(Comprobante).Collection(p => p.Detalle).Load();

                if (Comprobante.ResultadoCAE != "A" && (Comprobante.ResultadoCAE != "" && Comprobante.ResultadoCAE != null))
                    throw new ValidationException("El comprobante ya ha sido procesado.");

                if (Comprobante.Id != (db.ComprobantesVentas.Where(t => t.UserDel == null && t.FechaAnulacion == null && t.Id_Sucursal == Comprobante.Id_Sucursal && t.Id_TalonariosComprobantes == Comprobante.Id_TalonariosComprobantes && (t.AFIPCAE == "" || t.AFIPCAE == null)).OrderBy(t => new { t.Fecha, t.Letra, t.PuntoVenta, t.NroComprobante }).Select(t => t.Id).FirstOrDefault()))
                    throw new ValidationException("Existen comprobantes anteriores sin procesar.");

                if (Comprobante.Fecha.AddDays(5) < Sistema.ObtenerFecha())
                    throw new ValidationException("La fecha del comprobante es anterior a 5 días.");


                Wsmtxca.MTXCAService client = new Wsmtxca.MTXCAService();
                client.Url = strUrlWsfeWsdl;

                decimal ImpTributos = Convert.ToDecimal(Comprobante.OtrosImpuestos + Comprobante.PercepcionIIBB + Comprobante.PercepcionIva + Comprobante.Retenciones);


                //FEAuthRequest fe1 = new FEAuthRequest();
                Wsmtxca.AuthRequestType fe1 = new Wsmtxca.AuthRequestType();
                fe1.cuitRepresentada = objTicket.CuitEmisor; // CUIT DEL EMISOR
                fe1.sign = objTicket.Sign; //SIGN DEL WSAA
                fe1.token = objTicket.Token; //TOKEN DEL WSAA

                //Definición de la factura
                Wsmtxca.AuthRequestType fc = new Wsmtxca.AuthRequestType();
                //FECAERequest fc = new FECAERequest();

                Wsmtxca.ComprobanteType detalle = new Wsmtxca.ComprobanteType();
                detalle.codigoTipoComprobante = Convert.ToInt16((from ac in db.AFIP_Comprobantes
                                                                 join tc in db.TalonariosComprobantes on ac.Id equals tc.Id_AFIP_Comprobante into listAC
                                                                 from a in listAC
                                                                 where a.Id == Comprobante.Id_TalonariosComprobantes
                                                                 select ac.Id).FirstOrDefault());
                detalle.numeroPuntoVenta = Convert.ToInt16(Comprobante.PuntoVenta);
                detalle.numeroComprobante = Convert.ToInt64(Comprobante.NroComprobante);
                detalle.fechaEmision = Comprobante.Fecha;
                detalle.codigoTipoDocumento = 80;//CUIT
                detalle.numeroDocumento = Comprobante.Id_TipoEntidad == Enums.TipoEntidad.Cliente ? Convert.ToInt64(db.Clientes.Where(c => c.Id == Comprobante.Id_Entidad).Select(c => c.Cuit).FirstOrDefault().Replace("-", ""))
                                : Comprobante.Id_TipoEntidad == Enums.TipoEntidad.Proveedor ? Convert.ToInt64(db.Proveedores.Where(c => c.Id == Comprobante.Id_Entidad).Select(c => c.Cuit).FirstOrDefault().Replace("-", ""))
                                : Comprobante.Id_TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? Convert.ToInt64(db.ProvFinancieros.Where(c => c.Id == Comprobante.Id_Entidad).Select(c => c.Cuit).FirstOrDefault().Replace("-", ""))
                                : Comprobante.Id_TipoEntidad == Enums.TipoEntidad.Personal ? Convert.ToInt64(db.Personal.Where(c => c.Id == Comprobante.Id_Entidad).Select(c => c.Cuit).FirstOrDefault().Replace("-", ""))
                                : 0;
                detalle.importeGravado = Convert.ToDecimal(Comprobante.Detalle.Where(t => t.UserDel == null && t.ImporteIVA != 0).Select(t => t.Importe).Sum());
                detalle.importeNoGravado = Convert.ToDecimal(Comprobante.Detalle.Where(t => t.UserDel == null && t.ImporteIVA == 0).Select(t => t.Importe).Sum());
                detalle.importeExento = 0;
                detalle.importeSubtotal = Convert.ToDecimal(Comprobante.Detalle.Where(t => t.UserDel == null).Select(t => t.Importe).Sum());
                detalle.importeOtrosTributos = ImpTributos;
                detalle.importeTotal = Convert.ToDecimal(Comprobante.Importe);
                detalle.codigoMoneda = "PES";
                detalle.cotizacionMoneda = 1;
                detalle.observaciones = Comprobante.Observaciones;
                detalle.codigoConcepto = 1;

                //TRIBUTOS
                if (ImpTributos > 0)
                {
                    detalle.arrayOtrosTributos = new Wsmtxca.OtroTributoType[0];
                    detalle.arrayOtrosTributos[0] = new Wsmtxca.OtroTributoType();

                    detalle.arrayOtrosTributos[0].codigo = 99;
                    detalle.arrayOtrosTributos[0].descripcion = "Otros Tributos";
                    detalle.arrayOtrosTributos[0].baseImponible = 100;
                    detalle.arrayOtrosTributos[0].importe = ImpTributos;
                }

                //DETALLE
                int i = Comprobante.Detalle.Where(t => t.UserDel == null).Count();
                detalle.arrayItems = new Wsmtxca.ItemType[i];
                i = 0;

                foreach (ComprobantesVentasDetalle d in Comprobante.Detalle)
                {
                    detalle.arrayItems[i] = new Wsmtxca.ItemType();

                    detalle.arrayItems[i].unidadesMtx = 1;
                    detalle.arrayItems[i].codigoMtx = "7790001001122";
                    detalle.arrayItems[i].codigo = d.Id_Producto.ToString();
                    detalle.arrayItems[i].descripcion = d.Descripcion;
                    detalle.arrayItems[i].cantidad = d.Cantidad;
                    detalle.arrayItems[i].codigoUnidadMedida = 7;
                    detalle.arrayItems[i].precioUnitario = d.ImporteUnitario;
                    detalle.arrayItems[i].importeBonificacion = 0;
                    detalle.arrayItems[i].codigoCondicionIVA = Convert.ToInt16(d.Id_AlicuotaIva);
                    detalle.arrayItems[i].importeIVA = d.ImporteIVA;
                    detalle.arrayItems[i].importeItem = d.Importe;

                    i += 1;
                }


                ////como relacionarlo con fc.FeDetReq
                //fc.FeDetReq = new FECAEDetRequest[1];
                //fc.FeDetReq[0] = detalle;

                //TRIBUTOS


                //IVA
                // LISTADO PARAMETROS
                // IvaTipoResponse itr = client.FEParamGetTiposIva(fe1);

                i = 0;
                detalle.arraySubtotalesIVA = new Wsmtxca.SubtotalIVAType[Comprobante.Detalle.Where(t => t.UserDel == null).Select(t => t.AlicuotaIva).Distinct().Count()];

                foreach (decimal ai in Comprobante.Detalle.Where(t => t.UserDel == null).Select(t => t.AlicuotaIva).Distinct())
                {
                    if (ai == 0)
                    {
                        detalle.arraySubtotalesIVA[i] = new Wsmtxca.SubtotalIVAType();
                        detalle.arraySubtotalesIVA[i].codigo = 3;
                        detalle.arraySubtotalesIVA[i].importe = 0;
                        i += 1;
                    }

                    if (ai == Convert.ToDecimal(10.5))
                    {
                        detalle.arraySubtotalesIVA[i] = new Wsmtxca.SubtotalIVAType();
                        detalle.arraySubtotalesIVA[i].codigo = 4;
                        detalle.arraySubtotalesIVA[i].importe = Convert.ToDecimal(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => t.ImporteIVA).Sum());
                        i += 1;
                    }

                    if (ai == Convert.ToDecimal(21))
                    {
                        detalle.arraySubtotalesIVA[i] = new Wsmtxca.SubtotalIVAType();
                        detalle.arraySubtotalesIVA[i].codigo = 5;
                        detalle.arraySubtotalesIVA[i].importe = Convert.ToDecimal(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => t.ImporteIVA).Sum());
                        i += 1;
                    }

                    if (ai == Convert.ToDecimal(27))
                    {
                        detalle.arraySubtotalesIVA[i] = new Wsmtxca.SubtotalIVAType();
                        detalle.arraySubtotalesIVA[i].codigo = 6;
                        detalle.arraySubtotalesIVA[i].importe = Convert.ToDecimal(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => t.ImporteIVA).Sum());
                        i += 1;
                    }

                    if (ai == Convert.ToDecimal(5))
                    {
                        detalle.arraySubtotalesIVA[i] = new Wsmtxca.SubtotalIVAType();
                        detalle.arraySubtotalesIVA[i].codigo = 8;
                        detalle.arraySubtotalesIVA[i].importe = Convert.ToDecimal(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => t.ImporteIVA).Sum());
                        i += 1;
                    }

                    if (ai == Convert.ToDecimal(2.5))
                    {
                        detalle.arraySubtotalesIVA[i] = new Wsmtxca.SubtotalIVAType();
                        detalle.arraySubtotalesIVA[i].codigo = 9;
                        detalle.arraySubtotalesIVA[i].importe = Convert.ToDecimal(Comprobante.Detalle.Where(t => t.UserDel == null && t.AlicuotaIva == ai).Select(t => t.ImporteIVA).Sum());
                        i += 1;
                    }
                }

                // Verificación ultimo Presentado
                //FERecuperaLastCbteResponse ult = client.FECompUltimoAutorizado(fe1, cabecera.PtoVta, cabecera.CbteTipo);
                Wsmtxca.ComprobanteCAEResponseType ComprobanteResponse = new Wsmtxca.ComprobanteCAEResponseType();
                Wsmtxca.CodigoDescripcionType[] Observaciones = new Wsmtxca.CodigoDescripcionType[0];
                Wsmtxca.CodigoDescripcionType[] Errores = new Wsmtxca.CodigoDescripcionType[0];
                Wsmtxca.CodigoDescripcionType Eventos = new Wsmtxca.CodigoDescripcionType();

                //client.consultarCondicionesIVA(fe1,out Eventos);

                client.autorizarComprobante(fe1, detalle, out ComprobanteResponse, out Observaciones, out Errores, out Eventos);
                //Wsmtxca.autorizarComprobanteCompletedEventArgs result = new  Wsmtxca.autorizarComprobanteCompletedEventArgs()
                //FECAEResponse result = client.FECAESolicitar(fe1, fc);

                if (Errores != null)
                    foreach (var e in Errores)
                    {
                        if (e.codigo == 10016)
                        {
                            //            FERecuperaLastCbteResponse ult = client.FECompUltimoAutorizado(fe1, cabecera.PtoVta, cabecera.CbteTipo);
                            //            throw new ValidationException(string.Format("El último comprobante presentado fue {0} y se está presentando {1}.", ult.CbteNro.ToString("00000000"), Comprobante.NroComprobante));
                        }
                        else
                            throw new ValidationException(e.codigo + " - " + e.descripcion + "\r\n");
                    }

                string Mensajes = "";

                if (Eventos != null)
                    //foreach (var e in Eventos)
                    //{
                    Mensajes += Eventos.codigo + " - " + Eventos.descripcion + "\r\n";
                //}

                string strObservaciones = "";

                if (Observaciones != null)
                    foreach (var e in Observaciones)
                    {
                        strObservaciones += e.codigo + " - " + e.descripcion + "\r\n";
                    }

                Comprobante.AFIPCAE = ComprobanteResponse.CAE.ToString();
                Comprobante.FechaVtoCAE = ComprobanteResponse.fechaVencimientoCAE.ToString("yyyyMMdd");
                //Comprobante.ResultadoCAE = ComprobanteResponse.Resultado;
                Comprobante.ObservacionesCAE = strObservaciones;
                Comprobante.EventosCAE = Mensajes;

                db.SaveChanges();

                return Comprobante;
            }
            catch (Exception e)
            {
                objTicket.ExpirationTime = new DateTime(2001, 01, 01);
                throw new ValidationException("Error PRESENTANDO Comprobante: " + e.Message);
            }
        }

        public ComprobantesVentas ActualizarComprobante(LoginTicket objTicket, int IdComprobanteVenta)
        {
            try
            {
                int TipoPresentacion = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.AFIP_WebService_Presentacion));
                ComprobantesVentas r = new ComprobantesVentas();

                if (TipoPresentacion != 1)
                    return r;

                string strUrlWsfeWsdl = Parametro.ObtenerValor(Parametro.Param.AFIP_URL_WSFE);

                if (objTicket.ExpirationTime < DateTime.Now)
                    throw new ValidationException("Se debe generar un nuevo Ticket.");

                GestionContext db = new GestionContext();

                ComprobantesVentas Comprobante = new ComprobantesVentas() { Id = IdComprobanteVenta };
                db.ComprobantesVentas.Attach(Comprobante);
                db.Entry(Comprobante).Reload();

                if (Comprobante.Detalle == null)
                    db.Entry(Comprobante).Collection(p => p.Detalle).Load();

                if (Comprobante.Impuestos == null)
                    db.Entry(Comprobante).Collection(p => p.Impuestos).Load();

                Wsfev1.Service client = new Wsfev1.Service();
                client.Url = strUrlWsfeWsdl;

                Wsfev1.FEAuthRequest fe1 = new Wsfev1.FEAuthRequest();
                fe1.Cuit = objTicket.CuitEmisor; // CUIT DEL EMISOR
                fe1.Sign = objTicket.Sign; //SIGN DEL WSAA
                fe1.Token = objTicket.Token; //TOKEN DEL WSAA

                Wsfev1.FECompConsultaReq fc = new Wsfev1.FECompConsultaReq();
                fc.CbteNro = Convert.ToInt64(Comprobante.NroComprobante);
                fc.CbteTipo = (from ac in db.AFIP_Comprobantes
                               join tc in db.TalonariosComprobantes on ac.Id equals tc.Id_AFIP_Comprobante into listAC
                               from a in listAC
                               where a.Id == Comprobante.Id_TalonariosComprobantes
                               select ac.Id).FirstOrDefault(); //Factura A (Ver tipos de comprobantes)
                fc.PtoVta = Convert.ToInt32(Comprobante.PuntoVenta); //Punto de venta a autorizar


                Wsfev1.FECompConsultaResponse result = client.FECompConsultar(fe1, fc);


                if (result.Errors != null)
                    foreach (var e in result.Errors)
                    {
                        throw new ValidationException(e.Code + " - " + e.Msg + "\r\n");
                    }

                string Mensajes = "";

                if (result.Events != null)
                    foreach (var e in result.Events)
                    {
                        Mensajes += e.Code + " - " + e.Msg + "\r\n";
                    }

                Comprobante.AFIPCAE = result.ResultGet.CodAutorizacion;
                Comprobante.FechaVtoCAE = result.ResultGet.FchVto;
                Comprobante.ResultadoCAE = result.ResultGet.Resultado;
                Comprobante.EventosCAE = Mensajes;

                db.SaveChanges();

                return Comprobante;
            }
            catch (ValidationException exv)
            {
                throw new ValidationException(exv.Message);
            }
            catch (Exception e)
            {
                throw new ValidationException(e.Message);
            }
        }

    }
}