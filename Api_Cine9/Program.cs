using Api_Cine9.Middleware;
using Api_Cine9.Repository;
using Api_Cine9.Services;

// CREAMOS NUESTRO APP
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// REGISTRAMOS EL REPOSITORIO , CUANDO ALGUIEN PIDA ITICKETREPOSITORY LE DAMOS TICKETREPOSITORY (INYECCION DE DEPENDENCIAS)
builder.Services.AddSingleton<ITicketRepository, TicketRepository>();

builder.Services.AddSingleton<ITicketService, TicketService>();

// .NET USARA NUESTRA CLASE CUANDO OCURRA UNA EXCEPCION
builder.Services.AddExceptionHandler<ManejadorExcepciones>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// LEVANTAMO SERVIDOR
app.Run();
