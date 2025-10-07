namespace cadeteria
{
    public class AccesoADatosCSV : IAccesoADatos
    {
        private string _ruta;
        public AccesoADatosCSV(string RutaArchivo)
        {
            _ruta = RutaArchivo;
        }
        public Cadeteria CargarCadetes()
        {
            
            
            Cadeteria _cadeteria = new Cadeteria();
            if (File.Exists(_ruta))
            {

                string[] lineas = File.ReadAllLines(_ruta);
                string[] cadeteriaData = File.ReadAllLines(_ruta);
                for (int i = 1; i < lineas.Length; i++)
                {
                    string[] datos = lineas[i].Split(';');

                    int id = int.Parse(datos[0]);
                    string nombre = datos[1];
                    string direccion = datos[2];
                    string telefono = datos[3];

                    Cadetes cadete = new Cadetes(id, nombre, direccion, telefono);

                    _cadeteria.ListadoCadetes.Add(cadete);
                }
            }
            else
            {
                Console.WriteLine("El archivo CSV de cadetes no existe.");
            }

            return _cadeteria;
        }

        public void CargarCadeteria(Cadeteria cadeteria)
        {
            Console.WriteLine("El csv solo lectura");
        }
    }

}
