namespace VENET_Common
{
    using System.Collections.Generic;

    public interface IForm
    {
        void IdSeleccionado(int Id);
        void IdsSeleccionados(List<int> Ids);
    }
}
