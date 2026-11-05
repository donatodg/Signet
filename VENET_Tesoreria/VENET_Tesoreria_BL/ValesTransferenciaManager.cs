namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using VENET_DataEntity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using VENET_Common;

    public class ValesTransferenciaManager
    {
        public ValeTransferencia ValeTrans { get; set; }

        public ValesTransferenciaManager()
        {
            ValeTrans = new ValeTransferencia();
            ValeTrans.PropertyChanged += new PropertyChangedEventHandler(PropertyChanged);
        }

        public List<Sistema.CajasList> CajasDestino
        {
            get
            {
                if (ValeTrans.Id_CajaOrigen == 0) return new List<Sistema.CajasList>();
                else
                    using (GeneralContext db = new GeneralContext())
                    {

                        int IdEmpresa = (from c in db.Cajas
                                         join s in db.Sucursales on c.Id_Sucursal equals s.Id into listSuc
                                         from suc in listSuc
                                         where c.Id == ValeTrans.Id_CajaOrigen
                                         select suc.Id_Empresa).FirstOrDefault();

                        int IdEspecie = (from c in db.Cajas
                                         where c.Id == ValeTrans.Id_CajaOrigen
                                         select c.Id_Especie).FirstOrDefault();

                        return (from c in db.Cajas
                                join s in db.Sucursales on c.Id_Sucursal equals s.Id into listSuc
                                from suc in listSuc
                                join e in db.Empresas on suc.Id_Empresa equals e.Id into listEmp
                                from emp in listEmp
                                join es in db.Especies on c.Id_Especie equals es.Id into listEsp
                                from esp in listEsp
                                where c.UserDel == null &&
                                      suc.UserDel == null &&
                                      esp.UserDel == null &&
                                      suc.Id_Empresa == IdEmpresa &&
                                      c.Id_Especie == IdEspecie &&
                                      c.Id != ValeTrans.Id_CajaOrigen
                                select new Sistema.CajasList
                                {
                                    Id_Caja = c.Id,
                                    Caja = c.Descripcion,
                                    Empresa = emp.Nombre,
                                    Especie = esp.Descripcion,
                                    Sucursal = suc.Descripcion
                                }).OrderByDescending(t => t.Empresa).ToList();
                    }
            }
        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Id_CajaOrigen")
                CargaListaVales();
        }

        private void CargaListaVales()
        {
            if (ValeTrans.Id_CajaOrigen != 0)
            {
                using (var db = new TesoreriaContext())
                {
                    ValeTrans.Vales = (from v in db.Vales
                                       join p in db.Personal on v.Id_Personal equals p.Id into listPer
                                       from per in listPer
                                       where v.UserDel == null &&
                                             v.Id_Rendicion == 0 &&
                                             v.FechaAnulacion == null &&
                                             v.FechaConfirmacion != null &&
                                             v.Id_Caja == ValeTrans.Id_CajaOrigen
                                       select new ListaVales()
                                       {
                                           Id = v.Id,
                                           Descripción = v.Descripcion,
                                           Fecha = v.Fecha,
                                           Id_Personal = v.Id_Personal,
                                           Legajo = per.LaboralLegajo,
                                           Numero = v.Numero,
                                           Personal = per.Apellido + ", " + per.Nombre,
                                           Seleccionado = false
                                       }).ToList();
                }
            }
            else
                ValeTrans.Vales = new List<ListaVales>();
        }

        public void Save()
        {
            if (ValeTrans.Id_CajaOrigen == 0)
                throw new ValidationException("Debe seleccionar una caja de origen");

            if (ValeTrans.Id_CajaDestino == 0)
                throw new ValidationException("Debe seleccionar una caja de destino");

            if (ValeTrans.Id_CajaOrigen == ValeTrans.Id_CajaDestino)
                throw new ValidationException("La caja de origen es igual a la de destino");

            using (var db = new TesoreriaContext())
            {
                foreach (ListaVales o in ValeTrans.Vales.Where(t => t.Seleccionado == true))
                {
                    Vales v = db.Vales.Find(o.Id);
                    db.Entry(v).State = EntityState.Modified;

                    v.Id_Caja = ValeTrans.Id_CajaDestino;
                }

                db.SaveChanges();
            }
        }

    }

    public class ValeTransferencia : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _Id_CajaOrigen;
        public int Id_CajaOrigen
        {
            get { return _Id_CajaOrigen; }
            set
            {
                _Id_CajaOrigen = value;
                RaisePropertyChanged("Id_CajaOrigen");
            }
        }
        private int _Id_CajaDestino;
        public int Id_CajaDestino
        {
            get { return _Id_CajaDestino; }
            set
            {
                _Id_CajaDestino = value;
                //RaisePropertyChanged("Id_CajaDestino");
            }
        }
        public List<ListaVales> Vales { get; set; }
    }

    public class ListaVales
    {
        public bool Seleccionado { get; set; }
        public int Id { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public int Id_Personal { get; set; }
        public string Personal { get; set; }
        public int? Legajo { get; set; }
        public string Descripción { get; set; }

    }

}
