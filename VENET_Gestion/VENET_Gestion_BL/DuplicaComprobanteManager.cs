namespace VENET_Gestion_BL
{
    using System.Collections.Generic;
    using VENET_Common;
    using VENET_Comun;

    public class DuplicaComprobanteManager
    {
        public DuplicaComprobanteManager()
        {

        }

        public List<KeyNamePair> Entidades(Enums.TipoEntidad Id_TipoEntidad)
        {
            return Sistema.ObtenerEntidades(Id_TipoEntidad);
        }

    }
}
