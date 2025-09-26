namespace cadeteria
{
    public class AccesoADatosCSV : IAccesoADatos
    {
        public List<Cadetes> CargarCadetes(string ruta)
        {
            var listadoCadetes = new List<Cadetes>();
            int telAux;

            if (File.Exists(ruta))
            {
                string[] lineas = File.ReadAllLines(ruta);
                for (int i = 1; i < lineas.Length; i++)
                {
                    string[] datos = lineas[i].Split(';');

                    int id = int.Parse(datos[0]);
                    string nombre = datos[1];
                    string direccion = datos[2];
                    string telefono = datos[3];
                    int.TryParse(telefono, out telAux);

                    Cadetes cadete = new Cadetes(id, nombre, direccion, telAux);
                    listadoCadetes.Add(cadete);
                }
            }
            else
            {
                Console.WriteLine("El archivo CSV de cadetes no existe.");
            }

            return listadoCadetes;
        }

        public Cadeteria CargarCadeteria(string ruta)
        {
            Cadeteria cadeteria = new Cadeteria();

            if (File.Exists(ruta))
            {
                string[] lineas = File.ReadAllLines(ruta);
                for (int i = 1; i < lineas.Length; i++)
                {
                    string[] datos = lineas[i].Split(';');
                    cadeteria.Nombre = datos[0];
                    cadeteria.Telefono = datos[1];
                }
            }
            else
            {
                Console.WriteLine("El archivo CSV de cadetería no existe.");
            }

            return cadeteria;
        }
    }

}
