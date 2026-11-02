namespace Api_Cine9.Models;

public class Cliente
{
    public int Id { get; set; } // GET Y SET  (ENCAPSULANMIENTO)
    public string Nombre { get; set; } = "";
    public string Dni { get; set; } = "";
    public string Email { get; set; } = "";
    
    public Cliente() { }

    public Cliente(int id, string nombre, string dni, string email)
    {
        Id = id;
        Nombre = nombre;
        Dni = dni;
        Email = email;
    }
}
