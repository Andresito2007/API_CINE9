using Api_Cine9.Models;

namespace Api_Cine9.Repository;

// CONTRATO DEL REPOSITORIO PARA EL SERVICIO : SOLO ACCESO A  MANUPILAR DATOS DE LA BD
public interface ITicketRepository
{
    List<Ticket> ObtenerTodos();
    Ticket? ObtenerPorId(int id);
    void Agregar(Ticket ticket);
    void Eliminar(Ticket ticket);
}
