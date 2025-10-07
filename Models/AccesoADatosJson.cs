using System.Text.Json;
namespace cadeteria
{
    public class AccesoADatosJSON : IAccesoADatos
    {
        private string _ruta;
        public AccesoADatosJSON(string RutaArchivo)
        {
            _ruta = RutaArchivo;
        }
        public Cadeteria CargarCadetes()
    {
        if (!File.Exists(_ruta))
        {
            Console.WriteLine("No se encontró el archivo JSON");
            return null;
        }

        string json = File.ReadAllText(_ruta);

        Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return cadeteria;
    }
        public void CargarCadeteria(Cadeteria cadeteria)
        {
            string json = JsonSerializer.Serialize(cadeteria, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_ruta, json);

            Console.WriteLine("Datos guardados correctamente en JSON.");
        }
    }
}