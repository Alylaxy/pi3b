using AcheASaida.Endpoints;
using AcheASaida.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureServices();

// Add configuration
builder.Configuration.AddConfigurations();

var app = builder.Build();
app.ConfigureMiddlewares();
app.RegistrarGrupoEndpoints();
app.RegistrarLabirintoEndpoints();

app.Run();