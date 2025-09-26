namespace cadeteria
{
    public class Informe
    {
        public int EnviosTotales { get; set; }
        public int MontoGanado { get; set; }
        public float EnviosPromedio { get; set; }
        public List<InformeCadete> DetalleCadetes { get; set; } = new List<InformeCadete>();
    }

    public class InformeCadete
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Envios { get; set; }
        public int MontoGanado { get; set; }
    }
}
