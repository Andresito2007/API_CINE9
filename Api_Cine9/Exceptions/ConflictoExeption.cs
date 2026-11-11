namespace Api_Cine9.Exceptions;

// ERROR 409 CONFLICTO 
public class ConflictoException : Exception
{
    public ConflictoException(string mensaje) : base(mensaje) { }
}
