using System.Data.Common;

namespace cadeteria
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadetes> listadoCadetes = new List<Cadetes>();
        private List<Pedidos> listadoPedidos = new List<Pedidos>();


        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Cadetes> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
        public List<Pedidos> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        public Pedidos TomarPedido(string nombre, string direccion, string telefono, string referenciaDireccion, string observacion)

        {
            int numero = listadoPedidos.Max(p => p.Nro) + 1;
            Cadetes cadete = null;
            Cliente cliente = new Cliente(nombre, direccion, telefono, referenciaDireccion);

            return new Pedidos(numero, observacion, cliente, cadete);

        }


        public int AsignarPedido(int idCadete, int idPedido)
        {
            Cadetes cadete = ListadoCadetes.FirstOrDefault(c => c.Id == idCadete);
            Pedidos pedido = ListadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
            if (cadete != null && pedido != null)
            {
                pedido.AsignarCadete(cadete);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public string DarDeAlta(Pedidos pedido)
        {
            ListadoPedidos.Add(pedido);
            return "Pedido completado sin asignar pedido";
           
        }

        public string CambiarDeEstado(List<Pedidos> pedidos, int idPedido, int cambiarEstado)
        {

            var pedido = pedidos.FirstOrDefault(p => p.Nro == idPedido);
            if (pedido != null)
            {
                if (Enum.IsDefined(typeof(Pedidos.Estados), cambiarEstado))
                {
                    pedido.Estado = (Pedidos.Estados)cambiarEstado;
                    return "El pedido de id:" + idPedido + "cambio correctamente su estado";
                }
                else
                {
                    return "El estado ingresado es invalido";
                }
            }
            else
            {
                return "El id ingresado no fue encontrado" ;
            }
        }
        public string AsignarPedidos(List<Pedidos> pedidos, List<Cadetes> listaCadetes, Cadeteria cadeteria, int idPedido, int idCadete)

        {

            if (pedidos.Where(p => p.Estado == Pedidos.Estados.Pendiente).Count() > 0)
            {
                int opcion = cadeteria.AsignarPedido(idCadete, idPedido);

                if (opcion == 0)
                {
                    return "Numero de cadete o pedido invalido.";
                }

                return "El pedido fue asignado con exito";
            }
            else
            {
                return "No hay pedidos pendientes para asignar";
            }

        }

        public string ReasignarPedido(List<Cadetes> cadetes, List<Pedidos> pedidos, Cadeteria cadeteria, int idCadete, int idPedido)
        {
            if (pedidos.Where(p => p.Estado == Pedidos.Estados.EnProceso).Count() > 0)
            {
                int numeroAreasignar = cadeteria.AsignarPedido(idCadete, idPedido);

                if (numeroAreasignar == 0)
                {
                    return "Numero de cadete o pedido invalido.";
                }

                return "El pedido fue reasignado con exito";
            }
            else
            {
                return "No hay pedidos en curso para reasignar";
            }

        }

        
        
         private int CantEntregasCadete(int idCadete)
        {
            return ListadoPedidos
            .Where(p => p.CadeteAsignado.Id == idCadete && p.Estado == Pedidos.Estados.Entregado)
            .Count();


        }


        public int JornalACobrar(int idCadete)
        {
            int monto = CantEntregasCadete(idCadete) * 500;
            return monto;
        }
        public string InformeJornada()
{
    int enviosTotal = 0, montoGanado = 0, cantCadetes = 0;
    float enviosPromedio = 0;

    enviosTotal = ListadoPedidos
        .Where(p => p.Estado == Pedidos.Estados.Entregado)
        .Count();

    montoGanado = enviosTotal * 500;

    cantCadetes = ListadoCadetes.Count();

    
    if (cantCadetes > 0)
    {
        
        enviosPromedio = enviosTotal / cantCadetes;
    }
    else
    {
        enviosPromedio = 0;
    }

    
    string informe = "";
    informe += "Informe de jornada\n";
    informe += "== Detalle cadetes ==\n";
    informe += "ID|      Nombre      | Envios | Monto ganado\n";

    foreach (var cadete in ListadoCadetes)
    {
        informe += cadete.Nombre + " | "
                 + CantEntregasCadete(cadete.Id) + " | "
                 + JornalACobrar(cadete.Id) + "\n";
    }

    informe += "Monto total ganado: $" + montoGanado + "\n";
    informe += "Cantidad de envios:\n";
    informe += string.Format("- Promedio por cadete: {0:0.0000}\n", enviosPromedio);
    informe += "- Total: " + enviosTotal + "\n";

    return informe;
}

    }
}
    
