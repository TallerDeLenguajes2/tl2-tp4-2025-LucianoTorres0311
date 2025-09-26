namespace cadeteria
{
    public class Cadetes
    {
        private int id;
        private string nombre;
        private string direccion;
        private int telefono;
        

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        
        public Cadetes(int id, string nombre, string direccion, int telefono)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }

        
    }
}