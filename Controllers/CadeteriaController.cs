using Microsoft.AspNetCore.Mvc;

namespace cadeteria.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CadeteriaController : ControllerBase
{
    private Cadeteria cadeteria = new Cadeteria();
    private AccesoADatos
    [HttpGet]
    public List<Pedidos> GetPedidos(string nombre, string direccion, string telefono, string referenciaDireccion, string observacion)
    {
        var pedido = cadeteria.TomarPedido(nombre, direccion, telefono, referenciaDireccion, observacion);
        return cadeteria.DarDeAlta(pedido);
    }

    [HttpGet]
    public List<Cadetes> GetCadetes()
    {
        
    }

    [HttpGet]
    public Informe GetInforme()
    {
        return new Informe();
    }

    [HttpPost]
    public List<Pedidos> PostAgregarPedido(Pedidos pedido)
    {
        List<Pedidos> ListaPedidos = new List<Pedidos>();
        ListaPedidos.Add(pedido);
        return ListaPedidos;
    }

    [HttpPut]
    public List<Cadetes> PutAsignarPedido()
    { 

    }
    
}
