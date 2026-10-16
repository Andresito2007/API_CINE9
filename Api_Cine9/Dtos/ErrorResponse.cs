namespace Api_Cine9.Dtos;

// PARA MAPEAR LO QUE QUIERES QUE TENGA LAS RESPUESTAS DE ERROR ( DTO DE SALIDA PARA EL MIDDLEWARW)
public class ErrorResponse
{
    public int Estado { get; set; }
    public string Error { get; set; } = "";
    public string Mensaje { get; set; } = "";
    public string Ruta { get; set; } = "";
    public DateTime Fecha { get; set; } = DateTime.Now;

    // CUANDO HAY FALLAS EN LAS VALIDACIONES DE LOS CAMPOS
    public Dictionary<string, string[]>? Errores { get; set; }
}
