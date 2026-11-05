namespace VENET_Informes_BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VENET_Comun;
    using VENET_DataEntity;

    public class ReporteLibretaManager
    {
        public int Id_Empresa { get; set; }
        //public int Id_Linea { get; set; }
        public Enums.Meses Mes { get; set; }
        public int Año { get; set; }
        public int LegajoDesde { get; set; }
        public int LegajoHasta { get; set; }

        public ReporteLibretaManager()
        {

        }

        public List<DatosReporte> Imprimir()
        {
            using (var db = new GeneralContext())
            {
                List<DatosReporte> ListaReporte = new List<DatosReporte>();
                List<Legajos> ListaLegajos = new List<Legajos>();
                List<DiasReporte> ListaDiasLegajos = new List<DiasReporte>();

                int IdEmpresa = Id_Empresa;

                //terminar case de empresas sit - nexus
                switch (Id_Empresa)
                {
                    case 4: IdEmpresa = 2; break;
                    case 5: IdEmpresa = 3; break;
                    case 6: IdEmpresa = 4; break;
                    case 3: IdEmpresa = 5; break;
                    case 8: IdEmpresa = 8; break;
                    case 2: IdEmpresa = 9; break;
                    case 9: IdEmpresa = 10; break;
                    case 7: IdEmpresa = 20; break;
                    case 12: IdEmpresa = 6; break;
                    case 13: IdEmpresa = 17; break;
                    case 10: IdEmpresa = 24; break;
                    case 20: IdEmpresa = 16; break;
                }


                string sqlString = "SELECT Legajo, " +
                                   "       Empleado = RTRIM(LTRIM(apellido)) + ', ' + RTRIM(LTRIM(Nombre)) + ' ' + ISNULL(RTRIM(LTRIM(Segundo_Nombre)), ''), " +
                                   "       Ingreso = Fecha_Alta, " +
                                   "       Categoria, " +
                                   "       Cuil " +
                                   "FROM [192.168.1.22].[NexusHR].[dbo].[viewLegajos2] " +
                                   "WHERE Cod_Empresa = " + IdEmpresa +
                                   "  AND Estado = 'Acti' " +
                                   "  AND Legajo BETWEEN " + LegajoDesde + " AND " + LegajoHasta + " " +
                                   "ORDER BY Legajo";
                System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                System.Data.SqlClient.SqlCommand cmdReport = new System.Data.SqlClient.SqlCommand(sqlString, sqlConn);
                using (cmdReport)
                {
                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = System.Data.CommandType.Text;
                    if (cmdReport.Connection.State == System.Data.ConnectionState.Closed) cmdReport.Connection.Open();
                    using (System.Data.IDataReader dr = cmdReport.ExecuteReader())
                        while (dr.Read())
                            ListaLegajos.Add(Load(dr));
                }

                //Cargar listado Dias x legajo
                //DiasReporte
                var pr = Mes.ToString();
                DateTime FD = new DateTime(Año, 4, 01);
                DateTime FH = FD.AddMonths(1).AddDays(-1);

                //SE CREO VISTA viewDiasTrabajadosPorLegajo
                //falta permiso a nexus-test. pasar a produccion.
                sqlString = "SELECT Legajo,Dia,Franco,Entro,Diagr,Salio FROM [192.168.1.22].[TAW].[dbo].[DiasTrabajadosPorLegajo] WHERE dia BETWEEN '" + FD + "' AND '" + FH + "' AND Legajo BETWEEN " + LegajoDesde + " AND " + LegajoHasta;
                cmdReport = new System.Data.SqlClient.SqlCommand(sqlString, sqlConn);
                using (cmdReport)
                {
                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = System.Data.CommandType.Text;
                    if (cmdReport.Connection.State == System.Data.ConnectionState.Closed) cmdReport.Connection.Open();
                    using (System.Data.IDataReader dr = cmdReport.ExecuteReader())
                        while (dr.Read())
                            ListaDiasLegajos.Add(LoadDias(dr));
                }

                int i = LegajoDesde;
                DatosReporte r = new DatosReporte();
                r.Mes = Mes;
                r.Año = Año;

                //Lineas l = new Lineas() { Id = Id_Linea };
                //db.Entry(l).State = EntityState.Unchanged;
                //db.Entry(l).Reload();

                //r.Linea = l.Descripcion;
                //r.DireccionLinea = "";

                int x = 1;

                while (i <= LegajoHasta)
                {
                    //si el legajo no esta en la lista 
                    DiasReporte l = ListaDiasLegajos.Where(t => t.Legajo == i).FirstOrDefault();

                    i += 1;

                    if (l != null)
                    {
                        Legajos l2 = ListaLegajos.Where(t => t.Legajo == l.Legajo).FirstOrDefault();

                        if (l2 != null)
                        {
                            switch (x)
                            {
                                case 1:
                                    r.Legajo1 = l.Legajo.ToString() + " - " + l2.Cuit;
                                    r.Empleado1 = l2.Empleado;
                                    r.Ingreso1 = l2.Ingreso;
                                    r.Categoria1 = l2.Categoria;

                                    foreach (DiasReporte d in ListaDiasLegajos.Where(t => t.Legajo == l.Legajo))
                                        switch (d.Dia.Day)
                                        {
                                            case 1:
                                                r.L1Dia1 = d.Dia.Day;
                                                r.L1Franco1 = d.Franco;
                                                r.L1Entro1 = d.Entro;
                                                r.L1Diagr1 = d.Diagr;
                                                r.L1Salio1 = d.Salio;
                                                break;
                                            case 2:
                                                r.L1Dia2 = d.Dia.Day;
                                                r.L1Franco2 = d.Franco;
                                                r.L1Entro2 = d.Entro;
                                                r.L1Diagr2 = d.Diagr;
                                                r.L1Salio2 = d.Salio;
                                                break;
                                            case 3:
                                                r.L1Dia3 = d.Dia.Day;
                                                r.L1Franco3 = d.Franco;
                                                r.L1Entro3 = d.Entro;
                                                r.L1Diagr3 = d.Diagr;
                                                r.L1Salio3 = d.Salio;
                                                break;
                                            case 4:
                                                r.L1Dia4 = d.Dia.Day;
                                                r.L1Franco4 = d.Franco;
                                                r.L1Entro4 = d.Entro;
                                                r.L1Diagr4 = d.Diagr;
                                                r.L1Salio4 = d.Salio;
                                                break;
                                            case 5:
                                                r.L1Dia5 = d.Dia.Day;
                                                r.L1Franco5 = d.Franco;
                                                r.L1Entro5 = d.Entro;
                                                r.L1Diagr5 = d.Diagr;
                                                r.L1Salio5 = d.Salio;
                                                break;
                                            case 6:
                                                r.L1Dia6 = d.Dia.Day;
                                                r.L1Franco6 = d.Franco;
                                                r.L1Entro6 = d.Entro;
                                                r.L1Diagr6 = d.Diagr;
                                                r.L1Salio6 = d.Salio;
                                                break;
                                            case 7:
                                                r.L1Dia7 = d.Dia.Day;
                                                r.L1Franco7 = d.Franco;
                                                r.L1Entro7 = d.Entro;
                                                r.L1Diagr7 = d.Diagr;
                                                r.L1Salio7 = d.Salio;
                                                break;
                                            case 8:
                                                r.L1Dia8 = d.Dia.Day;
                                                r.L1Franco8 = d.Franco;
                                                r.L1Entro8 = d.Entro;
                                                r.L1Diagr8 = d.Diagr;
                                                r.L1Salio8 = d.Salio;
                                                break;
                                            case 9:
                                                r.L1Dia9 = d.Dia.Day;
                                                r.L1Franco9 = d.Franco;
                                                r.L1Entro9 = d.Entro;
                                                r.L1Diagr9 = d.Diagr;
                                                r.L1Salio9 = d.Salio;
                                                break;
                                            case 10:
                                                r.L1Dia10 = d.Dia.Day;
                                                r.L1Franco10 = d.Franco;
                                                r.L1Entro10 = d.Entro;
                                                r.L1Diagr10 = d.Diagr;
                                                r.L1Salio10 = d.Salio;
                                                break;
                                            case 11:
                                                r.L1Dia11 = d.Dia.Day;
                                                r.L1Franco11 = d.Franco;
                                                r.L1Entro11 = d.Entro;
                                                r.L1Diagr11 = d.Diagr;
                                                r.L1Salio11 = d.Salio;
                                                break;
                                            case 12:
                                                r.L1Dia12 = d.Dia.Day;
                                                r.L1Franco12 = d.Franco;
                                                r.L1Entro12 = d.Entro;
                                                r.L1Diagr12 = d.Diagr;
                                                r.L1Salio12 = d.Salio;
                                                break;
                                            case 13:
                                                r.L1Dia13 = d.Dia.Day;
                                                r.L1Franco13 = d.Franco;
                                                r.L1Entro13 = d.Entro;
                                                r.L1Diagr13 = d.Diagr;
                                                r.L1Salio13 = d.Salio;
                                                break;
                                            case 14:
                                                r.L1Dia14 = d.Dia.Day;
                                                r.L1Franco14 = d.Franco;
                                                r.L1Entro14 = d.Entro;
                                                r.L1Diagr14 = d.Diagr;
                                                r.L1Salio14 = d.Salio;
                                                break;
                                            case 15:
                                                r.L1Dia15 = d.Dia.Day;
                                                r.L1Franco15 = d.Franco;
                                                r.L1Entro15 = d.Entro;
                                                r.L1Diagr15 = d.Diagr;
                                                r.L1Salio15 = d.Salio;
                                                break;
                                            case 16:
                                                r.L1Dia16 = d.Dia.Day;
                                                r.L1Franco16 = d.Franco;
                                                r.L1Entro16 = d.Entro;
                                                r.L1Diagr16 = d.Diagr;
                                                r.L1Salio16 = d.Salio;
                                                break;
                                            case 17:
                                                r.L1Dia17 = d.Dia.Day;
                                                r.L1Franco17 = d.Franco;
                                                r.L1Entro17 = d.Entro;
                                                r.L1Diagr17 = d.Diagr;
                                                r.L1Salio17 = d.Salio;
                                                break;
                                            case 18:
                                                r.L1Dia18 = d.Dia.Day;
                                                r.L1Franco18 = d.Franco;
                                                r.L1Entro18 = d.Entro;
                                                r.L1Diagr18 = d.Diagr;
                                                r.L1Salio18 = d.Salio;
                                                break;
                                            case 19:
                                                r.L1Dia19 = d.Dia.Day;
                                                r.L1Franco19 = d.Franco;
                                                r.L1Entro19 = d.Entro;
                                                r.L1Diagr19 = d.Diagr;
                                                r.L1Salio19 = d.Salio;
                                                break;
                                            case 20:
                                                r.L1Dia20 = d.Dia.Day;
                                                r.L1Franco20 = d.Franco;
                                                r.L1Entro20 = d.Entro;
                                                r.L1Diagr20 = d.Diagr;
                                                r.L1Salio20 = d.Salio;
                                                break;
                                            case 21:
                                                r.L1Dia21 = d.Dia.Day;
                                                r.L1Franco21 = d.Franco;
                                                r.L1Entro21 = d.Entro;
                                                r.L1Diagr21 = d.Diagr;
                                                r.L1Salio21 = d.Salio;
                                                break;
                                            case 22:
                                                r.L1Dia22 = d.Dia.Day;
                                                r.L1Franco22 = d.Franco;
                                                r.L1Entro22 = d.Entro;
                                                r.L1Diagr22 = d.Diagr;
                                                r.L1Salio22 = d.Salio;
                                                break;
                                            case 23:
                                                r.L1Dia23 = d.Dia.Day;
                                                r.L1Franco23 = d.Franco;
                                                r.L1Entro23 = d.Entro;
                                                r.L1Diagr23 = d.Diagr;
                                                r.L1Salio23 = d.Salio;
                                                break;
                                            case 24:
                                                r.L1Dia24 = d.Dia.Day;
                                                r.L1Franco24 = d.Franco;
                                                r.L1Entro24 = d.Entro;
                                                r.L1Diagr24 = d.Diagr;
                                                r.L1Salio24 = d.Salio;
                                                break;
                                            case 25:
                                                r.L1Dia25 = d.Dia.Day;
                                                r.L1Franco25 = d.Franco;
                                                r.L1Entro25 = d.Entro;
                                                r.L1Diagr25 = d.Diagr;
                                                r.L1Salio25 = d.Salio;
                                                break;
                                            case 26:
                                                r.L1Dia26 = d.Dia.Day;
                                                r.L1Franco26 = d.Franco;
                                                r.L1Entro26 = d.Entro;
                                                r.L1Diagr26 = d.Diagr;
                                                r.L1Salio26 = d.Salio;
                                                break;
                                            case 27:
                                                r.L1Dia27 = d.Dia.Day;
                                                r.L1Franco27 = d.Franco;
                                                r.L1Entro27 = d.Entro;
                                                r.L1Diagr27 = d.Diagr;
                                                r.L1Salio27 = d.Salio;
                                                break;
                                            case 28:
                                                r.L1Dia28 = d.Dia.Day;
                                                r.L1Franco28 = d.Franco;
                                                r.L1Entro28 = d.Entro;
                                                r.L1Diagr28 = d.Diagr;
                                                r.L1Salio28 = d.Salio;
                                                break;
                                            case 29:
                                                r.L1Dia29 = d.Dia.Day;
                                                r.L1Franco29 = d.Franco;
                                                r.L1Entro29 = d.Entro;
                                                r.L1Diagr29 = d.Diagr;
                                                r.L1Salio29 = d.Salio;
                                                break;
                                            case 30:
                                                r.L1Dia30 = d.Dia.Day;
                                                r.L1Franco30 = d.Franco;
                                                r.L1Entro30 = d.Entro;
                                                r.L1Diagr30 = d.Diagr;
                                                r.L1Salio30 = d.Salio;
                                                break;
                                            case 31:
                                                r.L1Dia31 = d.Dia.Day;
                                                r.L1Franco31 = d.Franco;
                                                r.L1Entro31 = d.Entro;
                                                r.L1Diagr31 = d.Diagr;
                                                r.L1Salio31 = d.Salio;
                                                break;
                                        }

                                    r.CantF1 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "F").Count();
                                    r.CantLE1 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "LE").Count();
                                    r.CantLO1 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "LO").Count();
                                    r.CantO1 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco != "" && t.Franco != "F" && t.Franco != "LO"  && t.Franco != "LE").Count();
                                    break;
                                case 2:
                                    r.Legajo2 = l.Legajo.ToString() + " - " + l2.Cuit;
                                    r.Empleado2 = l2.Empleado;
                                    r.Ingreso2 = l2.Ingreso;
                                    r.Categoria2 = l2.Categoria;
                                    foreach (DiasReporte d in ListaDiasLegajos.Where(t => t.Legajo == l.Legajo))
                                        switch (d.Dia.Day)
                                        {
                                            case 1:
                                                r.L2Dia1 = d.Dia.Day;
                                                r.L2Franco1 = d.Franco;
                                                r.L2Entro1 = d.Entro;
                                                r.L2Diagr1 = d.Diagr;
                                                r.L2Salio1 = d.Salio;
                                                break;
                                            case 2:
                                                r.L2Dia2 = d.Dia.Day;
                                                r.L2Franco2 = d.Franco;
                                                r.L2Entro2 = d.Entro;
                                                r.L2Diagr2 = d.Diagr;
                                                r.L2Salio2 = d.Salio;
                                                break;
                                            case 3:
                                                r.L2Dia3 = d.Dia.Day;
                                                r.L2Franco3 = d.Franco;
                                                r.L2Entro3 = d.Entro;
                                                r.L2Diagr3 = d.Diagr;
                                                r.L2Salio3 = d.Salio;
                                                break;
                                            case 4:
                                                r.L2Dia4 = d.Dia.Day;
                                                r.L2Franco4 = d.Franco;
                                                r.L2Entro4 = d.Entro;
                                                r.L2Diagr4 = d.Diagr;
                                                r.L2Salio4 = d.Salio;
                                                break;
                                            case 5:
                                                r.L2Dia5 = d.Dia.Day;
                                                r.L2Franco5 = d.Franco;
                                                r.L2Entro5 = d.Entro;
                                                r.L2Diagr5 = d.Diagr;
                                                r.L2Salio5 = d.Salio;
                                                break;
                                            case 6:
                                                r.L2Dia6 = d.Dia.Day;
                                                r.L2Franco6 = d.Franco;
                                                r.L2Entro6 = d.Entro;
                                                r.L2Diagr6 = d.Diagr;
                                                r.L2Salio6 = d.Salio;
                                                break;
                                            case 7:
                                                r.L2Dia7 = d.Dia.Day;
                                                r.L2Franco7 = d.Franco;
                                                r.L2Entro7 = d.Entro;
                                                r.L2Diagr7 = d.Diagr;
                                                r.L2Salio7 = d.Salio;
                                                break;
                                            case 8:
                                                r.L2Dia8 = d.Dia.Day;
                                                r.L2Franco8 = d.Franco;
                                                r.L2Entro8 = d.Entro;
                                                r.L2Diagr8 = d.Diagr;
                                                r.L2Salio8 = d.Salio;
                                                break;
                                            case 9:
                                                r.L2Dia9 = d.Dia.Day;
                                                r.L2Franco9 = d.Franco;
                                                r.L2Entro9 = d.Entro;
                                                r.L2Diagr9 = d.Diagr;
                                                r.L2Salio9 = d.Salio;
                                                break;
                                            case 10:
                                                r.L2Dia10 = d.Dia.Day;
                                                r.L2Franco10 = d.Franco;
                                                r.L2Entro10 = d.Entro;
                                                r.L2Diagr10 = d.Diagr;
                                                r.L2Salio10 = d.Salio;
                                                break;
                                            case 11:
                                                r.L2Dia11 = d.Dia.Day;
                                                r.L2Franco11 = d.Franco;
                                                r.L2Entro11 = d.Entro;
                                                r.L2Diagr11 = d.Diagr;
                                                r.L2Salio11 = d.Salio;
                                                break;
                                            case 12:
                                                r.L2Dia12 = d.Dia.Day;
                                                r.L2Franco12 = d.Franco;
                                                r.L2Entro12 = d.Entro;
                                                r.L2Diagr12 = d.Diagr;
                                                r.L2Salio12 = d.Salio;
                                                break;
                                            case 13:
                                                r.L2Dia13 = d.Dia.Day;
                                                r.L2Franco13 = d.Franco;
                                                r.L2Entro13 = d.Entro;
                                                r.L2Diagr13 = d.Diagr;
                                                r.L2Salio13 = d.Salio;
                                                break;
                                            case 14:
                                                r.L2Dia14 = d.Dia.Day;
                                                r.L2Franco14 = d.Franco;
                                                r.L2Entro14 = d.Entro;
                                                r.L2Diagr14 = d.Diagr;
                                                r.L2Salio14 = d.Salio;
                                                break;
                                            case 15:
                                                r.L2Dia15 = d.Dia.Day;
                                                r.L2Franco15 = d.Franco;
                                                r.L2Entro15 = d.Entro;
                                                r.L2Diagr15 = d.Diagr;
                                                r.L2Salio15 = d.Salio;
                                                break;
                                            case 16:
                                                r.L2Dia16 = d.Dia.Day;
                                                r.L2Franco16 = d.Franco;
                                                r.L2Entro16 = d.Entro;
                                                r.L2Diagr16 = d.Diagr;
                                                r.L2Salio16 = d.Salio;
                                                break;
                                            case 17:
                                                r.L2Dia17 = d.Dia.Day;
                                                r.L2Franco17 = d.Franco;
                                                r.L2Entro17 = d.Entro;
                                                r.L2Diagr17 = d.Diagr;
                                                r.L2Salio17 = d.Salio;
                                                break;
                                            case 18:
                                                r.L2Dia18 = d.Dia.Day;
                                                r.L2Franco18 = d.Franco;
                                                r.L2Entro18 = d.Entro;
                                                r.L2Diagr18 = d.Diagr;
                                                r.L2Salio18 = d.Salio;
                                                break;
                                            case 19:
                                                r.L2Dia19 = d.Dia.Day;
                                                r.L2Franco19 = d.Franco;
                                                r.L2Entro19 = d.Entro;
                                                r.L2Diagr19 = d.Diagr;
                                                r.L2Salio19 = d.Salio;
                                                break;
                                            case 20:
                                                r.L2Dia20 = d.Dia.Day;
                                                r.L2Franco20 = d.Franco;
                                                r.L2Entro20 = d.Entro;
                                                r.L2Diagr20 = d.Diagr;
                                                r.L2Salio20 = d.Salio;
                                                break;
                                            case 21:
                                                r.L2Dia21 = d.Dia.Day;
                                                r.L2Franco21 = d.Franco;
                                                r.L2Entro21 = d.Entro;
                                                r.L2Diagr21 = d.Diagr;
                                                r.L2Salio21 = d.Salio;
                                                break;
                                            case 22:
                                                r.L2Dia22 = d.Dia.Day;
                                                r.L2Franco22 = d.Franco;
                                                r.L2Entro22 = d.Entro;
                                                r.L2Diagr22 = d.Diagr;
                                                r.L2Salio22 = d.Salio;
                                                break;
                                            case 23:
                                                r.L2Dia23 = d.Dia.Day;
                                                r.L2Franco23 = d.Franco;
                                                r.L2Entro23 = d.Entro;
                                                r.L2Diagr23 = d.Diagr;
                                                r.L2Salio23 = d.Salio;
                                                break;
                                            case 24:
                                                r.L2Dia24 = d.Dia.Day;
                                                r.L2Franco24 = d.Franco;
                                                r.L2Entro24 = d.Entro;
                                                r.L2Diagr24 = d.Diagr;
                                                r.L2Salio24 = d.Salio;
                                                break;
                                            case 25:
                                                r.L2Dia25 = d.Dia.Day;
                                                r.L2Franco25 = d.Franco;
                                                r.L2Entro25 = d.Entro;
                                                r.L2Diagr25 = d.Diagr;
                                                r.L2Salio25 = d.Salio;
                                                break;
                                            case 26:
                                                r.L2Dia26 = d.Dia.Day;
                                                r.L2Franco26 = d.Franco;
                                                r.L2Entro26 = d.Entro;
                                                r.L2Diagr26 = d.Diagr;
                                                r.L2Salio26 = d.Salio;
                                                break;
                                            case 27:
                                                r.L2Dia27 = d.Dia.Day;
                                                r.L2Franco27 = d.Franco;
                                                r.L2Entro27 = d.Entro;
                                                r.L2Diagr27 = d.Diagr;
                                                r.L2Salio27 = d.Salio;
                                                break;
                                            case 28:
                                                r.L2Dia28 = d.Dia.Day;
                                                r.L2Franco28 = d.Franco;
                                                r.L2Entro28 = d.Entro;
                                                r.L2Diagr28 = d.Diagr;
                                                r.L2Salio28 = d.Salio;
                                                break;
                                            case 29:
                                                r.L2Dia29 = d.Dia.Day;
                                                r.L2Franco29 = d.Franco;
                                                r.L2Entro29 = d.Entro;
                                                r.L2Diagr29 = d.Diagr;
                                                r.L2Salio29 = d.Salio;
                                                break;
                                            case 30:
                                                r.L2Dia30 = d.Dia.Day;
                                                r.L2Franco30 = d.Franco;
                                                r.L2Entro30 = d.Entro;
                                                r.L2Diagr30 = d.Diagr;
                                                r.L2Salio30 = d.Salio;
                                                break;
                                            case 31:
                                                r.L2Dia31 = d.Dia.Day;
                                                r.L2Franco31 = d.Franco;
                                                r.L2Entro31 = d.Entro;
                                                r.L2Diagr31 = d.Diagr;
                                                r.L2Salio31 = d.Salio;
                                                break;
                                        }
                                    r.CantF2 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "F").Count();
                                    r.CantLE2 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "LE").Count();
                                    r.CantLO2= ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "LO").Count();
                                    r.CantO2 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco != "" && t.Franco != "F" && t.Franco != "LO" && t.Franco != "LE").Count(); break;
                                case 3:
                                    r.Legajo3 = l.Legajo.ToString() + " - " + l2.Cuit;
                                    r.Empleado3 = l2.Empleado;
                                    r.Ingreso3 = l2.Ingreso;
                                    r.Categoria3 = l2.Categoria;
                                    foreach (DiasReporte d in ListaDiasLegajos.Where(t => t.Legajo == l.Legajo))
                                        switch (d.Dia.Day)
                                        {
                                            case 1:
                                                r.L3Dia1 = d.Dia.Day;
                                                r.L3Franco1 = d.Franco;
                                                r.L3Entro1 = d.Entro;
                                                r.L3Diagr1 = d.Diagr;
                                                r.L3Salio1 = d.Salio;
                                                break;
                                            case 2:
                                                r.L3Dia2 = d.Dia.Day;
                                                r.L3Franco2 = d.Franco;
                                                r.L3Entro2 = d.Entro;
                                                r.L3Diagr2 = d.Diagr;
                                                r.L3Salio2 = d.Salio;
                                                break;
                                            case 3:
                                                r.L3Dia3 = d.Dia.Day;
                                                r.L3Franco3 = d.Franco;
                                                r.L3Entro3 = d.Entro;
                                                r.L3Diagr3 = d.Diagr;
                                                r.L3Salio3 = d.Salio;
                                                break;
                                            case 4:
                                                r.L3Dia4 = d.Dia.Day;
                                                r.L3Franco4 = d.Franco;
                                                r.L3Entro4 = d.Entro;
                                                r.L3Diagr4 = d.Diagr;
                                                r.L3Salio4 = d.Salio;
                                                break;
                                            case 5:
                                                r.L3Dia5 = d.Dia.Day;
                                                r.L3Franco5 = d.Franco;
                                                r.L3Entro5 = d.Entro;
                                                r.L3Diagr5 = d.Diagr;
                                                r.L3Salio5 = d.Salio;
                                                break;
                                            case 6:
                                                r.L3Dia6 = d.Dia.Day;
                                                r.L3Franco6 = d.Franco;
                                                r.L3Entro6 = d.Entro;
                                                r.L3Diagr6 = d.Diagr;
                                                r.L3Salio6 = d.Salio;
                                                break;
                                            case 7:
                                                r.L3Dia7 = d.Dia.Day;
                                                r.L3Franco7 = d.Franco;
                                                r.L3Entro7 = d.Entro;
                                                r.L3Diagr7 = d.Diagr;
                                                r.L3Salio7 = d.Salio;
                                                break;
                                            case 8:
                                                r.L3Dia8 = d.Dia.Day;
                                                r.L3Franco8 = d.Franco;
                                                r.L3Entro8 = d.Entro;
                                                r.L3Diagr8 = d.Diagr;
                                                r.L3Salio8 = d.Salio;
                                                break;
                                            case 9:
                                                r.L3Dia9 = d.Dia.Day;
                                                r.L3Franco9 = d.Franco;
                                                r.L3Entro9 = d.Entro;
                                                r.L3Diagr9 = d.Diagr;
                                                r.L3Salio9 = d.Salio;
                                                break;
                                            case 10:
                                                r.L3Dia10 = d.Dia.Day;
                                                r.L3Franco10 = d.Franco;
                                                r.L3Entro10 = d.Entro;
                                                r.L3Diagr10 = d.Diagr;
                                                r.L3Salio10 = d.Salio;
                                                break;
                                            case 11:
                                                r.L3Dia11 = d.Dia.Day;
                                                r.L3Franco11 = d.Franco;
                                                r.L3Entro11 = d.Entro;
                                                r.L3Diagr11 = d.Diagr;
                                                r.L3Salio11 = d.Salio;
                                                break;
                                            case 12:
                                                r.L3Dia12 = d.Dia.Day;
                                                r.L3Franco12 = d.Franco;
                                                r.L3Entro12 = d.Entro;
                                                r.L3Diagr12 = d.Diagr;
                                                r.L3Salio12 = d.Salio;
                                                break;
                                            case 13:
                                                r.L3Dia13 = d.Dia.Day;
                                                r.L3Franco13 = d.Franco;
                                                r.L3Entro13 = d.Entro;
                                                r.L3Diagr13 = d.Diagr;
                                                r.L3Salio13 = d.Salio;
                                                break;
                                            case 14:
                                                r.L3Dia14 = d.Dia.Day;
                                                r.L3Franco14 = d.Franco;
                                                r.L3Entro14 = d.Entro;
                                                r.L3Diagr14 = d.Diagr;
                                                r.L3Salio14 = d.Salio;
                                                break;
                                            case 15:
                                                r.L3Dia15 = d.Dia.Day;
                                                r.L3Franco15 = d.Franco;
                                                r.L3Entro15 = d.Entro;
                                                r.L3Diagr15 = d.Diagr;
                                                r.L3Salio15 = d.Salio;
                                                break;
                                            case 16:
                                                r.L3Dia16 = d.Dia.Day;
                                                r.L3Franco16 = d.Franco;
                                                r.L3Entro16 = d.Entro;
                                                r.L3Diagr16 = d.Diagr;
                                                r.L3Salio16 = d.Salio;
                                                break;
                                            case 17:
                                                r.L3Dia17 = d.Dia.Day;
                                                r.L3Franco17 = d.Franco;
                                                r.L3Entro17 = d.Entro;
                                                r.L3Diagr17 = d.Diagr;
                                                r.L3Salio17 = d.Salio;
                                                break;
                                            case 18:
                                                r.L3Dia18 = d.Dia.Day;
                                                r.L3Franco18 = d.Franco;
                                                r.L3Entro18 = d.Entro;
                                                r.L3Diagr18 = d.Diagr;
                                                r.L3Salio18 = d.Salio;
                                                break;
                                            case 19:
                                                r.L3Dia19 = d.Dia.Day;
                                                r.L3Franco19 = d.Franco;
                                                r.L3Entro19 = d.Entro;
                                                r.L3Diagr19 = d.Diagr;
                                                r.L3Salio19 = d.Salio;
                                                break;
                                            case 20:
                                                r.L3Dia20 = d.Dia.Day;
                                                r.L3Franco20 = d.Franco;
                                                r.L3Entro20 = d.Entro;
                                                r.L3Diagr20 = d.Diagr;
                                                r.L3Salio20 = d.Salio;
                                                break;
                                            case 21:
                                                r.L3Dia21 = d.Dia.Day;
                                                r.L3Franco21 = d.Franco;
                                                r.L3Entro21 = d.Entro;
                                                r.L3Diagr21 = d.Diagr;
                                                r.L3Salio21 = d.Salio;
                                                break;
                                            case 22:
                                                r.L3Dia22 = d.Dia.Day;
                                                r.L3Franco22 = d.Franco;
                                                r.L3Entro22 = d.Entro;
                                                r.L3Diagr22 = d.Diagr;
                                                r.L3Salio22 = d.Salio;
                                                break;
                                            case 23:
                                                r.L3Dia23 = d.Dia.Day;
                                                r.L3Franco23 = d.Franco;
                                                r.L3Entro23 = d.Entro;
                                                r.L3Diagr23 = d.Diagr;
                                                r.L3Salio23 = d.Salio;
                                                break;
                                            case 24:
                                                r.L3Dia24 = d.Dia.Day;
                                                r.L3Franco24 = d.Franco;
                                                r.L3Entro24 = d.Entro;
                                                r.L3Diagr24 = d.Diagr;
                                                r.L3Salio24 = d.Salio;
                                                break;
                                            case 25:
                                                r.L3Dia25 = d.Dia.Day;
                                                r.L3Franco25 = d.Franco;
                                                r.L3Entro25 = d.Entro;
                                                r.L3Diagr25 = d.Diagr;
                                                r.L3Salio25 = d.Salio;
                                                break;
                                            case 26:
                                                r.L3Dia26 = d.Dia.Day;
                                                r.L3Franco26 = d.Franco;
                                                r.L3Entro26 = d.Entro;
                                                r.L3Diagr26 = d.Diagr;
                                                r.L3Salio26 = d.Salio;
                                                break;
                                            case 27:
                                                r.L3Dia27 = d.Dia.Day;
                                                r.L3Franco27 = d.Franco;
                                                r.L3Entro27 = d.Entro;
                                                r.L3Diagr27 = d.Diagr;
                                                r.L3Salio27 = d.Salio;
                                                break;
                                            case 28:
                                                r.L3Dia28 = d.Dia.Day;
                                                r.L3Franco28 = d.Franco;
                                                r.L3Entro28 = d.Entro;
                                                r.L3Diagr28 = d.Diagr;
                                                r.L3Salio28 = d.Salio;
                                                break;
                                            case 29:
                                                r.L3Dia29 = d.Dia.Day;
                                                r.L3Franco29 = d.Franco;
                                                r.L3Entro29 = d.Entro;
                                                r.L3Diagr29 = d.Diagr;
                                                r.L3Salio29 = d.Salio;
                                                break;
                                            case 30:
                                                r.L3Dia30 = d.Dia.Day;
                                                r.L3Franco30 = d.Franco;
                                                r.L3Entro30 = d.Entro;
                                                r.L3Diagr30 = d.Diagr;
                                                r.L3Salio30 = d.Salio;
                                                break;
                                            case 31:
                                                r.L3Dia31 = d.Dia.Day;
                                                r.L3Franco31 = d.Franco;
                                                r.L3Entro31 = d.Entro;
                                                r.L3Diagr31 = d.Diagr;
                                                r.L3Salio31 = d.Salio;
                                                break;
                                        }
                                    r.CantF3 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "F").Count();
                                    r.CantLE3 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "LE").Count();
                                    r.CantLO3 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "LO").Count();
                                    r.CantO3 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco != "" && t.Franco != "F" && t.Franco != "LO" && t.Franco != "LE").Count();
                                    break;
                                case 4:
                                    r.Legajo4 = l.Legajo.ToString() + " - " + l2.Cuit;
                                    r.Empleado4 = l2.Empleado;
                                    r.Ingreso4 = l2.Ingreso;
                                    r.Categoria4 = l2.Categoria;
                                    foreach (DiasReporte d in ListaDiasLegajos.Where(t => t.Legajo == l.Legajo))
                                        switch (d.Dia.Day)
                                        {
                                            case 1:
                                                r.L4Dia1 = d.Dia.Day;
                                                r.L4Franco1 = d.Franco;
                                                r.L4Entro1 = d.Entro;
                                                r.L4Diagr1 = d.Diagr;
                                                r.L4Salio1 = d.Salio;
                                                break;
                                            case 2:
                                                r.L4Dia2 = d.Dia.Day;
                                                r.L4Franco2 = d.Franco;
                                                r.L4Entro2 = d.Entro;
                                                r.L4Diagr2 = d.Diagr;
                                                r.L4Salio2 = d.Salio;
                                                break;
                                            case 3:
                                                r.L4Dia3 = d.Dia.Day;
                                                r.L4Franco3 = d.Franco;
                                                r.L4Entro3 = d.Entro;
                                                r.L4Diagr3 = d.Diagr;
                                                r.L4Salio3 = d.Salio;
                                                break;
                                            case 4:
                                                r.L4Dia4 = d.Dia.Day;
                                                r.L4Franco4 = d.Franco;
                                                r.L4Entro4 = d.Entro;
                                                r.L4Diagr4 = d.Diagr;
                                                r.L4Salio4 = d.Salio;
                                                break;
                                            case 5:
                                                r.L4Dia5 = d.Dia.Day;
                                                r.L4Franco5 = d.Franco;
                                                r.L4Entro5 = d.Entro;
                                                r.L4Diagr5 = d.Diagr;
                                                r.L4Salio5 = d.Salio;
                                                break;
                                            case 6:
                                                r.L4Dia6 = d.Dia.Day;
                                                r.L4Franco6 = d.Franco;
                                                r.L4Entro6 = d.Entro;
                                                r.L4Diagr6 = d.Diagr;
                                                r.L4Salio6 = d.Salio;
                                                break;
                                            case 7:
                                                r.L4Dia7 = d.Dia.Day;
                                                r.L4Franco7 = d.Franco;
                                                r.L4Entro7 = d.Entro;
                                                r.L4Diagr7 = d.Diagr;
                                                r.L4Salio7 = d.Salio;
                                                break;
                                            case 8:
                                                r.L4Dia8 = d.Dia.Day;
                                                r.L4Franco8 = d.Franco;
                                                r.L4Entro8 = d.Entro;
                                                r.L4Diagr8 = d.Diagr;
                                                r.L4Salio8 = d.Salio;
                                                break;
                                            case 9:
                                                r.L4Dia9 = d.Dia.Day;
                                                r.L4Franco9 = d.Franco;
                                                r.L4Entro9 = d.Entro;
                                                r.L4Diagr9 = d.Diagr;
                                                r.L4Salio9 = d.Salio;
                                                break;
                                            case 10:
                                                r.L4Dia10 = d.Dia.Day;
                                                r.L4Franco10 = d.Franco;
                                                r.L4Entro10 = d.Entro;
                                                r.L4Diagr10 = d.Diagr;
                                                r.L4Salio10 = d.Salio;
                                                break;
                                            case 11:
                                                r.L4Dia11 = d.Dia.Day;
                                                r.L4Franco11 = d.Franco;
                                                r.L4Entro11 = d.Entro;
                                                r.L4Diagr11 = d.Diagr;
                                                r.L4Salio11 = d.Salio;
                                                break;
                                            case 12:
                                                r.L4Dia12 = d.Dia.Day;
                                                r.L4Franco12 = d.Franco;
                                                r.L4Entro12 = d.Entro;
                                                r.L4Diagr12 = d.Diagr;
                                                r.L4Salio12 = d.Salio;
                                                break;
                                            case 13:
                                                r.L4Dia13 = d.Dia.Day;
                                                r.L4Franco13 = d.Franco;
                                                r.L4Entro13 = d.Entro;
                                                r.L4Diagr13 = d.Diagr;
                                                r.L4Salio13 = d.Salio;
                                                break;
                                            case 14:
                                                r.L4Dia14 = d.Dia.Day;
                                                r.L4Franco14 = d.Franco;
                                                r.L4Entro14 = d.Entro;
                                                r.L4Diagr14 = d.Diagr;
                                                r.L4Salio14 = d.Salio;
                                                break;
                                            case 15:
                                                r.L4Dia15 = d.Dia.Day;
                                                r.L4Franco15 = d.Franco;
                                                r.L4Entro15 = d.Entro;
                                                r.L4Diagr15 = d.Diagr;
                                                r.L4Salio15 = d.Salio;
                                                break;
                                            case 16:
                                                r.L4Dia16 = d.Dia.Day;
                                                r.L4Franco16 = d.Franco;
                                                r.L4Entro16 = d.Entro;
                                                r.L4Diagr16 = d.Diagr;
                                                r.L4Salio16 = d.Salio;
                                                break;
                                            case 17:
                                                r.L4Dia17 = d.Dia.Day;
                                                r.L4Franco17 = d.Franco;
                                                r.L4Entro17 = d.Entro;
                                                r.L4Diagr17 = d.Diagr;
                                                r.L4Salio17 = d.Salio;
                                                break;
                                            case 18:
                                                r.L4Dia18 = d.Dia.Day;
                                                r.L4Franco18 = d.Franco;
                                                r.L4Entro18 = d.Entro;
                                                r.L4Diagr18 = d.Diagr;
                                                r.L4Salio18 = d.Salio;
                                                break;
                                            case 19:
                                                r.L4Dia19 = d.Dia.Day;
                                                r.L4Franco19 = d.Franco;
                                                r.L4Entro19 = d.Entro;
                                                r.L4Diagr19 = d.Diagr;
                                                r.L4Salio19 = d.Salio;
                                                break;
                                            case 20:
                                                r.L4Dia20 = d.Dia.Day;
                                                r.L4Franco20 = d.Franco;
                                                r.L4Entro20 = d.Entro;
                                                r.L4Diagr20 = d.Diagr;
                                                r.L4Salio20 = d.Salio;
                                                break;
                                            case 21:
                                                r.L4Dia21 = d.Dia.Day;
                                                r.L4Franco21 = d.Franco;
                                                r.L4Entro21 = d.Entro;
                                                r.L4Diagr21 = d.Diagr;
                                                r.L4Salio21 = d.Salio;
                                                break;
                                            case 22:
                                                r.L4Dia22 = d.Dia.Day;
                                                r.L4Franco22 = d.Franco;
                                                r.L4Entro22 = d.Entro;
                                                r.L4Diagr22 = d.Diagr;
                                                r.L4Salio22 = d.Salio;
                                                break;
                                            case 23:
                                                r.L4Dia23 = d.Dia.Day;
                                                r.L4Franco23 = d.Franco;
                                                r.L4Entro23 = d.Entro;
                                                r.L4Diagr23 = d.Diagr;
                                                r.L4Salio23 = d.Salio;
                                                break;
                                            case 24:
                                                r.L4Dia24 = d.Dia.Day;
                                                r.L4Franco24 = d.Franco;
                                                r.L4Entro24 = d.Entro;
                                                r.L4Diagr24 = d.Diagr;
                                                r.L4Salio24 = d.Salio;
                                                break;
                                            case 25:
                                                r.L4Dia25 = d.Dia.Day;
                                                r.L4Franco25 = d.Franco;
                                                r.L4Entro25 = d.Entro;
                                                r.L4Diagr25 = d.Diagr;
                                                r.L4Salio25 = d.Salio;
                                                break;
                                            case 26:
                                                r.L4Dia26 = d.Dia.Day;
                                                r.L4Franco26 = d.Franco;
                                                r.L4Entro26 = d.Entro;
                                                r.L4Diagr26 = d.Diagr;
                                                r.L4Salio26 = d.Salio;
                                                break;
                                            case 27:
                                                r.L4Dia27 = d.Dia.Day;
                                                r.L4Franco27 = d.Franco;
                                                r.L4Entro27 = d.Entro;
                                                r.L4Diagr27 = d.Diagr;
                                                r.L4Salio27 = d.Salio;
                                                break;
                                            case 28:
                                                r.L4Dia28 = d.Dia.Day;
                                                r.L4Franco28 = d.Franco;
                                                r.L4Entro28 = d.Entro;
                                                r.L4Diagr28 = d.Diagr;
                                                r.L4Salio28 = d.Salio;
                                                break;
                                            case 29:
                                                r.L4Dia29 = d.Dia.Day;
                                                r.L4Franco29 = d.Franco;
                                                r.L4Entro29 = d.Entro;
                                                r.L4Diagr29 = d.Diagr;
                                                r.L4Salio29 = d.Salio;
                                                break;
                                            case 30:
                                                r.L4Dia30 = d.Dia.Day;
                                                r.L4Franco30 = d.Franco;
                                                r.L4Entro30 = d.Entro;
                                                r.L4Diagr30 = d.Diagr;
                                                r.L4Salio30 = d.Salio;
                                                break;
                                            case 31:
                                                r.L4Dia31 = d.Dia.Day;
                                                r.L4Franco31 = d.Franco;
                                                r.L4Entro31 = d.Entro;
                                                r.L4Diagr31 = d.Diagr;
                                                r.L4Salio31 = d.Salio;
                                                break;
                                        }
                                    r.CantF4 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "F").Count();
                                    r.CantLE4 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "LE").Count();
                                    r.CantLO4 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "LO").Count();
                                    r.CantO4 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco != "" && t.Franco != "F" && t.Franco != "LO" && t.Franco != "LE").Count();
                                    break;
                                case 5:
                                    r.Legajo5 = l.Legajo.ToString() + " - " + l2.Cuit;
                                    r.Empleado5 = l2.Empleado;
                                    r.Ingreso5 = l2.Ingreso;
                                    r.Categoria5 = l2.Categoria;
                                    foreach (DiasReporte d in ListaDiasLegajos.Where(t => t.Legajo == l.Legajo))
                                        switch (d.Dia.Day)
                                        {
                                            case 1:
                                                r.L5Dia1 = d.Dia.Day;
                                                r.L5Franco1 = d.Franco;
                                                r.L5Entro1 = d.Entro;
                                                r.L5Diagr1 = d.Diagr;
                                                r.L5Salio1 = d.Salio;
                                                break;
                                            case 2:
                                                r.L5Dia2 = d.Dia.Day;
                                                r.L5Franco2 = d.Franco;
                                                r.L5Entro2 = d.Entro;
                                                r.L5Diagr2 = d.Diagr;
                                                r.L5Salio2 = d.Salio;
                                                break;
                                            case 3:
                                                r.L5Dia3 = d.Dia.Day;
                                                r.L5Franco3 = d.Franco;
                                                r.L5Entro3 = d.Entro;
                                                r.L5Diagr3 = d.Diagr;
                                                r.L5Salio3 = d.Salio;
                                                break;
                                            case 4:
                                                r.L5Dia4 = d.Dia.Day;
                                                r.L5Franco4 = d.Franco;
                                                r.L5Entro4 = d.Entro;
                                                r.L5Diagr4 = d.Diagr;
                                                r.L5Salio4 = d.Salio;
                                                break;
                                            case 5:
                                                r.L5Dia5 = d.Dia.Day;
                                                r.L5Franco5 = d.Franco;
                                                r.L5Entro5 = d.Entro;
                                                r.L5Diagr5 = d.Diagr;
                                                r.L5Salio5 = d.Salio;
                                                break;
                                            case 6:
                                                r.L5Dia6 = d.Dia.Day;
                                                r.L5Franco6 = d.Franco;
                                                r.L5Entro6 = d.Entro;
                                                r.L5Diagr6 = d.Diagr;
                                                r.L5Salio6 = d.Salio;
                                                break;
                                            case 7:
                                                r.L5Dia7 = d.Dia.Day;
                                                r.L5Franco7 = d.Franco;
                                                r.L5Entro7 = d.Entro;
                                                r.L5Diagr7 = d.Diagr;
                                                r.L5Salio7 = d.Salio;
                                                break;
                                            case 8:
                                                r.L5Dia8 = d.Dia.Day;
                                                r.L5Franco8 = d.Franco;
                                                r.L5Entro8 = d.Entro;
                                                r.L5Diagr8 = d.Diagr;
                                                r.L5Salio8 = d.Salio;
                                                break;
                                            case 9:
                                                r.L5Dia9 = d.Dia.Day;
                                                r.L5Franco9 = d.Franco;
                                                r.L5Entro9 = d.Entro;
                                                r.L5Diagr9 = d.Diagr;
                                                r.L5Salio9 = d.Salio;
                                                break;
                                            case 10:
                                                r.L5Dia10 = d.Dia.Day;
                                                r.L5Franco10 = d.Franco;
                                                r.L5Entro10 = d.Entro;
                                                r.L5Diagr10 = d.Diagr;
                                                r.L5Salio10 = d.Salio;
                                                break;
                                            case 11:
                                                r.L5Dia11 = d.Dia.Day;
                                                r.L5Franco11 = d.Franco;
                                                r.L5Entro11 = d.Entro;
                                                r.L5Diagr11 = d.Diagr;
                                                r.L5Salio11 = d.Salio;
                                                break;
                                            case 12:
                                                r.L5Dia12 = d.Dia.Day;
                                                r.L5Franco12 = d.Franco;
                                                r.L5Entro12 = d.Entro;
                                                r.L5Diagr12 = d.Diagr;
                                                r.L5Salio12 = d.Salio;
                                                break;
                                            case 13:
                                                r.L5Dia13 = d.Dia.Day;
                                                r.L5Franco13 = d.Franco;
                                                r.L5Entro13 = d.Entro;
                                                r.L5Diagr13 = d.Diagr;
                                                r.L5Salio13 = d.Salio;
                                                break;
                                            case 14:
                                                r.L5Dia14 = d.Dia.Day;
                                                r.L5Franco14 = d.Franco;
                                                r.L5Entro14 = d.Entro;
                                                r.L5Diagr14 = d.Diagr;
                                                r.L5Salio14 = d.Salio;
                                                break;
                                            case 15:
                                                r.L5Dia15 = d.Dia.Day;
                                                r.L5Franco15 = d.Franco;
                                                r.L5Entro15 = d.Entro;
                                                r.L5Diagr15 = d.Diagr;
                                                r.L5Salio15 = d.Salio;
                                                break;
                                            case 16:
                                                r.L5Dia16 = d.Dia.Day;
                                                r.L5Franco16 = d.Franco;
                                                r.L5Entro16 = d.Entro;
                                                r.L5Diagr16 = d.Diagr;
                                                r.L5Salio16 = d.Salio;
                                                break;
                                            case 17:
                                                r.L5Dia17 = d.Dia.Day;
                                                r.L5Franco17 = d.Franco;
                                                r.L5Entro17 = d.Entro;
                                                r.L5Diagr17 = d.Diagr;
                                                r.L5Salio17 = d.Salio;
                                                break;
                                            case 18:
                                                r.L5Dia18 = d.Dia.Day;
                                                r.L5Franco18 = d.Franco;
                                                r.L5Entro18 = d.Entro;
                                                r.L5Diagr18 = d.Diagr;
                                                r.L5Salio18 = d.Salio;
                                                break;
                                            case 19:
                                                r.L5Dia19 = d.Dia.Day;
                                                r.L5Franco19 = d.Franco;
                                                r.L5Entro19 = d.Entro;
                                                r.L5Diagr19 = d.Diagr;
                                                r.L5Salio19 = d.Salio;
                                                break;
                                            case 20:
                                                r.L5Dia20 = d.Dia.Day;
                                                r.L5Franco20 = d.Franco;
                                                r.L5Entro20 = d.Entro;
                                                r.L5Diagr20 = d.Diagr;
                                                r.L5Salio20 = d.Salio;
                                                break;
                                            case 21:
                                                r.L5Dia21 = d.Dia.Day;
                                                r.L5Franco21 = d.Franco;
                                                r.L5Entro21 = d.Entro;
                                                r.L5Diagr21 = d.Diagr;
                                                r.L5Salio21 = d.Salio;
                                                break;
                                            case 22:
                                                r.L5Dia22 = d.Dia.Day;
                                                r.L5Franco22 = d.Franco;
                                                r.L5Entro22 = d.Entro;
                                                r.L5Diagr22 = d.Diagr;
                                                r.L5Salio22 = d.Salio;
                                                break;
                                            case 23:
                                                r.L5Dia23 = d.Dia.Day;
                                                r.L5Franco23 = d.Franco;
                                                r.L5Entro23 = d.Entro;
                                                r.L5Diagr23 = d.Diagr;
                                                r.L5Salio23 = d.Salio;
                                                break;
                                            case 24:
                                                r.L5Dia24 = d.Dia.Day;
                                                r.L5Franco24 = d.Franco;
                                                r.L5Entro24 = d.Entro;
                                                r.L5Diagr24 = d.Diagr;
                                                r.L5Salio24 = d.Salio;
                                                break;
                                            case 25:
                                                r.L5Dia25 = d.Dia.Day;
                                                r.L5Franco25 = d.Franco;
                                                r.L5Entro25 = d.Entro;
                                                r.L5Diagr25 = d.Diagr;
                                                r.L5Salio25 = d.Salio;
                                                break;
                                            case 26:
                                                r.L5Dia26 = d.Dia.Day;
                                                r.L5Franco26 = d.Franco;
                                                r.L5Entro26 = d.Entro;
                                                r.L5Diagr26 = d.Diagr;
                                                r.L5Salio26 = d.Salio;
                                                break;
                                            case 27:
                                                r.L5Dia27 = d.Dia.Day;
                                                r.L5Franco27 = d.Franco;
                                                r.L5Entro27 = d.Entro;
                                                r.L5Diagr27 = d.Diagr;
                                                r.L5Salio27 = d.Salio;
                                                break;
                                            case 28:
                                                r.L5Dia28 = d.Dia.Day;
                                                r.L5Franco28 = d.Franco;
                                                r.L5Entro28 = d.Entro;
                                                r.L5Diagr28 = d.Diagr;
                                                r.L5Salio28 = d.Salio;
                                                break;
                                            case 29:
                                                r.L5Dia29 = d.Dia.Day;
                                                r.L5Franco29 = d.Franco;
                                                r.L5Entro29 = d.Entro;
                                                r.L5Diagr29 = d.Diagr;
                                                r.L5Salio29 = d.Salio;
                                                break;
                                            case 30:
                                                r.L5Dia30 = d.Dia.Day;
                                                r.L5Franco30 = d.Franco;
                                                r.L5Entro30 = d.Entro;
                                                r.L5Diagr30 = d.Diagr;
                                                r.L5Salio30 = d.Salio;
                                                break;
                                            case 31:
                                                r.L5Dia31 = d.Dia.Day;
                                                r.L5Franco31 = d.Franco;
                                                r.L5Entro31 = d.Entro;
                                                r.L5Diagr31 = d.Diagr;
                                                r.L5Salio31 = d.Salio;
                                                break;
                                        }
                                    r.CantF5 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "F").Count();
                                    r.CantLE5 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "LE").Count();
                                    r.CantLO5 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "LO").Count();
                                    r.CantO5 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco != "" && t.Franco != "F" && t.Franco != "LO" && t.Franco != "LE").Count();
                                    break;
                                case 6:
                                    r.Legajo6 = l.Legajo.ToString() + " - " + l2.Cuit;
                                    r.Empleado6 = l2.Empleado;
                                    r.Ingreso6 = l2.Ingreso;
                                    r.Categoria6 = l2.Categoria;
                                    foreach (DiasReporte d in ListaDiasLegajos.Where(t => t.Legajo == l.Legajo))
                                        switch (d.Dia.Day)
                                        {
                                            case 1:
                                                r.L6Dia1 = d.Dia.Day;
                                                r.L6Franco1 = d.Franco;
                                                r.L6Entro1 = d.Entro;
                                                r.L6Diagr1 = d.Diagr;
                                                r.L6Salio1 = d.Salio;
                                                break;
                                            case 2:
                                                r.L6Dia2 = d.Dia.Day;
                                                r.L6Franco2 = d.Franco;
                                                r.L6Entro2 = d.Entro;
                                                r.L6Diagr2 = d.Diagr;
                                                r.L6Salio2 = d.Salio;
                                                break;
                                            case 3:
                                                r.L6Dia3 = d.Dia.Day;
                                                r.L6Franco3 = d.Franco;
                                                r.L6Entro3 = d.Entro;
                                                r.L6Diagr3 = d.Diagr;
                                                r.L6Salio3 = d.Salio;
                                                break;
                                            case 4:
                                                r.L6Dia4 = d.Dia.Day;
                                                r.L6Franco4 = d.Franco;
                                                r.L6Entro4 = d.Entro;
                                                r.L6Diagr4 = d.Diagr;
                                                r.L6Salio4 = d.Salio;
                                                break;
                                            case 5:
                                                r.L6Dia5 = d.Dia.Day;
                                                r.L6Franco5 = d.Franco;
                                                r.L6Entro5 = d.Entro;
                                                r.L6Diagr5 = d.Diagr;
                                                r.L6Salio5 = d.Salio;
                                                break;
                                            case 6:
                                                r.L6Dia6 = d.Dia.Day;
                                                r.L6Franco6 = d.Franco;
                                                r.L6Entro6 = d.Entro;
                                                r.L6Diagr6 = d.Diagr;
                                                r.L6Salio6 = d.Salio;
                                                break;
                                            case 7:
                                                r.L6Dia7 = d.Dia.Day;
                                                r.L6Franco7 = d.Franco;
                                                r.L6Entro7 = d.Entro;
                                                r.L6Diagr7 = d.Diagr;
                                                r.L6Salio7 = d.Salio;
                                                break;
                                            case 8:
                                                r.L6Dia8 = d.Dia.Day;
                                                r.L6Franco8 = d.Franco;
                                                r.L6Entro8 = d.Entro;
                                                r.L6Diagr8 = d.Diagr;
                                                r.L6Salio8 = d.Salio;
                                                break;
                                            case 9:
                                                r.L6Dia9 = d.Dia.Day;
                                                r.L6Franco9 = d.Franco;
                                                r.L6Entro9 = d.Entro;
                                                r.L6Diagr9 = d.Diagr;
                                                r.L6Salio9 = d.Salio;
                                                break;
                                            case 10:
                                                r.L6Dia10 = d.Dia.Day;
                                                r.L6Franco10 = d.Franco;
                                                r.L6Entro10 = d.Entro;
                                                r.L6Diagr10 = d.Diagr;
                                                r.L6Salio10 = d.Salio;
                                                break;
                                            case 11:
                                                r.L6Dia11 = d.Dia.Day;
                                                r.L6Franco11 = d.Franco;
                                                r.L6Entro11 = d.Entro;
                                                r.L6Diagr11 = d.Diagr;
                                                r.L6Salio11 = d.Salio;
                                                break;
                                            case 12:
                                                r.L6Dia12 = d.Dia.Day;
                                                r.L6Franco12 = d.Franco;
                                                r.L6Entro12 = d.Entro;
                                                r.L6Diagr12 = d.Diagr;
                                                r.L6Salio12 = d.Salio;
                                                break;
                                            case 13:
                                                r.L6Dia13 = d.Dia.Day;
                                                r.L6Franco13 = d.Franco;
                                                r.L6Entro13 = d.Entro;
                                                r.L6Diagr13 = d.Diagr;
                                                r.L6Salio13 = d.Salio;
                                                break;
                                            case 14:
                                                r.L6Dia14 = d.Dia.Day;
                                                r.L6Franco14 = d.Franco;
                                                r.L6Entro14 = d.Entro;
                                                r.L6Diagr14 = d.Diagr;
                                                r.L6Salio14 = d.Salio;
                                                break;
                                            case 15:
                                                r.L6Dia15 = d.Dia.Day;
                                                r.L6Franco15 = d.Franco;
                                                r.L6Entro15 = d.Entro;
                                                r.L6Diagr15 = d.Diagr;
                                                r.L6Salio15 = d.Salio;
                                                break;
                                            case 16:
                                                r.L6Dia16 = d.Dia.Day;
                                                r.L6Franco16 = d.Franco;
                                                r.L6Entro16 = d.Entro;
                                                r.L6Diagr16 = d.Diagr;
                                                r.L6Salio16 = d.Salio;
                                                break;
                                            case 17:
                                                r.L6Dia17 = d.Dia.Day;
                                                r.L6Franco17 = d.Franco;
                                                r.L6Entro17 = d.Entro;
                                                r.L6Diagr17 = d.Diagr;
                                                r.L6Salio17 = d.Salio;
                                                break;
                                            case 18:
                                                r.L6Dia18 = d.Dia.Day;
                                                r.L6Franco18 = d.Franco;
                                                r.L6Entro18 = d.Entro;
                                                r.L6Diagr18 = d.Diagr;
                                                r.L6Salio18 = d.Salio;
                                                break;
                                            case 19:
                                                r.L6Dia19 = d.Dia.Day;
                                                r.L6Franco19 = d.Franco;
                                                r.L6Entro19 = d.Entro;
                                                r.L6Diagr19 = d.Diagr;
                                                r.L6Salio19 = d.Salio;
                                                break;
                                            case 20:
                                                r.L6Dia20 = d.Dia.Day;
                                                r.L6Franco20 = d.Franco;
                                                r.L6Entro20 = d.Entro;
                                                r.L6Diagr20 = d.Diagr;
                                                r.L6Salio20 = d.Salio;
                                                break;
                                            case 21:
                                                r.L6Dia21 = d.Dia.Day;
                                                r.L6Franco21 = d.Franco;
                                                r.L6Entro21 = d.Entro;
                                                r.L6Diagr21 = d.Diagr;
                                                r.L6Salio21 = d.Salio;
                                                break;
                                            case 22:
                                                r.L6Dia22 = d.Dia.Day;
                                                r.L6Franco22 = d.Franco;
                                                r.L6Entro22 = d.Entro;
                                                r.L6Diagr22 = d.Diagr;
                                                r.L6Salio22 = d.Salio;
                                                break;
                                            case 23:
                                                r.L6Dia23 = d.Dia.Day;
                                                r.L6Franco23 = d.Franco;
                                                r.L6Entro23 = d.Entro;
                                                r.L6Diagr23 = d.Diagr;
                                                r.L6Salio23 = d.Salio;
                                                break;
                                            case 24:
                                                r.L6Dia24 = d.Dia.Day;
                                                r.L6Franco24 = d.Franco;
                                                r.L6Entro24 = d.Entro;
                                                r.L6Diagr24 = d.Diagr;
                                                r.L6Salio24 = d.Salio;
                                                break;
                                            case 25:
                                                r.L6Dia25 = d.Dia.Day;
                                                r.L6Franco25 = d.Franco;
                                                r.L6Entro25 = d.Entro;
                                                r.L6Diagr25 = d.Diagr;
                                                r.L6Salio25 = d.Salio;
                                                break;
                                            case 26:
                                                r.L6Dia26 = d.Dia.Day;
                                                r.L6Franco26 = d.Franco;
                                                r.L6Entro26 = d.Entro;
                                                r.L6Diagr26 = d.Diagr;
                                                r.L6Salio26 = d.Salio;
                                                break;
                                            case 27:
                                                r.L6Dia27 = d.Dia.Day;
                                                r.L6Franco27 = d.Franco;
                                                r.L6Entro27 = d.Entro;
                                                r.L6Diagr27 = d.Diagr;
                                                r.L6Salio27 = d.Salio;
                                                break;
                                            case 28:
                                                r.L6Dia28 = d.Dia.Day;
                                                r.L6Franco28 = d.Franco;
                                                r.L6Entro28 = d.Entro;
                                                r.L6Diagr28 = d.Diagr;
                                                r.L6Salio28 = d.Salio;
                                                break;
                                            case 29:
                                                r.L6Dia29 = d.Dia.Day;
                                                r.L6Franco29 = d.Franco;
                                                r.L6Entro29 = d.Entro;
                                                r.L6Diagr29 = d.Diagr;
                                                r.L6Salio29 = d.Salio;
                                                break;
                                            case 30:
                                                r.L6Dia30 = d.Dia.Day;
                                                r.L6Franco30 = d.Franco;
                                                r.L6Entro30 = d.Entro;
                                                r.L6Diagr30 = d.Diagr;
                                                r.L6Salio30 = d.Salio;
                                                break;
                                            case 31:
                                                r.L6Dia31 = d.Dia.Day;
                                                r.L6Franco31 = d.Franco;
                                                r.L6Entro31 = d.Entro;
                                                r.L6Diagr31 = d.Diagr;
                                                r.L6Salio31 = d.Salio;
                                                break;
                                        }
                                    r.CantF6 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "F").Count();
                                    r.CantLE6 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "LE").Count();
                                    r.CantLO6 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco == "LO").Count();
                                    r.CantO6 = ListaDiasLegajos.Where(t => t.Legajo == l.Legajo && t.Franco != "" && t.Franco != "F" && t.Franco != "LO" && t.Franco != "LE").Count();
                                    break;
                            }

                            if (x == 6)
                            {
                                x = 1;
                                ListaReporte.Add(r);
                                r = new DatosReporte();
                            }
                            else
                                x += 1;
                        }
                    }
                }

                if (x != 1)
                    ListaReporte.Add(r);

                return ListaReporte;
            }
        }

        private Legajos Load(System.Data.IDataRecord dr)
        {
            Legajos o = new Legajos();

            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (!dr.IsDBNull(i))
                {
                    switch (dr.GetName(i))
                    {
                        case "Legajo": o.Legajo = dr.GetInt32(i); break;
                        case "Empleado": o.Empleado = dr.GetString(i); break;
                        case "Categoria": o.Categoria = dr.GetString(i); break;
                        case "Ingreso": o.Ingreso = dr.GetDateTime(i); break;
                        case "Cuil": o.Cuit = dr.GetString(i); break;
                    }
                }
            }

            return o;
        }

        private DiasReporte LoadDias(System.Data.IDataRecord dr)
        {
            DiasReporte o = new DiasReporte();

            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (!dr.IsDBNull(i))
                {
                    switch (dr.GetName(i))
                    {
                        case "Legajo": o.Legajo = dr.GetInt32(i); break;
                        case "Dia": o.Dia = dr.GetDateTime(i); break;
                        case "Franco": o.Franco = dr.GetString(i); break;
                        case "Entro": o.Entro = dr.GetString(i); break;
                        case "Diagr": o.Diagr = dr.GetString(i); break;
                        case "Salio": o.Salio = dr.GetString(i); break;
                    }
                }
            }

            return o;
        }

        public class DatosReporte
        {
            //public string Linea { get; set; }
            //public string DireccionLinea { get; set; }
            public Enums.Meses Mes { get; set; }
            public int? Año { get; set; }
            public string Legajo1 { get; set; }
            public string Empleado1 { get; set; }
            public DateTime? Ingreso1 { get; set; }
            public string Categoria1 { get; set; }
            //public List<DiasReporte> Dias1 { get; set; }
            public int? L1Dia1 { get; set; }
            public string L1Franco1 { get; set; }
            public string L1Entro1 { get; set; }
            public string L1Diagr1 { get; set; }
            public string L1Salio1 { get; set; }
            public int? L1Dia2 { get; set; }
            public string L1Franco2 { get; set; }
            public string L1Entro2 { get; set; }
            public string L1Diagr2 { get; set; }
            public string L1Salio2 { get; set; }
            public int? L1Dia3 { get; set; }
            public string L1Franco3 { get; set; }
            public string L1Entro3 { get; set; }
            public string L1Diagr3 { get; set; }
            public string L1Salio3 { get; set; }
            public int? L1Dia4 { get; set; }
            public string L1Franco4 { get; set; }
            public string L1Entro4 { get; set; }
            public string L1Diagr4 { get; set; }
            public string L1Salio4 { get; set; }
            public int? L1Dia5 { get; set; }
            public string L1Franco5 { get; set; }
            public string L1Entro5 { get; set; }
            public string L1Diagr5 { get; set; }
            public string L1Salio5 { get; set; }
            public int? L1Dia6 { get; set; }
            public string L1Franco6 { get; set; }
            public string L1Entro6 { get; set; }
            public string L1Diagr6 { get; set; }
            public string L1Salio6 { get; set; }
            public int? L1Dia7 { get; set; }
            public string L1Franco7 { get; set; }
            public string L1Entro7 { get; set; }
            public string L1Diagr7 { get; set; }
            public string L1Salio7 { get; set; }
            public int? L1Dia8 { get; set; }
            public string L1Franco8 { get; set; }
            public string L1Entro8 { get; set; }
            public string L1Diagr8 { get; set; }
            public string L1Salio8 { get; set; }
            public int? L1Dia9 { get; set; }
            public string L1Franco9 { get; set; }
            public string L1Entro9 { get; set; }
            public string L1Diagr9 { get; set; }
            public string L1Salio9 { get; set; }
            public int? L1Dia10 { get; set; }
            public string L1Franco10 { get; set; }
            public string L1Entro10 { get; set; }
            public string L1Diagr10 { get; set; }
            public string L1Salio10 { get; set; }
            public int? L1Dia11 { get; set; }
            public string L1Franco11 { get; set; }
            public string L1Entro11 { get; set; }
            public string L1Diagr11 { get; set; }
            public string L1Salio11 { get; set; }
            public int? L1Dia12 { get; set; }
            public string L1Franco12 { get; set; }
            public string L1Entro12 { get; set; }
            public string L1Diagr12 { get; set; }
            public string L1Salio12 { get; set; }
            public int? L1Dia13 { get; set; }
            public string L1Franco13 { get; set; }
            public string L1Entro13 { get; set; }
            public string L1Diagr13 { get; set; }
            public string L1Salio13 { get; set; }
            public int? L1Dia14 { get; set; }
            public string L1Franco14 { get; set; }
            public string L1Entro14 { get; set; }
            public string L1Diagr14 { get; set; }
            public string L1Salio14 { get; set; }
            public int? L1Dia15 { get; set; }
            public string L1Franco15 { get; set; }
            public string L1Entro15 { get; set; }
            public string L1Diagr15 { get; set; }
            public string L1Salio15 { get; set; }
            public int? L1Dia16 { get; set; }
            public string L1Franco16 { get; set; }
            public string L1Entro16 { get; set; }
            public string L1Diagr16 { get; set; }
            public string L1Salio16 { get; set; }
            public int? L1Dia17 { get; set; }
            public string L1Franco17 { get; set; }
            public string L1Entro17 { get; set; }
            public string L1Diagr17 { get; set; }
            public string L1Salio17 { get; set; }
            public int? L1Dia18 { get; set; }
            public string L1Franco18 { get; set; }
            public string L1Entro18 { get; set; }
            public string L1Diagr18 { get; set; }
            public string L1Salio18 { get; set; }
            public int? L1Dia19 { get; set; }
            public string L1Franco19 { get; set; }
            public string L1Entro19 { get; set; }
            public string L1Diagr19 { get; set; }
            public string L1Salio19 { get; set; }
            public int? L1Dia20 { get; set; }
            public string L1Franco20 { get; set; }
            public string L1Entro20 { get; set; }
            public string L1Diagr20 { get; set; }
            public string L1Salio20 { get; set; }
            public int? L1Dia21 { get; set; }
            public string L1Franco21 { get; set; }
            public string L1Entro21 { get; set; }
            public string L1Diagr21 { get; set; }
            public string L1Salio21 { get; set; }
            public int? L1Dia22 { get; set; }
            public string L1Franco22 { get; set; }
            public string L1Entro22 { get; set; }
            public string L1Diagr22 { get; set; }
            public string L1Salio22 { get; set; }
            public int? L1Dia23 { get; set; }
            public string L1Franco23 { get; set; }
            public string L1Entro23 { get; set; }
            public string L1Diagr23 { get; set; }
            public string L1Salio23 { get; set; }
            public int? L1Dia24 { get; set; }
            public string L1Franco24 { get; set; }
            public string L1Entro24 { get; set; }
            public string L1Diagr24 { get; set; }
            public string L1Salio24 { get; set; }
            public int? L1Dia25 { get; set; }
            public string L1Franco25 { get; set; }
            public string L1Entro25 { get; set; }
            public string L1Diagr25 { get; set; }
            public string L1Salio25 { get; set; }
            public int? L1Dia26 { get; set; }
            public string L1Franco26 { get; set; }
            public string L1Entro26 { get; set; }
            public string L1Diagr26 { get; set; }
            public string L1Salio26 { get; set; }
            public int? L1Dia27 { get; set; }
            public string L1Franco27 { get; set; }
            public string L1Entro27 { get; set; }
            public string L1Diagr27 { get; set; }
            public string L1Salio27 { get; set; }
            public int? L1Dia28 { get; set; }
            public string L1Franco28 { get; set; }
            public string L1Entro28 { get; set; }
            public string L1Diagr28 { get; set; }
            public string L1Salio28 { get; set; }
            public int? L1Dia29 { get; set; }
            public string L1Franco29 { get; set; }
            public string L1Entro29 { get; set; }
            public string L1Diagr29 { get; set; }
            public string L1Salio29 { get; set; }
            public int? L1Dia30 { get; set; }
            public string L1Franco30 { get; set; }
            public string L1Entro30 { get; set; }
            public string L1Diagr30 { get; set; }
            public string L1Salio30 { get; set; }
            public int? L1Dia31 { get; set; }
            public string L1Franco31 { get; set; }
            public string L1Entro31 { get; set; }
            public string L1Diagr31 { get; set; }
            public string L1Salio31 { get; set; }
            public int? CantLE1 { get; set; }
            public int? CantLO1 { get; set; }
            public int? CantF1 { get; set; }
            public int? CantO1 { get; set; }
            public string Legajo2 { get; set; }
            public string Empleado2 { get; set; }
            public DateTime? Ingreso2 { get; set; }
            public string Categoria2 { get; set; }
            //public List<DiasReporte> Dias2 { get; set; }
            public int? L2Dia1 { get; set; }
            public string L2Franco1 { get; set; }
            public string L2Entro1 { get; set; }
            public string L2Diagr1 { get; set; }
            public string L2Salio1 { get; set; }
            public int? L2Dia2 { get; set; }
            public string L2Franco2 { get; set; }
            public string L2Entro2 { get; set; }
            public string L2Diagr2 { get; set; }
            public string L2Salio2 { get; set; }
            public int? L2Dia3 { get; set; }
            public string L2Franco3 { get; set; }
            public string L2Entro3 { get; set; }
            public string L2Diagr3 { get; set; }
            public string L2Salio3 { get; set; }
            public int? L2Dia4 { get; set; }
            public string L2Franco4 { get; set; }
            public string L2Entro4 { get; set; }
            public string L2Diagr4 { get; set; }
            public string L2Salio4 { get; set; }
            public int? L2Dia5 { get; set; }
            public string L2Franco5 { get; set; }
            public string L2Entro5 { get; set; }
            public string L2Diagr5 { get; set; }
            public string L2Salio5 { get; set; }
            public int? L2Dia6 { get; set; }
            public string L2Franco6 { get; set; }
            public string L2Entro6 { get; set; }
            public string L2Diagr6 { get; set; }
            public string L2Salio6 { get; set; }
            public int? L2Dia7 { get; set; }
            public string L2Franco7 { get; set; }
            public string L2Entro7 { get; set; }
            public string L2Diagr7 { get; set; }
            public string L2Salio7 { get; set; }
            public int? L2Dia8 { get; set; }
            public string L2Franco8 { get; set; }
            public string L2Entro8 { get; set; }
            public string L2Diagr8 { get; set; }
            public string L2Salio8 { get; set; }
            public int? L2Dia9 { get; set; }
            public string L2Franco9 { get; set; }
            public string L2Entro9 { get; set; }
            public string L2Diagr9 { get; set; }
            public string L2Salio9 { get; set; }
            public int? L2Dia10 { get; set; }
            public string L2Franco10 { get; set; }
            public string L2Entro10 { get; set; }
            public string L2Diagr10 { get; set; }
            public string L2Salio10 { get; set; }
            public int? L2Dia11 { get; set; }
            public string L2Franco11 { get; set; }
            public string L2Entro11 { get; set; }
            public string L2Diagr11 { get; set; }
            public string L2Salio11 { get; set; }
            public int? L2Dia12 { get; set; }
            public string L2Franco12 { get; set; }
            public string L2Entro12 { get; set; }
            public string L2Diagr12 { get; set; }
            public string L2Salio12 { get; set; }
            public int? L2Dia13 { get; set; }
            public string L2Franco13 { get; set; }
            public string L2Entro13 { get; set; }
            public string L2Diagr13 { get; set; }
            public string L2Salio13 { get; set; }
            public int? L2Dia14 { get; set; }
            public string L2Franco14 { get; set; }
            public string L2Entro14 { get; set; }
            public string L2Diagr14 { get; set; }
            public string L2Salio14 { get; set; }
            public int? L2Dia15 { get; set; }
            public string L2Franco15 { get; set; }
            public string L2Entro15 { get; set; }
            public string L2Diagr15 { get; set; }
            public string L2Salio15 { get; set; }
            public int? L2Dia16 { get; set; }
            public string L2Franco16 { get; set; }
            public string L2Entro16 { get; set; }
            public string L2Diagr16 { get; set; }
            public string L2Salio16 { get; set; }
            public int? L2Dia17 { get; set; }
            public string L2Franco17 { get; set; }
            public string L2Entro17 { get; set; }
            public string L2Diagr17 { get; set; }
            public string L2Salio17 { get; set; }
            public int? L2Dia18 { get; set; }
            public string L2Franco18 { get; set; }
            public string L2Entro18 { get; set; }
            public string L2Diagr18 { get; set; }
            public string L2Salio18 { get; set; }
            public int? L2Dia19 { get; set; }
            public string L2Franco19 { get; set; }
            public string L2Entro19 { get; set; }
            public string L2Diagr19 { get; set; }
            public string L2Salio19 { get; set; }
            public int? L2Dia20 { get; set; }
            public string L2Franco20 { get; set; }
            public string L2Entro20 { get; set; }
            public string L2Diagr20 { get; set; }
            public string L2Salio20 { get; set; }
            public int? L2Dia21 { get; set; }
            public string L2Franco21 { get; set; }
            public string L2Entro21 { get; set; }
            public string L2Diagr21 { get; set; }
            public string L2Salio21 { get; set; }
            public int? L2Dia22 { get; set; }
            public string L2Franco22 { get; set; }
            public string L2Entro22 { get; set; }
            public string L2Diagr22 { get; set; }
            public string L2Salio22 { get; set; }
            public int? L2Dia23 { get; set; }
            public string L2Franco23 { get; set; }
            public string L2Entro23 { get; set; }
            public string L2Diagr23 { get; set; }
            public string L2Salio23 { get; set; }
            public int? L2Dia24 { get; set; }
            public string L2Franco24 { get; set; }
            public string L2Entro24 { get; set; }
            public string L2Diagr24 { get; set; }
            public string L2Salio24 { get; set; }
            public int? L2Dia25 { get; set; }
            public string L2Franco25 { get; set; }
            public string L2Entro25 { get; set; }
            public string L2Diagr25 { get; set; }
            public string L2Salio25 { get; set; }
            public int? L2Dia26 { get; set; }
            public string L2Franco26 { get; set; }
            public string L2Entro26 { get; set; }
            public string L2Diagr26 { get; set; }
            public string L2Salio26 { get; set; }
            public int? L2Dia27 { get; set; }
            public string L2Franco27 { get; set; }
            public string L2Entro27 { get; set; }
            public string L2Diagr27 { get; set; }
            public string L2Salio27 { get; set; }
            public int? L2Dia28 { get; set; }
            public string L2Franco28 { get; set; }
            public string L2Entro28 { get; set; }
            public string L2Diagr28 { get; set; }
            public string L2Salio28 { get; set; }
            public int? L2Dia29 { get; set; }
            public string L2Franco29 { get; set; }
            public string L2Entro29 { get; set; }
            public string L2Diagr29 { get; set; }
            public string L2Salio29 { get; set; }
            public int? L2Dia30 { get; set; }
            public string L2Franco30 { get; set; }
            public string L2Entro30 { get; set; }
            public string L2Diagr30 { get; set; }
            public string L2Salio30 { get; set; }
            public int? L2Dia31 { get; set; }
            public string L2Franco31 { get; set; }
            public string L2Entro31 { get; set; }
            public string L2Diagr31 { get; set; }
            public string L2Salio31 { get; set; }
            public int? CantLE2 { get; set; }
            public int? CantLO2 { get; set; }
            public int? CantF2 { get; set; }
            public int? CantO2 { get; set; }
            public string Legajo3 { get; set; }
            public string Empleado3 { get; set; }
            public DateTime? Ingreso3 { get; set; }
            public string Categoria3 { get; set; }
            //public List<DiasReporte> Dias3 { get; set; }
            public int? L3Dia1 { get; set; }
            public string L3Franco1 { get; set; }
            public string L3Entro1 { get; set; }
            public string L3Diagr1 { get; set; }
            public string L3Salio1 { get; set; }
            public int? L3Dia2 { get; set; }
            public string L3Franco2 { get; set; }
            public string L3Entro2 { get; set; }
            public string L3Diagr2 { get; set; }
            public string L3Salio2 { get; set; }
            public int? L3Dia3 { get; set; }
            public string L3Franco3 { get; set; }
            public string L3Entro3 { get; set; }
            public string L3Diagr3 { get; set; }
            public string L3Salio3 { get; set; }
            public int? L3Dia4 { get; set; }
            public string L3Franco4 { get; set; }
            public string L3Entro4 { get; set; }
            public string L3Diagr4 { get; set; }
            public string L3Salio4 { get; set; }
            public int? L3Dia5 { get; set; }
            public string L3Franco5 { get; set; }
            public string L3Entro5 { get; set; }
            public string L3Diagr5 { get; set; }
            public string L3Salio5 { get; set; }
            public int? L3Dia6 { get; set; }
            public string L3Franco6 { get; set; }
            public string L3Entro6 { get; set; }
            public string L3Diagr6 { get; set; }
            public string L3Salio6 { get; set; }
            public int? L3Dia7 { get; set; }
            public string L3Franco7 { get; set; }
            public string L3Entro7 { get; set; }
            public string L3Diagr7 { get; set; }
            public string L3Salio7 { get; set; }
            public int? L3Dia8 { get; set; }
            public string L3Franco8 { get; set; }
            public string L3Entro8 { get; set; }
            public string L3Diagr8 { get; set; }
            public string L3Salio8 { get; set; }
            public int? L3Dia9 { get; set; }
            public string L3Franco9 { get; set; }
            public string L3Entro9 { get; set; }
            public string L3Diagr9 { get; set; }
            public string L3Salio9 { get; set; }
            public int? L3Dia10 { get; set; }
            public string L3Franco10 { get; set; }
            public string L3Entro10 { get; set; }
            public string L3Diagr10 { get; set; }
            public string L3Salio10 { get; set; }
            public int? L3Dia11 { get; set; }
            public string L3Franco11 { get; set; }
            public string L3Entro11 { get; set; }
            public string L3Diagr11 { get; set; }
            public string L3Salio11 { get; set; }
            public int? L3Dia12 { get; set; }
            public string L3Franco12 { get; set; }
            public string L3Entro12 { get; set; }
            public string L3Diagr12 { get; set; }
            public string L3Salio12 { get; set; }
            public int? L3Dia13 { get; set; }
            public string L3Franco13 { get; set; }
            public string L3Entro13 { get; set; }
            public string L3Diagr13 { get; set; }
            public string L3Salio13 { get; set; }
            public int? L3Dia14 { get; set; }
            public string L3Franco14 { get; set; }
            public string L3Entro14 { get; set; }
            public string L3Diagr14 { get; set; }
            public string L3Salio14 { get; set; }
            public int? L3Dia15 { get; set; }
            public string L3Franco15 { get; set; }
            public string L3Entro15 { get; set; }
            public string L3Diagr15 { get; set; }
            public string L3Salio15 { get; set; }
            public int? L3Dia16 { get; set; }
            public string L3Franco16 { get; set; }
            public string L3Entro16 { get; set; }
            public string L3Diagr16 { get; set; }
            public string L3Salio16 { get; set; }
            public int? L3Dia17 { get; set; }
            public string L3Franco17 { get; set; }
            public string L3Entro17 { get; set; }
            public string L3Diagr17 { get; set; }
            public string L3Salio17 { get; set; }
            public int? L3Dia18 { get; set; }
            public string L3Franco18 { get; set; }
            public string L3Entro18 { get; set; }
            public string L3Diagr18 { get; set; }
            public string L3Salio18 { get; set; }
            public int? L3Dia19 { get; set; }
            public string L3Franco19 { get; set; }
            public string L3Entro19 { get; set; }
            public string L3Diagr19 { get; set; }
            public string L3Salio19 { get; set; }
            public int? L3Dia20 { get; set; }
            public string L3Franco20 { get; set; }
            public string L3Entro20 { get; set; }
            public string L3Diagr20 { get; set; }
            public string L3Salio20 { get; set; }
            public int? L3Dia21 { get; set; }
            public string L3Franco21 { get; set; }
            public string L3Entro21 { get; set; }
            public string L3Diagr21 { get; set; }
            public string L3Salio21 { get; set; }
            public int? L3Dia22 { get; set; }
            public string L3Franco22 { get; set; }
            public string L3Entro22 { get; set; }
            public string L3Diagr22 { get; set; }
            public string L3Salio22 { get; set; }
            public int? L3Dia23 { get; set; }
            public string L3Franco23 { get; set; }
            public string L3Entro23 { get; set; }
            public string L3Diagr23 { get; set; }
            public string L3Salio23 { get; set; }
            public int? L3Dia24 { get; set; }
            public string L3Franco24 { get; set; }
            public string L3Entro24 { get; set; }
            public string L3Diagr24 { get; set; }
            public string L3Salio24 { get; set; }
            public int? L3Dia25 { get; set; }
            public string L3Franco25 { get; set; }
            public string L3Entro25 { get; set; }
            public string L3Diagr25 { get; set; }
            public string L3Salio25 { get; set; }
            public int? L3Dia26 { get; set; }
            public string L3Franco26 { get; set; }
            public string L3Entro26 { get; set; }
            public string L3Diagr26 { get; set; }
            public string L3Salio26 { get; set; }
            public int? L3Dia27 { get; set; }
            public string L3Franco27 { get; set; }
            public string L3Entro27 { get; set; }
            public string L3Diagr27 { get; set; }
            public string L3Salio27 { get; set; }
            public int? L3Dia28 { get; set; }
            public string L3Franco28 { get; set; }
            public string L3Entro28 { get; set; }
            public string L3Diagr28 { get; set; }
            public string L3Salio28 { get; set; }
            public int? L3Dia29 { get; set; }
            public string L3Franco29 { get; set; }
            public string L3Entro29 { get; set; }
            public string L3Diagr29 { get; set; }
            public string L3Salio29 { get; set; }
            public int? L3Dia30 { get; set; }
            public string L3Franco30 { get; set; }
            public string L3Entro30 { get; set; }
            public string L3Diagr30 { get; set; }
            public string L3Salio30 { get; set; }
            public int? L3Dia31 { get; set; }
            public string L3Franco31 { get; set; }
            public string L3Entro31 { get; set; }
            public string L3Diagr31 { get; set; }
            public string L3Salio31 { get; set; }
            public int? CantLE3 { get; set; }
            public int? CantLO3 { get; set; }
            public int? CantF3 { get; set; }
            public int? CantO3 { get; set; }
            public string Legajo4 { get; set; }
            public string Empleado4 { get; set; }
            public DateTime? Ingreso4 { get; set; }
            public string Categoria4 { get; set; }
            //public List<DiasReporte> Dias4 { get; set; }
            public int? L4Dia1 { get; set; }
            public string L4Franco1 { get; set; }
            public string L4Entro1 { get; set; }
            public string L4Diagr1 { get; set; }
            public string L4Salio1 { get; set; }
            public int? L4Dia2 { get; set; }
            public string L4Franco2 { get; set; }
            public string L4Entro2 { get; set; }
            public string L4Diagr2 { get; set; }
            public string L4Salio2 { get; set; }
            public int? L4Dia3 { get; set; }
            public string L4Franco3 { get; set; }
            public string L4Entro3 { get; set; }
            public string L4Diagr3 { get; set; }
            public string L4Salio3 { get; set; }
            public int? L4Dia4 { get; set; }
            public string L4Franco4 { get; set; }
            public string L4Entro4 { get; set; }
            public string L4Diagr4 { get; set; }
            public string L4Salio4 { get; set; }
            public int? L4Dia5 { get; set; }
            public string L4Franco5 { get; set; }
            public string L4Entro5 { get; set; }
            public string L4Diagr5 { get; set; }
            public string L4Salio5 { get; set; }
            public int? L4Dia6 { get; set; }
            public string L4Franco6 { get; set; }
            public string L4Entro6 { get; set; }
            public string L4Diagr6 { get; set; }
            public string L4Salio6 { get; set; }
            public int? L4Dia7 { get; set; }
            public string L4Franco7 { get; set; }
            public string L4Entro7 { get; set; }
            public string L4Diagr7 { get; set; }
            public string L4Salio7 { get; set; }
            public int? L4Dia8 { get; set; }
            public string L4Franco8 { get; set; }
            public string L4Entro8 { get; set; }
            public string L4Diagr8 { get; set; }
            public string L4Salio8 { get; set; }
            public int? L4Dia9 { get; set; }
            public string L4Franco9 { get; set; }
            public string L4Entro9 { get; set; }
            public string L4Diagr9 { get; set; }
            public string L4Salio9 { get; set; }
            public int? L4Dia10 { get; set; }
            public string L4Franco10 { get; set; }
            public string L4Entro10 { get; set; }
            public string L4Diagr10 { get; set; }
            public string L4Salio10 { get; set; }
            public int? L4Dia11 { get; set; }
            public string L4Franco11 { get; set; }
            public string L4Entro11 { get; set; }
            public string L4Diagr11 { get; set; }
            public string L4Salio11 { get; set; }
            public int? L4Dia12 { get; set; }
            public string L4Franco12 { get; set; }
            public string L4Entro12 { get; set; }
            public string L4Diagr12 { get; set; }
            public string L4Salio12 { get; set; }
            public int? L4Dia13 { get; set; }
            public string L4Franco13 { get; set; }
            public string L4Entro13 { get; set; }
            public string L4Diagr13 { get; set; }
            public string L4Salio13 { get; set; }
            public int? L4Dia14 { get; set; }
            public string L4Franco14 { get; set; }
            public string L4Entro14 { get; set; }
            public string L4Diagr14 { get; set; }
            public string L4Salio14 { get; set; }
            public int? L4Dia15 { get; set; }
            public string L4Franco15 { get; set; }
            public string L4Entro15 { get; set; }
            public string L4Diagr15 { get; set; }
            public string L4Salio15 { get; set; }
            public int? L4Dia16 { get; set; }
            public string L4Franco16 { get; set; }
            public string L4Entro16 { get; set; }
            public string L4Diagr16 { get; set; }
            public string L4Salio16 { get; set; }
            public int? L4Dia17 { get; set; }
            public string L4Franco17 { get; set; }
            public string L4Entro17 { get; set; }
            public string L4Diagr17 { get; set; }
            public string L4Salio17 { get; set; }
            public int? L4Dia18 { get; set; }
            public string L4Franco18 { get; set; }
            public string L4Entro18 { get; set; }
            public string L4Diagr18 { get; set; }
            public string L4Salio18 { get; set; }
            public int? L4Dia19 { get; set; }
            public string L4Franco19 { get; set; }
            public string L4Entro19 { get; set; }
            public string L4Diagr19 { get; set; }
            public string L4Salio19 { get; set; }
            public int? L4Dia20 { get; set; }
            public string L4Franco20 { get; set; }
            public string L4Entro20 { get; set; }
            public string L4Diagr20 { get; set; }
            public string L4Salio20 { get; set; }
            public int? L4Dia21 { get; set; }
            public string L4Franco21 { get; set; }
            public string L4Entro21 { get; set; }
            public string L4Diagr21 { get; set; }
            public string L4Salio21 { get; set; }
            public int? L4Dia22 { get; set; }
            public string L4Franco22 { get; set; }
            public string L4Entro22 { get; set; }
            public string L4Diagr22 { get; set; }
            public string L4Salio22 { get; set; }
            public int? L4Dia23 { get; set; }
            public string L4Franco23 { get; set; }
            public string L4Entro23 { get; set; }
            public string L4Diagr23 { get; set; }
            public string L4Salio23 { get; set; }
            public int? L4Dia24 { get; set; }
            public string L4Franco24 { get; set; }
            public string L4Entro24 { get; set; }
            public string L4Diagr24 { get; set; }
            public string L4Salio24 { get; set; }
            public int? L4Dia25 { get; set; }
            public string L4Franco25 { get; set; }
            public string L4Entro25 { get; set; }
            public string L4Diagr25 { get; set; }
            public string L4Salio25 { get; set; }
            public int? L4Dia26 { get; set; }
            public string L4Franco26 { get; set; }
            public string L4Entro26 { get; set; }
            public string L4Diagr26 { get; set; }
            public string L4Salio26 { get; set; }
            public int? L4Dia27 { get; set; }
            public string L4Franco27 { get; set; }
            public string L4Entro27 { get; set; }
            public string L4Diagr27 { get; set; }
            public string L4Salio27 { get; set; }
            public int? L4Dia28 { get; set; }
            public string L4Franco28 { get; set; }
            public string L4Entro28 { get; set; }
            public string L4Diagr28 { get; set; }
            public string L4Salio28 { get; set; }
            public int? L4Dia29 { get; set; }
            public string L4Franco29 { get; set; }
            public string L4Entro29 { get; set; }
            public string L4Diagr29 { get; set; }
            public string L4Salio29 { get; set; }
            public int? L4Dia30 { get; set; }
            public string L4Franco30 { get; set; }
            public string L4Entro30 { get; set; }
            public string L4Diagr30 { get; set; }
            public string L4Salio30 { get; set; }
            public int? L4Dia31 { get; set; }
            public string L4Franco31 { get; set; }
            public string L4Entro31 { get; set; }
            public string L4Diagr31 { get; set; }
            public string L4Salio31 { get; set; }
            public int? CantLE4 { get; set; }
            public int? CantLO4 { get; set; }
            public int? CantF4 { get; set; }
            public int? CantO4 { get; set; }
            public string Legajo5 { get; set; }
            public string Empleado5 { get; set; }
            public DateTime? Ingreso5 { get; set; }
            public string Categoria5 { get; set; }
            //public List<DiasReporte> Dias5 { get; set; }
            public int? L5Dia1 { get; set; }
            public string L5Franco1 { get; set; }
            public string L5Entro1 { get; set; }
            public string L5Diagr1 { get; set; }
            public string L5Salio1 { get; set; }
            public int? L5Dia2 { get; set; }
            public string L5Franco2 { get; set; }
            public string L5Entro2 { get; set; }
            public string L5Diagr2 { get; set; }
            public string L5Salio2 { get; set; }
            public int? L5Dia3 { get; set; }
            public string L5Franco3 { get; set; }
            public string L5Entro3 { get; set; }
            public string L5Diagr3 { get; set; }
            public string L5Salio3 { get; set; }
            public int? L5Dia4 { get; set; }
            public string L5Franco4 { get; set; }
            public string L5Entro4 { get; set; }
            public string L5Diagr4 { get; set; }
            public string L5Salio4 { get; set; }
            public int? L5Dia5 { get; set; }
            public string L5Franco5 { get; set; }
            public string L5Entro5 { get; set; }
            public string L5Diagr5 { get; set; }
            public string L5Salio5 { get; set; }
            public int? L5Dia6 { get; set; }
            public string L5Franco6 { get; set; }
            public string L5Entro6 { get; set; }
            public string L5Diagr6 { get; set; }
            public string L5Salio6 { get; set; }
            public int? L5Dia7 { get; set; }
            public string L5Franco7 { get; set; }
            public string L5Entro7 { get; set; }
            public string L5Diagr7 { get; set; }
            public string L5Salio7 { get; set; }
            public int? L5Dia8 { get; set; }
            public string L5Franco8 { get; set; }
            public string L5Entro8 { get; set; }
            public string L5Diagr8 { get; set; }
            public string L5Salio8 { get; set; }
            public int? L5Dia9 { get; set; }
            public string L5Franco9 { get; set; }
            public string L5Entro9 { get; set; }
            public string L5Diagr9 { get; set; }
            public string L5Salio9 { get; set; }
            public int? L5Dia10 { get; set; }
            public string L5Franco10 { get; set; }
            public string L5Entro10 { get; set; }
            public string L5Diagr10 { get; set; }
            public string L5Salio10 { get; set; }
            public int? L5Dia11 { get; set; }
            public string L5Franco11 { get; set; }
            public string L5Entro11 { get; set; }
            public string L5Diagr11 { get; set; }
            public string L5Salio11 { get; set; }
            public int? L5Dia12 { get; set; }
            public string L5Franco12 { get; set; }
            public string L5Entro12 { get; set; }
            public string L5Diagr12 { get; set; }
            public string L5Salio12 { get; set; }
            public int? L5Dia13 { get; set; }
            public string L5Franco13 { get; set; }
            public string L5Entro13 { get; set; }
            public string L5Diagr13 { get; set; }
            public string L5Salio13 { get; set; }
            public int? L5Dia14 { get; set; }
            public string L5Franco14 { get; set; }
            public string L5Entro14 { get; set; }
            public string L5Diagr14 { get; set; }
            public string L5Salio14 { get; set; }
            public int? L5Dia15 { get; set; }
            public string L5Franco15 { get; set; }
            public string L5Entro15 { get; set; }
            public string L5Diagr15 { get; set; }
            public string L5Salio15 { get; set; }
            public int? L5Dia16 { get; set; }
            public string L5Franco16 { get; set; }
            public string L5Entro16 { get; set; }
            public string L5Diagr16 { get; set; }
            public string L5Salio16 { get; set; }
            public int? L5Dia17 { get; set; }
            public string L5Franco17 { get; set; }
            public string L5Entro17 { get; set; }
            public string L5Diagr17 { get; set; }
            public string L5Salio17 { get; set; }
            public int? L5Dia18 { get; set; }
            public string L5Franco18 { get; set; }
            public string L5Entro18 { get; set; }
            public string L5Diagr18 { get; set; }
            public string L5Salio18 { get; set; }
            public int? L5Dia19 { get; set; }
            public string L5Franco19 { get; set; }
            public string L5Entro19 { get; set; }
            public string L5Diagr19 { get; set; }
            public string L5Salio19 { get; set; }
            public int? L5Dia20 { get; set; }
            public string L5Franco20 { get; set; }
            public string L5Entro20 { get; set; }
            public string L5Diagr20 { get; set; }
            public string L5Salio20 { get; set; }
            public int? L5Dia21 { get; set; }
            public string L5Franco21 { get; set; }
            public string L5Entro21 { get; set; }
            public string L5Diagr21 { get; set; }
            public string L5Salio21 { get; set; }
            public int? L5Dia22 { get; set; }
            public string L5Franco22 { get; set; }
            public string L5Entro22 { get; set; }
            public string L5Diagr22 { get; set; }
            public string L5Salio22 { get; set; }
            public int? L5Dia23 { get; set; }
            public string L5Franco23 { get; set; }
            public string L5Entro23 { get; set; }
            public string L5Diagr23 { get; set; }
            public string L5Salio23 { get; set; }
            public int? L5Dia24 { get; set; }
            public string L5Franco24 { get; set; }
            public string L5Entro24 { get; set; }
            public string L5Diagr24 { get; set; }
            public string L5Salio24 { get; set; }
            public int? L5Dia25 { get; set; }
            public string L5Franco25 { get; set; }
            public string L5Entro25 { get; set; }
            public string L5Diagr25 { get; set; }
            public string L5Salio25 { get; set; }
            public int? L5Dia26 { get; set; }
            public string L5Franco26 { get; set; }
            public string L5Entro26 { get; set; }
            public string L5Diagr26 { get; set; }
            public string L5Salio26 { get; set; }
            public int? L5Dia27 { get; set; }
            public string L5Franco27 { get; set; }
            public string L5Entro27 { get; set; }
            public string L5Diagr27 { get; set; }
            public string L5Salio27 { get; set; }
            public int? L5Dia28 { get; set; }
            public string L5Franco28 { get; set; }
            public string L5Entro28 { get; set; }
            public string L5Diagr28 { get; set; }
            public string L5Salio28 { get; set; }
            public int? L5Dia29 { get; set; }
            public string L5Franco29 { get; set; }
            public string L5Entro29 { get; set; }
            public string L5Diagr29 { get; set; }
            public string L5Salio29 { get; set; }
            public int? L5Dia30 { get; set; }
            public string L5Franco30 { get; set; }
            public string L5Entro30 { get; set; }
            public string L5Diagr30 { get; set; }
            public string L5Salio30 { get; set; }
            public int? L5Dia31 { get; set; }
            public string L5Franco31 { get; set; }
            public string L5Entro31 { get; set; }
            public string L5Diagr31 { get; set; }
            public string L5Salio31 { get; set; }
            public int? CantLE5 { get; set; }
            public int? CantLO5 { get; set; }
            public int? CantF5 { get; set; }
            public int? CantO5 { get; set; }
            public string Legajo6 { get; set; }
            public string Empleado6 { get; set; }
            public DateTime? Ingreso6 { get; set; }
            public string Categoria6 { get; set; }
            //public List<DiasReporte> Dias6 { get; set; }
            public int? L6Dia1 { get; set; }
            public string L6Franco1 { get; set; }
            public string L6Entro1 { get; set; }
            public string L6Diagr1 { get; set; }
            public string L6Salio1 { get; set; }
            public int? L6Dia2 { get; set; }
            public string L6Franco2 { get; set; }
            public string L6Entro2 { get; set; }
            public string L6Diagr2 { get; set; }
            public string L6Salio2 { get; set; }
            public int? L6Dia3 { get; set; }
            public string L6Franco3 { get; set; }
            public string L6Entro3 { get; set; }
            public string L6Diagr3 { get; set; }
            public string L6Salio3 { get; set; }
            public int? L6Dia4 { get; set; }
            public string L6Franco4 { get; set; }
            public string L6Entro4 { get; set; }
            public string L6Diagr4 { get; set; }
            public string L6Salio4 { get; set; }
            public int? L6Dia5 { get; set; }
            public string L6Franco5 { get; set; }
            public string L6Entro5 { get; set; }
            public string L6Diagr5 { get; set; }
            public string L6Salio5 { get; set; }
            public int? L6Dia6 { get; set; }
            public string L6Franco6 { get; set; }
            public string L6Entro6 { get; set; }
            public string L6Diagr6 { get; set; }
            public string L6Salio6 { get; set; }
            public int? L6Dia7 { get; set; }
            public string L6Franco7 { get; set; }
            public string L6Entro7 { get; set; }
            public string L6Diagr7 { get; set; }
            public string L6Salio7 { get; set; }
            public int? L6Dia8 { get; set; }
            public string L6Franco8 { get; set; }
            public string L6Entro8 { get; set; }
            public string L6Diagr8 { get; set; }
            public string L6Salio8 { get; set; }
            public int? L6Dia9 { get; set; }
            public string L6Franco9 { get; set; }
            public string L6Entro9 { get; set; }
            public string L6Diagr9 { get; set; }
            public string L6Salio9 { get; set; }
            public int? L6Dia10 { get; set; }
            public string L6Franco10 { get; set; }
            public string L6Entro10 { get; set; }
            public string L6Diagr10 { get; set; }
            public string L6Salio10 { get; set; }
            public int? L6Dia11 { get; set; }
            public string L6Franco11 { get; set; }
            public string L6Entro11 { get; set; }
            public string L6Diagr11 { get; set; }
            public string L6Salio11 { get; set; }
            public int? L6Dia12 { get; set; }
            public string L6Franco12 { get; set; }
            public string L6Entro12 { get; set; }
            public string L6Diagr12 { get; set; }
            public string L6Salio12 { get; set; }
            public int? L6Dia13 { get; set; }
            public string L6Franco13 { get; set; }
            public string L6Entro13 { get; set; }
            public string L6Diagr13 { get; set; }
            public string L6Salio13 { get; set; }
            public int? L6Dia14 { get; set; }
            public string L6Franco14 { get; set; }
            public string L6Entro14 { get; set; }
            public string L6Diagr14 { get; set; }
            public string L6Salio14 { get; set; }
            public int? L6Dia15 { get; set; }
            public string L6Franco15 { get; set; }
            public string L6Entro15 { get; set; }
            public string L6Diagr15 { get; set; }
            public string L6Salio15 { get; set; }
            public int? L6Dia16 { get; set; }
            public string L6Franco16 { get; set; }
            public string L6Entro16 { get; set; }
            public string L6Diagr16 { get; set; }
            public string L6Salio16 { get; set; }
            public int? L6Dia17 { get; set; }
            public string L6Franco17 { get; set; }
            public string L6Entro17 { get; set; }
            public string L6Diagr17 { get; set; }
            public string L6Salio17 { get; set; }
            public int? L6Dia18 { get; set; }
            public string L6Franco18 { get; set; }
            public string L6Entro18 { get; set; }
            public string L6Diagr18 { get; set; }
            public string L6Salio18 { get; set; }
            public int? L6Dia19 { get; set; }
            public string L6Franco19 { get; set; }
            public string L6Entro19 { get; set; }
            public string L6Diagr19 { get; set; }
            public string L6Salio19 { get; set; }
            public int? L6Dia20 { get; set; }
            public string L6Franco20 { get; set; }
            public string L6Entro20 { get; set; }
            public string L6Diagr20 { get; set; }
            public string L6Salio20 { get; set; }
            public int? L6Dia21 { get; set; }
            public string L6Franco21 { get; set; }
            public string L6Entro21 { get; set; }
            public string L6Diagr21 { get; set; }
            public string L6Salio21 { get; set; }
            public int? L6Dia22 { get; set; }
            public string L6Franco22 { get; set; }
            public string L6Entro22 { get; set; }
            public string L6Diagr22 { get; set; }
            public string L6Salio22 { get; set; }
            public int? L6Dia23 { get; set; }
            public string L6Franco23 { get; set; }
            public string L6Entro23 { get; set; }
            public string L6Diagr23 { get; set; }
            public string L6Salio23 { get; set; }
            public int? L6Dia24 { get; set; }
            public string L6Franco24 { get; set; }
            public string L6Entro24 { get; set; }
            public string L6Diagr24 { get; set; }
            public string L6Salio24 { get; set; }
            public int? L6Dia25 { get; set; }
            public string L6Franco25 { get; set; }
            public string L6Entro25 { get; set; }
            public string L6Diagr25 { get; set; }
            public string L6Salio25 { get; set; }
            public int? L6Dia26 { get; set; }
            public string L6Franco26 { get; set; }
            public string L6Entro26 { get; set; }
            public string L6Diagr26 { get; set; }
            public string L6Salio26 { get; set; }
            public int? L6Dia27 { get; set; }
            public string L6Franco27 { get; set; }
            public string L6Entro27 { get; set; }
            public string L6Diagr27 { get; set; }
            public string L6Salio27 { get; set; }
            public int? L6Dia28 { get; set; }
            public string L6Franco28 { get; set; }
            public string L6Entro28 { get; set; }
            public string L6Diagr28 { get; set; }
            public string L6Salio28 { get; set; }
            public int? L6Dia29 { get; set; }
            public string L6Franco29 { get; set; }
            public string L6Entro29 { get; set; }
            public string L6Diagr29 { get; set; }
            public string L6Salio29 { get; set; }
            public int? L6Dia30 { get; set; }
            public string L6Franco30 { get; set; }
            public string L6Entro30 { get; set; }
            public string L6Diagr30 { get; set; }
            public string L6Salio30 { get; set; }
            public int? L6Dia31 { get; set; }
            public string L6Franco31 { get; set; }
            public string L6Entro31 { get; set; }
            public string L6Diagr31 { get; set; }
            public string L6Salio31 { get; set; }
            public int? CantLE6 { get; set; }
            public int? CantLO6 { get; set; }
            public int? CantF6 { get; set; }
            public int? CantO6 { get; set; }
        }

        public class DiasReporte
        {
            public int Legajo { get; set; }
            public DateTime Dia { get; set; }
            public string Franco { get; set; }
            public string Entro { get; set; }
            public string Diagr { get; set; }
            public string Salio { get; set; }
        }

        public class Legajos
        {
            public int Legajo { get; set; }
            public string Empleado { get; set; }
            public DateTime Ingreso { get; set; }
            public string Categoria { get; set; }
            public string Cuit { get; set; }
        }
    }
}
