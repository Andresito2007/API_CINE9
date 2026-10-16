using Api_Cine9.Middleware;
using Api_Cine9.Repository;
using Api_Cine9.Services;

// CREAMOS NUESTRO APP
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// REGISTRAMOS EL REPOSITORIO , CUANDO ALGUIEN PIDA ITICKETREPOSITORY LE DAMOS TICKETREPOSITORY (INYECCION DE DEPENDENCIAS)
builder.Services.AddSingleton<ITicketRepository, TicketRepository>();

// REGISTRAMOS EL SERVICIO , CUANDO ALGUIEN PIDA ITICKETSERVICE LE DAMOS TICKETSERVICE (INYECCION DE DEPENDENCIAS)
builder.Services.AddSingleton<ITicketService, TicketService>();

// REGISTRAMOS NUESTRO MANEJADORES DE ERRORES
builder.Services.AddExceptionHandler<ManejadorExcepciones>();
builder.Services.AddProblemDetails();

var app = builder.Build();


// ACTIVA EL MIDDLEWARE DE ERRORES PA QUE VAYA PRIMERO PA ATRAPAR LOS ERRORES DE TODO LO QUE VIENE DESPUES
app.UseExceptionHandler();

app.UseHttpsRedirection(); // REDIRIGE DE HTTP A HTTPS

app.UseAuthorization();

app.MapControllers();

// LEVANTAMOS NUESTRO SERVIDOR
app.Run();
