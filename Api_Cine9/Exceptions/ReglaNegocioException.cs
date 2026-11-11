namespace Api_Cine9.Exceptions;

// ERROR 400 REGLA DE NEGOCIO 
public class ReglaNegocioException : Exception
{
    public ReglaNegocioException(string mensaje) : base(mensaje) { }
}
