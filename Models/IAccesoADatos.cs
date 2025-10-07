using System.ComponentModel;

namespace cadeteria
{
    public interface IAccesoADatos
    {
        Cadeteria CargarCadetes();
        void CargarCadeteria(Cadeteria Cadeteria);
    }

}
