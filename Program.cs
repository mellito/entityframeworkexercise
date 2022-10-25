global using  System.ComponentModel.DataAnnotations;
global using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using proyectoef;


var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<TareasContext>(options => options.UseInMemoryDatabase("TareasDB")); conectar a una base de datos en memoria
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("TareasConnection"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => {
    dbContext.Database.EnsureCreated(); // asegura que la base de datos esta creada, si no esta creada la crea
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.Run();
