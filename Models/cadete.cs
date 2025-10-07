namespace cadeteria
{
    public class Cadetes
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public Cadetes()
        { 
            
        }
        
        public Cadetes(int id, string nombre, string direccion, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
        }

        
    }
}