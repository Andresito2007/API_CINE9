using Api_Cine9.Dtos;
using Api_Cine9.Models;
using Api_Cine9.Services;
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
    
    [HttpGet]
    public ActionResult<List<Ticket>> ObtenerTodos()
    {
        return Ok(_service.ObtenerTodos());
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

        return NoContent();
    }
}
