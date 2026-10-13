namespace Api_Cine9.Exceptions;

// ERROR 409 CONFLICTO  , SI HAY UN CONFLICTO DE DATOS COMO UN ID DE TICKET QUE YA EXISTE
public class ConflictoException : Exception
{
    public ConflictoException(string mensaje) : base(mensaje) { }
}