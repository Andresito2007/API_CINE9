namespace Api_Cine9.Exceptions;

// ERROR 400 REGLA DE NEGOCIO SI SE ROMPE ALGUNA REGLA DE NEGOCIO COMO UN ASIENTO YA VENDIDO
public class ReglaNegocioException : Exception
{
    public ReglaNegocioException(string mensaje) : base(mensaje) { }
}
