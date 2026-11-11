using Api_Cine9.Middleware;
using Api_Cine9.Repository;
using Api_Cine9.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


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

app.Run();
