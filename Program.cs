using CamionesBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using CamionesBackEnd.Services.Contrato;
using CamionesBackEnd.Services.Implementacion;

//"Server=DESKTOP-P7SSU03;Database=Camiones;Trusted_Connection=True;TrustServerCertificate=True"



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CamionesContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddScoped<ICargaService, CargaService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IGastoService, GastoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IViajeService, ViajeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#region Peticiones
app.MapGet("carga/lista",async(
    ICargaService _cargaServicio
    )=>
    {
        var listaCarga = await _cargaServicio.GetCargaList();
    });
#endregion

app.Run();
