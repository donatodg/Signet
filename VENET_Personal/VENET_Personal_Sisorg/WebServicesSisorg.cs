namespace VENET_Personal_Sisorg
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class WebServicesSisorg
    {
        public static void ActualizarIdsEmpleados()
        {
            {
                Token.TokenSoapClient t = new Token.TokenSoapClient();
                Tripulante.TripulanteSoapClient x = new Tripulante.TripulanteSoapClient();

                string token = XElement.Parse(t.GetToken("AABBBEAALJACAZCGA", "ERSA")).FirstAttribute.Value;

                string r = x.GetTripulante(token, "", "", "");

                XDocument doc = XDocument.Parse(r);

                XNamespace rootNs = doc.Root.Name.Namespace;
                XNamespace rowNs = "x-schema:#Schema1";

                foreach (var xe in doc.Element(rootNs + "rows").Elements(rowNs + "row"))
                {
                    if (xe.Attribute("Legajo") != null && xe.Attribute("Id") != null)
                    {
                        using (var db = new ErsaContext())
                        {
                            int Legajo = Convert.ToInt32(xe.Attribute("Legajo").Value);
                            int IdPersonal = db.Personal.Where(tt => tt.UserDel == null && tt.LaboralLegajo == Legajo).Select(tt => tt.Id).FirstOrDefault();

                            if (IdPersonal > 0)
                            {
                                Personal p = new Personal() { Id = IdPersonal };
                                db.Personal.Attach(p);
                                db.Entry(p).Reload();
                                //**************
                                p.ApellidoCasada = xe.Attribute("Id").Value.ToString();
                                //**************

                                db.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        public static void ActualizarIdsCoches()
        {
            {
                Token.TokenSoapClient t = new Token.TokenSoapClient();
                Vehiculos.VehiculoSoapClient x = new Vehiculos.VehiculoSoapClient();

                string token = XElement.Parse(t.GetToken("AABBBEAALJACAZCGA", "ERSA")).FirstAttribute.Value;

                string r = x.GetVehiculo(token, "", "", "");

                XDocument doc = XDocument.Parse(r);

                foreach (var xe in doc.Element("rows").Elements("row"))
                {
                    if (xe.Attribute("Matricula") != null)
                    {
                        using (var db = new ErsaContext())
                        {
                            string Dominio = xe.Attribute("Matricula").Value;
                            Dominio = Dominio.Replace("-", "");//.Replace(" ", "");
                            int IdCoche = db.Coches.Where(tt => tt.UserDel == null && tt.Dominio == Dominio).Select(tt => tt.Id).FirstOrDefault();

                            if (IdCoche > 0)
                            {
                                 Coches c = new Coches() { Id = IdCoche };
                                db.Coches.Attach(c);
                                db.Entry(c).Reload();
                                //**************
                                c.Id_Externo = Convert.ToString(xe.Attribute("Id").Value);
                                //**************

                                db.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        public static List<resultInsert> BuscarPendientes()
        {
            string Legajos = "";

            Token.TokenSoapClient t = new Token.TokenSoapClient();
            Tripulante.TripulanteSoapClient x = new Tripulante.TripulanteSoapClient();

            string token = XElement.Parse(t.GetToken("AABBBEAALJACAZCGA", "ERSA")).FirstAttribute.Value;

            string r = x.GetTripulante(token, "", "", "");

            XDocument doc = XDocument.Parse(r);
            List<result> res = new List<result>();

            XNamespace rootNs = doc.Root.Name.Namespace;
            XNamespace rowNs = "x-schema:#Schema1";

            foreach (var xe in doc.Element(rootNs + "rows").Elements(rowNs + "row"))
            {
                result i = new result();

                if (xe.Attribute("Id") != null) i.Id = Convert.ToInt32(xe.Attribute("Id").Value);
                if (xe.Attribute("Nombre") != null) i.Nombre = xe.Attribute("Nombre").Value;
                if (xe.Attribute("Apellido") != null) i.Apellido = xe.Attribute("Apellido").Value;
                if (xe.Attribute("TipoDocumento") != null) i.TipoDocumento = Convert.ToInt32(xe.Attribute("TipoDocumento").Value);
                if (xe.Attribute("Documento") != null) i.Documento = xe.Attribute("Documento").Value;
                if (xe.Attribute("Legajo") != null) i.Legajo = xe.Attribute("Legajo").Value;
                if (xe.Attribute("Categoria") != null) i.Categoria = Convert.ToInt32(xe.Attribute("Categoria").Value);
                if (xe.Attribute("Edad") != null) i.Edad = Convert.ToInt32(xe.Attribute("Edad").Value);
                if (xe.Attribute("Estado") != null) i.Estado = Convert.ToInt32(xe.Attribute("Estado").Value);
                if (xe.Attribute("FechaIncorporacion") != null) i.FechaIncorporacion = Convert.ToDateTime(xe.Attribute("FechaIncorporacion").Value);
                if (xe.Attribute("NroCarnetProv") != null) i.NroCarnetProv = xe.Attribute("NroCarnetProv").Value;
                if (xe.Attribute("CarnetProvDesde") != null) i.CarnetProvDesde = xe.Attribute("CarnetProvDesde").Value;
                if (xe.Attribute("CarnetProvHasta") != null) i.CarnetProvHasta = xe.Attribute("CarnetProvHasta").Value;
                if (xe.Attribute("NroCarnetNac") != null) i.NroCarnetNac = xe.Attribute("NroCarnetNac").Value;
                if (xe.Attribute("CarnetNacDesde") != null) i.CarnetNacDesde = xe.Attribute("CarnetNacDesde").Value;
                if (xe.Attribute("CarnetNacHasta") != null) i.CarnetNacHasta = xe.Attribute("CarnetNacHasta").Value;
                if (xe.Attribute("GremioID") != null) i.GremioID = Convert.ToInt32(xe.Attribute("GremioID").Value);
                if (xe.Attribute("Email") != null) i.Email = xe.Attribute("Email").Value;
                if (xe.Attribute("DireccionResidencia") != null) i.DireccionResidencia = Convert.ToInt32(xe.Attribute("DireccionResidencia").Value);
                if (xe.Attribute("Empleador") != null) i.Empleador = Convert.ToInt32(xe.Attribute("Empleador").Value);
                if (xe.Attribute("Telefono") != null) i.Telefono = xe.Attribute("Telefono").Value;
                if (xe.Attribute("TelefonoMovil") != null) i.TelefonoMovil = xe.Attribute("TelefonoMovil").Value;
                if (xe.Attribute("PaisNombre") != null) i.PaisNombre = xe.Attribute("PaisNombre").Value;
                if (xe.Attribute("LocalidadNombre") != null) i.LocalidadNombre = xe.Attribute("LocalidadNombre").Value;
                if (xe.Attribute("PaisID") != null) i.PaisID = Convert.ToInt32(xe.Attribute("PaisID").Value);
                if (xe.Attribute("LocalidadID") != null) i.LocalidadID = Convert.ToInt32(xe.Attribute("LocalidadID").Value);
                if (xe.Attribute("Calle") != null) i.Calle = xe.Attribute("Calle").Value;
                if (xe.Attribute("DirNumero") != null) i.DirNumero = Convert.ToInt32(xe.Attribute("DirNumero").Value);
                if (xe.Attribute("Piso") != null) i.Piso = xe.Attribute("Piso").Value;
                if (xe.Attribute("Departamento") != null) i.Departamento = xe.Attribute("Departamento").Value;
                if (xe.Attribute("CodPostal") != null) i.CodPostal = xe.Attribute("CodPostal").Value;
                if (xe.Attribute("CocheNombre") != null) i.CocheNombre = xe.Attribute("CocheNombre").Value;
                if (xe.Attribute("CocheId") != null) i.CocheId = Convert.ToInt32(xe.Attribute("CocheId").Value);
                if (xe.Attribute("EmpresaNombre") != null) i.EmpresaNombre = xe.Attribute("EmpresaNombre").Value;

                res.Add(i);

                if (xe.Attribute("Legajo") != null)
                    Legajos += "," + xe.Attribute("Legajo").Value;
            }

            List<resultInsert> result = new List<resultInsert>();

            using (var db = new ErsaContext())
            {
                System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;

                string UN = "";
                if (Seguridad.IdUnidadesNegociosAsignadas.Contains(5))
                    UN += ",5";
                if (Seguridad.IdUnidadesNegociosAsignadas.Contains(50))
                    UN += ",50";
                if (Seguridad.IdUnidadesNegociosAsignadas.Contains(29))
                    UN += ",29";

                string cmdstr = "SELECT " +
                                "Seleccionado = 0, " +
                                "parametros_ope = 0, " +
                                "id = 0, " +
                                "legajo = LaboralLegajo, " +
                                "categoria = CASE WHEN Id_Jerarquia = 1 THEN 0 " +
                                "                 WHEN Id_Jerarquia = 5 THEN 1 " +
                                "                 WHEN Id_Jerarquia = 7 THEN 0 " +
                                "                 ELSE 2 END, " +
                                "email = '', " +
                                "apellido = Apellido, " +
                                "nombre = Nombre, " +
                                "estado = 0, " +
                                "docNro = NroDoc, " +
                                "docTipo = 1, " +
                                "bus = '', " +
                                "gremioID = 1, " +
                                "tel = Telefono, " +
                                "telMovil = '', " +
                                "empleador = CASE WHEN Id_Empresa = 12 THEN 1 " +
                                "                 WHEN Id_Empresa = 13 THEN 2 " +
                                "                 WHEN Id_Empresa = 1  THEN 3 " +
                                "                 WHEN Id_Empresa = 3  THEN 3 " +
                                "                 WHEN Id_Empresa = 10 THEN 4 END, " +
                                "fIncor = FechaAlta " +
                                "FROM Personal " +
                                "WHERE UserDel IS NULL AND " +
                                "Id_Jerarquia IN (1, 5, 7) AND " +
                                "LaboralId_UnidadNegocio IN (" + UN.Substring(1) + ") AND " +
                                "LaboralLegajo NOT IN (" + Legajos.Substring(1) + ")";

                System.Data.SqlClient.SqlCommand cmdReport = new System.Data.SqlClient.SqlCommand(cmdstr, sqlConn);

                using (cmdReport)
                {
                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = System.Data.CommandType.Text;
                    if (cmdReport.Connection.State == System.Data.ConnectionState.Closed) cmdReport.Connection.Open();
                    using (System.Data.IDataReader dr = cmdReport.ExecuteReader())
                        while (dr.Read())
                            result.Add(Load(dr));
                }
            }
            return result;

        }

        private static resultInsert Load(System.Data.IDataRecord dr)
        {
            resultInsert o = new resultInsert();

            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (!dr.IsDBNull(i))
                {
                    switch (dr.GetName(i))
                    {
                        case "Seleccionado": o.Seleccionado = Convert.ToBoolean(dr.GetInt32(i)); break;
                        case "parametros_ope": o.parametros_ope = dr.GetInt32(i); break;
                        case "id": o.id = dr.GetInt32(i); break;
                        case "legajo": o.legajo = dr.GetInt32(i); break;
                        case "categoria": o.categoria = dr.GetInt32(i); break;
                        case "email": o.email = dr.GetString(i); break;
                        case "apellido": o.apellido = dr.GetString(i); break;
                        case "nombre": o.nombre = dr.GetString(i); break;
                        case "estado": o.estado = dr.GetInt32(i); break;
                        case "docNro": o.docNro = dr.GetInt32(i); break;
                        case "docTipo": o.docTipo = dr.GetInt32(i); break;
                        case "bus": o.bus = dr.GetString(i); break;
                        case "gremioID": o.gremioID = dr.GetInt32(i); break;
                        case "tel": o.tel = dr.GetString(i); break;
                        case "telMovil": o.telMovil = dr.GetString(i); break;
                        case "empleador": o.empleador = dr.GetInt32(i); break;
                    }
                }
            }
            return o;
        }

        public static void InsertPersonal(resultInsert p)
        {
            Token.TokenSoapClient t = new Token.TokenSoapClient();
            Tripulante.TripulanteSoapClient x = new Tripulante.TripulanteSoapClient();

            string token = XElement.Parse(t.GetToken("AABBBEAALJACAZCGA", "ERSA")).FirstAttribute.Value;

            string parametro = string.Format("<parametros _oper=\"0\" id=\"\" legajo=\"{0}\" categoria=\"{1}\" email=\"{2}\" apellido =\"{3}\" nombre =\"{4}\" estado =\"{5}\" docNro =\"{6}\" docTipo =\"{7}\" bus =\"\" gremioID =\"{8}\" tel =\"{9}\" telMovil =\"{10}\" empleador =\"{11}\" fIncor =\"\" ><rows></rows></parametros>",
                                         p.legajo,
                                         p.categoria,
                                         p.email,
                                         p.apellido,
                                         p.nombre,
                                         p.estado,
                                         p.docNro,
                                         p.docTipo,
                                         p.gremioID,
                                         p.tel,
                                         p.telMovil,
                                         p.empleador
                                         );

            string r = x.ABMTripulante(token, parametro);

            XDocument doc = XDocument.Parse(r);

            XNamespace rootNs = doc.Root.Name.Namespace;

            foreach (var xe in doc.Elements(rootNs + "Tripulante"))
                if (xe.Attribute("Id") != null)
                {
                    using (var db = new ErsaContext())
                    {
                        int IdPersonal = Convert.ToInt32(xe.Attribute("Id").Value);
                        if (IdPersonal > 0)
                        {
                            int Legajo = db.Personal.Where(tt => tt.UserDel == null && tt.LaboralLegajo == p.legajo).Select(tt => tt.Id).FirstOrDefault();
                            Personal pe = new Personal() { Id = Legajo };
                            db.Personal.Attach(pe);
                            db.Entry(pe).Reload();
                            //**************
                            pe.ApellidoCasada = xe.Attribute("Id").Value.ToString();
                            //**************

                            db.SaveChanges();
                        }
                    }
                }
        }

        public static List<resultViajes> GetHabilitados(DateTime Fecha)
        {
            Token.TokenSoapClient t = new Token.TokenSoapClient();
            Viajes.ViajeSoapClient x = new Viajes.ViajeSoapClient();

            string token = XElement.Parse(t.GetToken("AABBBEAALJACAZCGA", "ERSA")).FirstAttribute.Value;

            string F = Fecha.Day.ToString("00") + "/" + Fecha.Month.ToString("00") + "/" + Fecha.Year.ToString("0000");

            string r = x.GetHabilitados(token, F + " 00:00:00", F + " 23:59:59");

            XDocument doc = XDocument.Parse(r);
            List<resultViajes> res = new List<resultViajes>();

            foreach (var xe in doc.Element("viajes").Elements("viaje"))
            {
                resultViajes i = new resultViajes();

                if (xe.Attribute("ViajeID") != null) i.ViajeID = Convert.ToInt32(xe.Attribute("ViajeID").Value);
                if (xe.Attribute("TipoViaje") != null) i.TipoViaje = xe.Attribute("TipoViaje").Value;
                if (xe.Attribute("TerminalOrigenID") != null) i.TerminalOrigenID = Convert.ToInt32(xe.Attribute("TerminalOrigenID").Value);
                if (xe.Attribute("TerminalDestinoID") != null) i.TerminalDestinoID = Convert.ToInt32(xe.Attribute("TerminalDestinoID").Value);
                if (xe.Attribute("TerminalOrigenNombre") != null) i.TerminalOrigenNombre = xe.Attribute("TerminalOrigenNombre").Value;
                if (xe.Attribute("TerminalDestinoNombre") != null) i.TerminalDestinoNombre = xe.Attribute("TerminalDestinoNombre").Value;
                if (xe.Attribute("LocalidadOrigenID") != null) i.LocalidadOrigenID = Convert.ToInt32(xe.Attribute("LocalidadOrigenID").Value);
                if (xe.Attribute("LocalidadDestinoID") != null) i.LocalidadDestinoID = Convert.ToInt32(xe.Attribute("LocalidadDestinoID").Value);
                if (xe.Attribute("LocalidadOrigenNombre") != null) i.LocalidadOrigenNombre = xe.Attribute("LocalidadOrigenNombre").Value;
                if (xe.Attribute("LocalidadDestinoNombre") != null) i.LocalidadDestinoNombre = xe.Attribute("LocalidadDestinoNombre").Value;
                if (xe.Attribute("EmpresaID") != null)
                {
                    switch (Convert.ToInt32(xe.Attribute("EmpresaID").Value))
                    {
                        case 1: i.EmpresaID = 12; break;
                        case 2: i.EmpresaID = 13; break;
                        case 3: i.EmpresaID = 1; break;
                        case 4: i.EmpresaID = 10; break;
                    }
                }
                if (xe.Attribute("EmpresaCodigo") != null) i.EmpresaCodigo = xe.Attribute("EmpresaCodigo").Value;
                if (xe.Attribute("ServicioID") != null) i.ServicioID = Convert.ToInt32(xe.Attribute("ServicioID").Value);
                if (xe.Attribute("ServicioCodigo") != null) i.ServicioCodigo = xe.Attribute("ServicioCodigo").Value;
                if (xe.Attribute("CategoriaNombre") != null) i.CategoriaNombre = xe.Attribute("CategoriaNombre").Value;
                if (xe.Attribute("CategoriaID") != null) i.CategoriaID = Convert.ToInt32(xe.Attribute("CategoriaID").Value);
                if (xe.Attribute("TipoLinea") != null) i.TipoLinea = xe.Attribute("TipoLinea").Value;
                if (xe.Attribute("LongitudRecorrido") != null) i.LongitudRecorrido = Convert.ToDecimal(xe.Attribute("LongitudRecorrido").Value);
                if (xe.Attribute("FechaPartida") != null) i.FechaPartida = Convert.ToDateTime(xe.Attribute("FechaPartida").Value);
                if (xe.Attribute("FechaArribo") != null) i.FechaArribo = Convert.ToDateTime(xe.Attribute("FechaArribo").Value);
                if (xe.Attribute("Sentido") != null) i.Sentido = xe.Attribute("Sentido").Value;
                if (xe.Attribute("LongitudTotal") != null) i.LongitudTotal = Convert.ToDecimal(xe.Attribute("LongitudTotal").Value);

                res.Add(i);
            }

            List<CodigosServiciosFechasCodigos> ListadoServicios = new List<CodigosServiciosFechasCodigos>();

            using (var db = new ErsaContext())
            {
                ListadoServicios = (from csf in db.CodigosServiciosFechas
                                    join v in db.CodigosServiciosVueltas on csf.Id_CodigoServicioVuelta equals v.Id into listCSV
                                    from csv in listCSV
                                    join s in db.CodigosServicios on csv.Id_CodigoServicio equals s.Id into listCS
                                    from cs in listCS
                                    join tipos in db.TipoServicios on cs.Id_TipoServicio equals tipos.Id into listTS
                                    from ts in listTS
                                    join ram in db.Ramales on ts.Id_Ramal equals ram.Id into listR
                                    from ra in listR
                                    join lin in db.Lineas on ra.Id_Linea equals lin.Id into listLin
                                    from l in listLin
                                    join co in db.Coches on csf.Id_Coche equals co.Id into listCo
                                    from c in listCo.DefaultIfEmpty()
                                    join per1 in db.Personal on csf.Id_Personal1 equals per1.Id into listP1
                                    from p1 in listP1.DefaultIfEmpty()
                                    join per2 in db.Personal on csf.Id_Personal2 equals per2.Id into listP2
                                    from p2 in listP2.DefaultIfEmpty()
                                    join per3 in db.Personal on csf.Id_Personal3 equals per3.Id into listP3
                                    from p3 in listP3.DefaultIfEmpty()
                                    where csf.Fecha == Fecha
                                       && Seguridad.IdUnidadesNegociosAsignadas.Contains(l.Id_UnidadNegocio)
                                       && csf.UserDel == null
                                    select new CodigosServiciosFechasCodigos
                                    {
                                        Fecha = csf.Fecha,
                                        CodigoExterno = csv.CodigoExterno,
                                        Id_Coche = c.Id_Externo,
                                        Id_CodigoServicioVuelta = csf.Id_CodigoServicioVuelta,
                                        Id_Empresa = l.Id_Empresa,
                                        Id_Personal1 = p1.ApellidoCasada,
                                        Id_Personal2 = p2.ApellidoCasada,
                                        Id_Personal3 = p3.ApellidoCasada,
                                        Interno = c.Interno,
                                        LegajoPersonal1 = p1.LaboralLegajo.ToString() + "-" + p1.Apellido + " " + p1.Nombre,
                                        LegajoPersonal2 = p2.LaboralLegajo.ToString() + "-" + p2.Apellido + " " + p2.Nombre,
                                        LegajoPersonal3 = p3.LaboralLegajo.ToString() + "-" + p3.Apellido + " " + p3.Nombre,
                                        Id_TerminalSube = csv.IdTerminalSube,
                                        Id_TerminalBaja = csv.IdTerminalBaja,
                                        //agregar si descuenta un dia, osea que pertenece al dia anterior
                                        ExtensionDiaAnterior = csv.ExtensionDiaAnterior
                                    }).ToList();
            }

            List<resultViajes> res2 = new List<resultViajes>();
            List<CodigosServiciosFechasCodigos> listCsfc = new List<CodigosServiciosFechasCodigos>();

            foreach (resultViajes rv in res.Where(tt => Seguridad.IdEmpresasAsignadas.Contains(tt.EmpresaID)))
            {
                int i = 0;
                foreach (CodigosServiciosFechasCodigos csfc in ListadoServicios.Where(tt => tt.CodigoExterno == rv.ServicioCodigo))
                {
                    //si pertenece a un dia anterior, llenar otro CodigosServiciosFechasCodigos csfc2
                    //sino
                    if (csfc.ExtensionDiaAnterior == true)
                        listCsfc.Add(csfc);
                    else
                    {
                        if (i == 0)
                        {
                            rv.Id_CodigoServicioVuelta = csfc.Id_CodigoServicioVuelta;
                            rv.Id_Coche = csfc.Id_Coche;
                            rv.Id_Personal1 = csfc.Id_Personal1;
                            rv.Id_Personal2 = csfc.Id_Personal2;
                            rv.Id_Personal3 = csfc.Id_Personal3;
                            rv.Interno = csfc.Interno;
                            rv.LegajoPersonal1 = csfc.LegajoPersonal1;
                            rv.LegajoPersonal2 = csfc.LegajoPersonal2;
                            rv.LegajoPersonal3 = csfc.LegajoPersonal3;
                            rv.Id_TerminalBaja = csfc.Id_TerminalBaja;
                            rv.Id_TerminalSube = csfc.Id_TerminalSube;
                            i += 1;
                        }
                        else
                        {
                            resultViajes v = new resultViajes()
                            {
                                CategoriaID = rv.CategoriaID,
                                CategoriaNombre = rv.CategoriaNombre,
                                EmpresaCodigo = rv.EmpresaCodigo,
                                EmpresaID = rv.EmpresaID,
                                FechaArribo = rv.FechaArribo,
                                FechaPartida = rv.FechaPartida,
                                Id_CodigoServicioVuelta = csfc.Id_CodigoServicioVuelta,
                                LocalidadDestinoID = rv.LocalidadDestinoID,
                                LocalidadDestinoNombre = rv.LocalidadDestinoNombre,
                                LocalidadOrigenID = rv.LocalidadOrigenID,
                                LocalidadOrigenNombre = rv.LocalidadOrigenNombre,
                                LongitudRecorrido = rv.LongitudRecorrido,
                                LongitudTotal = rv.LongitudTotal,
                                Seleccionado = false,
                                Sentido = rv.Sentido,
                                ServicioCodigo = rv.ServicioCodigo,
                                ServicioID = rv.ServicioID,
                                TerminalDestinoID = rv.TerminalDestinoID,
                                TerminalDestinoNombre = rv.TerminalDestinoNombre,
                                TerminalOrigenID = rv.TerminalOrigenID,
                                TerminalOrigenNombre = rv.TerminalOrigenNombre,
                                TipoLinea = rv.TipoLinea,
                                TipoViaje = rv.TipoViaje,
                                ViajeID = rv.ViajeID,
                                Id_Coche = csfc.Id_Coche,
                                Id_Personal1 = csfc.Id_Personal1,
                                Id_Personal2 = csfc.Id_Personal2,
                                Id_Personal3 = csfc.Id_Personal3,
                                Interno = csfc.Interno,
                                LegajoPersonal1 = csfc.LegajoPersonal1,
                                LegajoPersonal2 = csfc.LegajoPersonal2,
                                LegajoPersonal3 = csfc.LegajoPersonal3,
                                Id_TerminalBaja = csfc.Id_TerminalBaja,
                                Id_TerminalSube = csfc.Id_TerminalSube
                            };

                            res2.Add(v);
                        }
                    }
                }
            }

            res.AddRange(res2);

            //si CodigosServiciosFechasCodigos csfc2 > 0
            //hacer todo devuelta para un dia atras y solamente agregar los del dia anterior que estan en CodigosServiciosFechasCodigos csfc2

            if (listCsfc.Count > 0)
            {
                token = XElement.Parse(t.GetToken("AABBBEAALJACAZCGA", "ERSA")).FirstAttribute.Value;

                Fecha = Fecha.AddDays(-1);
                F = Fecha.Day.ToString("00") + "/" + Fecha.Month.ToString("00") + "/" + Fecha.Year.ToString("0000");

                r = x.GetHabilitados(token, F + " 00:00:00", F + " 23:59:59");

                doc = XDocument.Parse(r);
                List<resultViajes> res3 = new List<resultViajes>();

                foreach (var xe in doc.Element("viajes").Elements("viaje"))
                {
                    resultViajes i = new resultViajes();

                    if (xe.Attribute("ViajeID") != null) i.ViajeID = Convert.ToInt32(xe.Attribute("ViajeID").Value);
                    if (xe.Attribute("TipoViaje") != null) i.TipoViaje = xe.Attribute("TipoViaje").Value;
                    if (xe.Attribute("TerminalOrigenID") != null) i.TerminalOrigenID = Convert.ToInt32(xe.Attribute("TerminalOrigenID").Value);
                    if (xe.Attribute("TerminalDestinoID") != null) i.TerminalDestinoID = Convert.ToInt32(xe.Attribute("TerminalDestinoID").Value);
                    if (xe.Attribute("TerminalOrigenNombre") != null) i.TerminalOrigenNombre = xe.Attribute("TerminalOrigenNombre").Value;
                    if (xe.Attribute("TerminalDestinoNombre") != null) i.TerminalDestinoNombre = xe.Attribute("TerminalDestinoNombre").Value;
                    if (xe.Attribute("LocalidadOrigenID") != null) i.LocalidadOrigenID = Convert.ToInt32(xe.Attribute("LocalidadOrigenID").Value);
                    if (xe.Attribute("LocalidadDestinoID") != null) i.LocalidadDestinoID = Convert.ToInt32(xe.Attribute("LocalidadDestinoID").Value);
                    if (xe.Attribute("LocalidadOrigenNombre") != null) i.LocalidadOrigenNombre = xe.Attribute("LocalidadOrigenNombre").Value;
                    if (xe.Attribute("LocalidadDestinoNombre") != null) i.LocalidadDestinoNombre = xe.Attribute("LocalidadDestinoNombre").Value;
                    if (xe.Attribute("EmpresaID") != null)
                    {
                        switch (Convert.ToInt32(xe.Attribute("EmpresaID").Value))
                        {
                            case 1: i.EmpresaID = 12; break;
                            case 2: i.EmpresaID = 13; break;
                            case 3: i.EmpresaID = 1; break;
                            case 4: i.EmpresaID = 10; break;
                        }
                    }
                    if (xe.Attribute("EmpresaCodigo") != null) i.EmpresaCodigo = xe.Attribute("EmpresaCodigo").Value;
                    if (xe.Attribute("ServicioID") != null) i.ServicioID = Convert.ToInt32(xe.Attribute("ServicioID").Value);
                    if (xe.Attribute("ServicioCodigo") != null) i.ServicioCodigo = xe.Attribute("ServicioCodigo").Value;
                    if (xe.Attribute("CategoriaNombre") != null) i.CategoriaNombre = xe.Attribute("CategoriaNombre").Value;
                    if (xe.Attribute("CategoriaID") != null) i.CategoriaID = Convert.ToInt32(xe.Attribute("CategoriaID").Value);
                    if (xe.Attribute("TipoLinea") != null) i.TipoLinea = xe.Attribute("TipoLinea").Value;
                    if (xe.Attribute("LongitudRecorrido") != null) i.LongitudRecorrido = Convert.ToDecimal(xe.Attribute("LongitudRecorrido").Value);
                    if (xe.Attribute("FechaPartida") != null) i.FechaPartida = Convert.ToDateTime(xe.Attribute("FechaPartida").Value);
                    if (xe.Attribute("FechaArribo") != null) i.FechaArribo = Convert.ToDateTime(xe.Attribute("FechaArribo").Value);
                    if (xe.Attribute("Sentido") != null) i.Sentido = xe.Attribute("Sentido").Value;
                    if (xe.Attribute("LongitudTotal") != null) i.LongitudTotal = Convert.ToDecimal(xe.Attribute("LongitudTotal").Value);

                    res3.Add(i);
                }

                foreach (CodigosServiciosFechasCodigos csfc in listCsfc)
                {
                    resultViajes rv = new resultViajes();
                    foreach (resultViajes rv2 in res3.Where(tt => Seguridad.IdEmpresasAsignadas.Contains(tt.EmpresaID) && tt.ServicioCodigo == csfc.CodigoExterno))
                    {
                        rv = rv2;
                    }

                    if (rv.ServicioCodigo != null)
                    {
                        resultViajes v = new resultViajes()
                        {
                            CategoriaID = rv.CategoriaID,
                            CategoriaNombre = rv.CategoriaNombre,
                            EmpresaCodigo = rv.EmpresaCodigo,
                            EmpresaID = rv.EmpresaID,
                            FechaArribo = rv.FechaArribo,
                            FechaPartida = rv.FechaPartida,
                            Id_CodigoServicioVuelta = csfc.Id_CodigoServicioVuelta,
                            LocalidadDestinoID = rv.LocalidadDestinoID,
                            LocalidadDestinoNombre = rv.LocalidadDestinoNombre,
                            LocalidadOrigenID = rv.LocalidadOrigenID,
                            LocalidadOrigenNombre = rv.LocalidadOrigenNombre,
                            LongitudRecorrido = rv.LongitudRecorrido,
                            LongitudTotal = rv.LongitudTotal,
                            Seleccionado = false,
                            Sentido = rv.Sentido,
                            ServicioCodigo = rv.ServicioCodigo,
                            ServicioID = rv.ServicioID,
                            TerminalDestinoID = rv.TerminalDestinoID,
                            TerminalDestinoNombre = rv.TerminalDestinoNombre,
                            TerminalOrigenID = rv.TerminalOrigenID,
                            TerminalOrigenNombre = rv.TerminalOrigenNombre,
                            TipoLinea = rv.TipoLinea,
                            TipoViaje = rv.TipoViaje,
                            ViajeID = rv.ViajeID,
                            Id_Coche = csfc.Id_Coche,
                            Id_Personal1 = csfc.Id_Personal1,
                            Id_Personal2 = csfc.Id_Personal2,
                            Id_Personal3 = csfc.Id_Personal3,
                            Interno = csfc.Interno,
                            LegajoPersonal1 = csfc.LegajoPersonal1,
                            LegajoPersonal2 = csfc.LegajoPersonal2,
                            LegajoPersonal3 = csfc.LegajoPersonal3,
                            Id_TerminalBaja = csfc.Id_TerminalBaja,
                            Id_TerminalSube = csfc.Id_TerminalSube
                        };

                        res.Add(v);
                    }
                }
            }

            return res;
        }

        public static string Enturnar(resultViajes p)
        {
            Token.TokenSoapClient t = new Token.TokenSoapClient();
            Viajes.ViajeSoapClient x = new Viajes.ViajeSoapClient();

            string token = XElement.Parse(t.GetToken("AABBBEAALJACAZCGA", "ERSA")).FirstAttribute.Value;

            string resp = "";
            string respuesta = "";

            if (p.Id_Personal1 == "")
                Sistema.Mensaje("El personal " + p.LegajoPersonal1 + " no se encuentra en la base de Sisorg");
            else
            {
                if (Convert.ToInt32(p.Id_Personal1) > 0)
                {
                    resp = x.AsignarTripulante(token, p.ViajeID, Convert.ToInt32(p.Id_TerminalSube), Convert.ToInt32(p.Id_TerminalBaja), Convert.ToInt32(p.Id_Personal1), 1);
                    respuesta += "Personal 1 - " + (XDocument.Parse(resp)).Element("rows").Elements("estado").FirstOrDefault().Value + " // ";
                }
            }
            if (p.Id_Personal2 == "")
                Sistema.Mensaje("El personal " + p.LegajoPersonal2 + " no se encuentra en la base de Sisorg");
            else
            {
                if (Convert.ToInt32(p.Id_Personal2) > 0)
                {
                    resp = x.AsignarTripulante(token, p.ViajeID, Convert.ToInt32(p.Id_TerminalSube), Convert.ToInt32(p.Id_TerminalBaja), Convert.ToInt32(p.Id_Personal2), 1);
                    respuesta += "Personal 2 - " + (XDocument.Parse(resp)).Element("rows").Elements("estado").FirstOrDefault().Value + " // ";
                }
            }
            if (p.Id_Personal3 == "")
                Sistema.Mensaje("El personal " + p.LegajoPersonal3 + " no se encuentra en la base de Sisorg");
            else
            {
                if (Convert.ToInt32(p.Id_Personal3) > 0)
                {
                    resp = x.AsignarTripulante(token, p.ViajeID, Convert.ToInt32(p.Id_TerminalSube), Convert.ToInt32(p.Id_TerminalBaja), Convert.ToInt32(p.Id_Personal3), 1);
                    respuesta += "Personal 3 - " + (XDocument.Parse(resp)).Element("rows").Elements("estado").FirstOrDefault().Value + " // ";
                }
            }
            if (p.Id_Coche != null)
            //Sistema.Mensaje("El coche " + p.Id_Coche + " no se encuentra en la base de Sisorg");
            //else
            {
                if (Convert.ToInt32(p.Id_Coche) > 0)
                {
                    resp = x.AsignarVehiculo(token, p.ViajeID, p.TerminalOrigenID, p.TerminalDestinoID, Convert.ToInt32(p.Id_Coche), 1, 0);
                    respuesta += "Interno - " + (XDocument.Parse(resp)).Element("rows").Elements("estado").FirstOrDefault().Value;
                }
            }
            return respuesta;
        }

        public static void BuscarTerminales()
        {
            Token.TokenSoapClient t = new Token.TokenSoapClient();
            Terminales.TerminalSoapClient x = new Terminales.TerminalSoapClient();

            string token = XElement.Parse(t.GetToken("AABBBEAALJACAZCGA", "ERSA")).FirstAttribute.Value;

            string parametro = "<parametros codigo=\"\" nombre=\"\" localidad=\"-1\" forABM=\"1\" usuario=\"1\" />";

            string r = x.GetTerminal(token, parametro);

            XDocument doc = XDocument.Parse(r);

            XNamespace rootNs = doc.Root.Name.Namespace;

            foreach (var xe in doc.Element(rootNs + "rows").Elements("Terminal"))
            {
                string cmdstr = "INSERT INTO TERMINALES (Id,Nombre,Localidad) VALUES (" + xe.Attribute("Id").Value + ",'" + xe.Attribute("Nombre").Value + "','" + xe.Attribute("LocalidadNombre").Value + "'" + ")";

                using (ErsaContext db = new ErsaContext())
                {
                    System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                    System.Data.SqlClient.SqlCommand cmdReport = new System.Data.SqlClient.SqlCommand(cmdstr, sqlConn);

                    using (cmdReport)
                    {
                        cmdReport.CommandTimeout = 0;

                        cmdReport.CommandType = System.Data.CommandType.Text;
                        if (cmdReport.Connection.State == System.Data.ConnectionState.Closed) cmdReport.Connection.Open();
                        try
                        {
                            cmdReport.ExecuteNonQuery();
                        }
                        catch (Exception) { }
                    }
                }
            }
        }


        public class result
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int TipoDocumento { get; set; }
            public string Documento { get; set; }
            public string Legajo { get; set; }
            public int Categoria { get; set; }
            public int Edad { get; set; }
            public int Estado { get; set; }
            public DateTime FechaIncorporacion { get; set; }
            public string NroCarnetProv { get; set; }
            public string CarnetProvDesde { get; set; }
            public string CarnetProvHasta { get; set; }
            public string NroCarnetNac { get; set; }
            public string CarnetNacDesde { get; set; }
            public string CarnetNacHasta { get; set; }
            public int GremioID { get; set; }
            public string Email { get; set; }
            public int DireccionResidencia { get; set; }
            public int Empleador { get; set; }
            public string Telefono { get; set; }
            public string TelefonoMovil { get; set; }
            public string PaisNombre { get; set; }
            public string LocalidadNombre { get; set; }
            public int PaisID { get; set; }
            public int LocalidadID { get; set; }
            public string Calle { get; set; }
            public int DirNumero { get; set; }
            public string Piso { get; set; }
            public string Departamento { get; set; }
            public string CodPostal { get; set; }
            public string CocheNombre { get; set; }
            public int CocheId { get; set; }
            public string EmpresaNombre { get; set; }
        }

        public class resultInsert
        {
            public bool Seleccionado { get; set; }
            public int parametros_ope { get; set; }
            public int id { get; set; }
            public int legajo { get; set; }
            public int categoria { get; set; }
            public string email { get; set; }
            public string apellido { get; set; }
            public string nombre { get; set; }
            public int estado { get; set; }
            public int docNro { get; set; }
            public int docTipo { get; set; }
            public string bus { get; set; }
            public int gremioID { get; set; }
            public string tel { get; set; }
            public string telMovil { get; set; }
            public int empleador { get; set; }
            public string Empresa
            {
                get
                {
                    if (empleador == 1) return "EMPRESA ROMERO SATICAF";
                    if (empleador == 2) return "EMPRESA ITATI S.R.L.";
                    if (empleador == 3) return "ERSA URBANO S.A.";
                    if (empleador == 4) return "EXPRESO SINGER";
                    else return "";
                }
            }
            public string Jerarquia
            {
                get
                {
                    if (categoria == 0) return "CONDUCTOR";
                    if (categoria == 1) return "AUXILIAR";
                    if (categoria == 2) return "VER";
                    else return "";
                }
            }
        }

        public class resultViajes
        {
            public bool Seleccionado { get; set; }
            public int ViajeID { get; set; }
            public string TipoViaje { get; set; }
            public int TerminalOrigenID { get; set; }
            public int TerminalDestinoID { get; set; }
            public string TerminalOrigenNombre { get; set; }
            public string TerminalDestinoNombre { get; set; }
            public int LocalidadOrigenID { get; set; }
            public int LocalidadDestinoID { get; set; }
            public string LocalidadOrigenNombre { get; set; }
            public string LocalidadDestinoNombre { get; set; }
            public int EmpresaID { get; set; }
            public string EmpresaCodigo { get; set; }
            public int ServicioID { get; set; }
            public string ServicioCodigo { get; set; }
            public string CategoriaNombre { get; set; }
            public int CategoriaID { get; set; }
            public string TipoLinea { get; set; }
            public decimal LongitudRecorrido { get; set; }
            public DateTime FechaPartida { get; set; }
            public DateTime FechaArribo { get; set; }
            public string Sentido { get; set; }
            public decimal LongitudTotal { get; set; }
            public int? Id_CodigoServicioVuelta { get; set; }
            public string Id_Coche { get; set; }
            public string Id_Personal1 { get; set; }
            public string Id_Personal2 { get; set; }
            public string Id_Personal3 { get; set; }
            public int? Interno { get; set; }
            public string LegajoPersonal1 { get; set; }
            public string LegajoPersonal2 { get; set; }
            public string LegajoPersonal3 { get; set; }
            public int? Id_TerminalSube { get; set; }
            public int? Id_TerminalBaja { get; set; }
            public string Resultado { get; set; }
        }

        public class CodigosServiciosFechasCodigos
        {
            public DateTime Fecha { get; set; }
            public string CodigoExterno { get; set; }
            public int Id_CodigoServicioVuelta { get; set; }
            public string Id_Coche { get; set; }
            public string Id_Personal1 { get; set; }
            public string Id_Personal2 { get; set; }
            public string Id_Personal3 { get; set; }
            public int? Interno { get; set; }
            public string LegajoPersonal1 { get; set; }
            public string LegajoPersonal2 { get; set; }
            public string LegajoPersonal3 { get; set; }
            public int? Id_Empresa { get; set; }
            public int? Id_TerminalSube { get; set; }
            public int? Id_TerminalBaja { get; set; }
            public bool? ExtensionDiaAnterior { get; set; }
        }

    }
}
