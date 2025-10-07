using System.Reflection.Metadata;
using Microsoft.VisualBasic;

namespace cadeteria
{
    public class Pedidos
    {
        private int nro;
        private string obs;
        private Cliente infClientes;

        private Cadetes cadeteAsignado;

        public enum Estados
        {
            Pendiente,
            EnProceso,
            Entregado
        };
        private Estados estado;
        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        public Estados Estado { get => estado; set => estado = value; }
        public Cliente InfClientes { get => infClientes; set => infClientes = value; }
        public Cadetes CadeteAsignado { get => cadeteAsignado; set => cadeteAsignado = value; }

        public Pedidos()
        { 
            
        }
        public Pedidos(int nro, string obs, Cliente infClientes, Cadetes cadeteAsignado)
        {
            this.Nro = nro;
            this.Obs = obs;
            this.InfClientes = infClientes;
            estado = Estados.Pendiente;
            this.CadeteAsignado = cadeteAsignado;
        }

        public void AsignarCadete(Cadetes cadete)
        {
            estado = Estados.EnProceso;
            CadeteAsignado = cadete;
        }
    }
}