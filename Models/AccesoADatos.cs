namespace cadeteria
{
    public interface IAccesoADatos
    {
        List<Cadetes> CargarCadetes(string ruta);
        Cadeteria CargarCadeteria(string ruta);
    }

}
