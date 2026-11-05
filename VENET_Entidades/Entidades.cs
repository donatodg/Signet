namespace VENET_Entidades
{
    using System;
    using System.Windows.Forms;
    //using VENET_Common;
    //using VENET_Comun;
    //using VENET_DataEntity;

    public sealed class Entidades
    {
        public static int CrearEntidad(int TipoEntidad, Form frm)
        //public static int CrearEntidad(Enums.TipoEntidad TipoEntidad, Form frm)
        {
            try
            {
                int Id_Entidad = 0;

                //switch (TipoEntidad)
                //{
                //case Enums.TipoEntidad.Cliente:
                //    Clientes c = new Clientes();
                //VENET_Clientes_UI.frmClientes_AddMod f1 = new VENET_Clientes_UI.frmClientes_AddMod(c);
                //    if (f1.ShowDialog(frm) == DialogResult.OK)
                //        Id_Entidad = c.Id;
                //    f1.Dispose();
                //    break;
                //case Enums.TipoEntidad.Personal:
                //    Personal p = new Personal();
                //    VENET_Personal_UI.frmPersonal_AddMod f2 = new VENET_Personal_UI.frmPersonal_AddMod(p);
                //    if (f2.ShowDialog(frm) == DialogResult.OK)
                //        Id_Entidad = p.Id;
                //    f2.Dispose();
                //    break;
                //case Enums.TipoEntidad.Proveedor:
                //    Proveedores pr = new Proveedores();
                //    VENET_Proveedores_UI.frmProveedores_AddMod f3 = new VENET_Proveedores_UI.frmProveedores_AddMod(pr);
                //    if (f3.ShowDialog(frm) == DialogResult.OK)
                //        Id_Entidad = pr.Id;
                //    f3.Dispose();
                //    break;
                //case Enums.TipoEntidad.Proveedor_Financiero:
                //    ProvFinancieros pf = new ProvFinancieros();
                //    VENET_ProvFinancieros_UI.frmProvFinancieros_AddMod f4 = new VENET_ProvFinancieros_UI.frmProvFinancieros_AddMod(pf);
                //    if (f4.ShowDialog(frm) == DialogResult.OK)
                //        Id_Entidad = pf.Id;
                //    f4.Dispose();
                //    break;
                //}

                return Id_Entidad;
            }
            catch (Exception ex)
            {
                //Sistema.MensajeError(ex);
                return 0;
            }
        }

    }
}
