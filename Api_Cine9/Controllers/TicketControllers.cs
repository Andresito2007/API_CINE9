using Api_Cine9.Dtos;
using Api_Cine9.Models;
using Api_Cine9.Services;
// (Controllerbase) USAMOS PARA USAR LOS METODOS DE ASPNETCORE PARA NUESTRO CONTROLADOR
using Microsoft.AspNetCore.Mvc;

namespace Api_Cine9.Controllers;

[ApiController]
[Route("api/tickets")]

// HEREDARA LOS METODOS DEL CONTROLBASE
public class TicketsController : ControllerBase
{
    private ITicketService _service; 
    
    public TicketsController(ITicketService service)
    {
        _service = service;
    }

    // ACCTIONRESULT ES LA REPRESENTACION DE LA RESPUES HTTP DE NUESTRO METODO
    [HttpGet]
    public ActionResult<List<Ticket>> ObtenerTodos()
    {
        return Ok(_service.ObtenerTodos()); // ok=200
    }

    [HttpGet("{id}")]
    public ActionResult<Ticket> ObtenerPorId(int id)
    {
        return Ok(_service.ObtenerPorId(id));
    }

    [HttpPost]

    public ActionResult<Ticket> Crear(TicketRequestDto dto)
    {
        Ticket creado = _service.Crear(dto);
        // RETORNAMOS NUESTRO METODO PARA POST ( 201 INDICANDO QUE SE CREO UN RECURSO)
        return CreatedAtAction("ObtenerPorId", new { id = creado.Id }, creado); 
    }

    [HttpPut("{id}")]
    public ActionResult<Ticket> Actualizar(int id, TicketRequestDto dto)
    {
        return Ok(_service.Actualizar(id, dto));
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        _service.Eliminar(id);

        // RETORNA 204 , SALIO BIEN PERO NO RETORNA NADA
        return NoContent();
    }
}
