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
        public string Obs { get => obs; set => obs = value; }
        public int Nro { get => nro; set => nro = value; }
        public Estados Estado { get => estado; set => estado = value; }
        public Cliente InfClientes { get => infClientes; set => infClientes = value; }
        public Cadetes CadeteAsignado { get => cadeteAsignado; set => cadeteAsignado = value; }

        public Pedidos(int numero, string observacion, Cliente cliente, Cadetes cadete)
    {
        this.Nro = numero;
        this.Obs = observacion;
        this.InfClientes = cliente;
        estado = Estados.Pendiente;
        this.CadeteAsignado = cadete;
    }

        public string verDireccionCliente(Cliente Informacion)
        {
            string DireccionCliente = Informacion.Direccion;
            string nombreCliente = Informacion.Nombre;
            string mensaje = "La direccion del cliente" + nombreCliente + "es" + DireccionCliente;
            return mensaje;
        }


        public string verDatosClientes(Cliente Informacion)
        {
            string datos = "";
            datos += "Los datos del cliente son:\n";
            datos += "/////////////////////////\n";
            datos += "Nombre: " + Informacion.Nombre + "\n";
            datos += "Direccion: " + Informacion.Direccion + "\n";
            datos += "Telefono: " + Informacion.Telefono + "\n";

            return datos;
        }


        public string MostrarPedido()
        {
            string NombreCadete;
            string retorno;
            if (CadeteAsignado == null)
            {
                NombreCadete = "No asignado";
            }else
            {
                NombreCadete = CadeteAsignado.Nombre;
            }
            Console.WriteLine("Su pedido es:");
            retorno = Nro + "/" + estado + "/" + InfClientes.Nombre + "/" + InfClientes.Direccion + "/" + NombreCadete;

            return retorno;

        }
        public void AsignarCadete(Cadetes cadete)
        {
            estado = Estados.EnProceso;
            CadeteAsignado = cadete;
        }
    }
}