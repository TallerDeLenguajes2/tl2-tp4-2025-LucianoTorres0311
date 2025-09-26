using System.Text.Json;
namespace cadeteria
{
    public class AccesoADatosJSON : IAccesoADatos
    {
        public List<Cadetes> CargarCadetes(string ruta)
        {
            if (!File.Exists(ruta))
            {
                Console.WriteLine("El archivo JSON de cadetes no existe.");
                return new List<Cadetes>();
            }

            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<Cadetes>>(json) ?? new List<Cadetes>();
        }

        public Cadeteria CargarCadeteria(string ruta)
        {
            if (!File.Exists(ruta))
            {
                Console.WriteLine("El archivo JSON de cadetería no existe.");
                return new Cadeteria();
            }

            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<Cadeteria>(json) ?? new Cadeteria();
        }
    }


}