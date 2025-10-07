using Microsoft.AspNetCore.Mvc;

namespace cadeteria.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CadeteriaController : ControllerBase
{
    private readonly IAccesoADatos _accesoDatos;
    private Cadeteria _cadeteria;

    public CadeteriaController()
    {
        _accesoDatos = new AccesoADatosJSON("Archivos/Cadetes.json");
        _cadeteria = _accesoDatos.CargarCadetes();
    }

    [HttpGet("ObtenerPedidos")]
    public IActionResult GetPedidos()
    {
        return Ok(_cadeteria.ListadoPedidos);
    }

    [HttpGet("ObtenerCadetes")]
    public IActionResult GetCadetes()
    {  
        return Ok(_cadeteria);
    }

    [HttpGet("ObtenerInforme")]
    public IActionResult GetInforme()
    {
        return Ok(_cadeteria.InformeJornada());
    }

    [HttpPost("AgregarPedido")]
    public IActionResult AgregarPedido(Pedidos pedido)
    {
        
        _cadeteria.DarDeAlta(pedido);
        _accesoDatos.CargarCadeteria(_cadeteria);
        return Ok(pedido);
    }

    [HttpPut("AsignarPedidos")]
    public IActionResult Put(int IdPedido, int IdCadete)
    {
        
        return Ok(_cadeteria.AsignarPedido(IdCadete, IdPedido));
    }

    [HttpPut("CambiarEstado")]

    public IActionResult PutCambiarEstado(int IdPedido, int CambiarDeEstado)
    {

        return Ok(_cadeteria.CambiarDeEstado(_cadeteria.ListadoPedidos, IdPedido, CambiarDeEstado));
    }
    
    [HttpPut("CambiarCadete")]
    public IActionResult PutCambiarCadete(int IdPedido,int IdCadete)
    {
        return Ok(_cadeteria.ReasignarPedido(_cadeteria.ListadoCadetes, _cadeteria.ListadoPedidos, _cadeteria, IdCadete, IdPedido));
    }
}
