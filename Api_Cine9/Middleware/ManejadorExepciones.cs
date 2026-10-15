using Api_Cine9.Dtos;
using Api_Cine9.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Api_Cine9.Middleware;

// ( GUARDIAN ) MANEJADOR CENTRALIZADO DE ERRORES , TODA EXCEPCION QUE SE LANCE EN EL CONTROLADOR O SERVICIO LLEGA AQUI PARA NO PONER TRY/CATCH EN CADA METODO
// IMPLEMENTAMOS LA INTERFAZ IEXCEPTIONHANDLER
public class ManejadorExcepciones : IExceptionHandler
{
    // ILOGGER PA ESCRIBIR MENSAJES EN CONSOLA Y SE INYECTA SOLO
    private ILogger<ManejadorExcepciones> _logger; 
    
    // INYECCION DE DEPENDENCIAS 
    public ManejadorExcepciones(ILogger<ManejadorExcepciones> logger)
    {
        _logger = logger;
    }
    // ASYNC PORQUE PUEDE HABER MUCHOS ERRORES AL MISMO TIEMPO PARA NO BLOQUEAR EL CURSO
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        int estado;
        string error;
        string mensaje = exception.Message;

        // SEGUN EL TIPO DE EXCEPCION ELEGIMOS EL CODIGO HTTP
        switch (exception)
        {
            case NoEncontradoException:
                estado = StatusCodes.Status404NotFound;
                error = "NO ENCONTRADO ESTIMADO APICINITO";
                break;
            case ReglaNegocioException:
                estado = StatusCodes.Status400BadRequest;
                error = "SOLICITID INVALIDA ESTIMADO APICINITO";
                break;
            case ConflictoException:
                estado = StatusCodes.Status409Conflict;
                error = "CONFLICTO ENCONTRADO ESTIMADO APICINITO";
                break;
            default:
                // POR SI HAY UN BUG DEL MISMO SERVIDOR , LO GUARDAMOS EN EL LOG PA NOSOTROS
                _logger.LogError(exception, "OCURRIO UN BUG ESTIMADO APICINITO");
                estado = StatusCodes.Status500InternalServerError;
                error = "ERROR INTERNO";
                mensaje = "OCURRIO UN ERROR INSEPERADO APICNITO , INTENTALO MAS TARDE";
                break;
        }

        // ARMAMOS LA RESPUESTA CON NUESTRO DTO DE SALIDA
        ErrorResponse respuesta = new ErrorResponse
        {
            Estado = estado,
            Error = error,
            Mensaje = mensaje,
            Ruta = context.Request.Path
        };
        // LE PONEMOS EL CODIGO HTTP Y LA MANDAMOS COMO JSON
        context.Response.StatusCode = estado;
        await context.Response.WriteAsJsonAsync(respuesta, cancellationToken);
        return true;
    }
}
