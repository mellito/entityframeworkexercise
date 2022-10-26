global using Microsoft.EntityFrameworkCore;
using proyectoef.Models;
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

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext)=>{
    return Results.Ok(dbContext.Tareas.Include(p=>p.Categoria));
    //.Where(p=> p.PrioridadTarea == proyectoef.Models.Prioridad.media)
});

app.MapGet("/api/tareas/{id}", async ([FromServices] TareasContext dbContext,[FromRoute] Guid id)=>{
    var TareaActual = dbContext.Tareas.Find(id);
    if(TareaActual!=null){
        return Results.Ok(TareaActual);
    }
    return Results.NotFound();
  
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea)=>{
    tarea.TareaId= Guid.NewGuid();
    tarea.estado=false;
    tarea.FechaCreacion=DateTime.Now;
    await dbContext.AddAsync(tarea);
    // await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Ok("Tarea guardada correctamente");
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id)=>{
    var TareaActual = dbContext.Tareas.Find(id);

    if(TareaActual != null) {
        TareaActual.CategoriaId= tarea.CategoriaId;
        TareaActual.Titulo=tarea.Titulo;
        TareaActual.PrioridadTarea=tarea.PrioridadTarea;
        TareaActual.Descripcion=tarea.Descripcion;
        await dbContext.SaveChangesAsync();
        return Results.Ok("Tarea Actualizada correctamente");
    }
    return Results.NotFound();
 
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id)=>{
    
    var TareaActual = dbContext.Tareas.Find(id);

    if(TareaActual != null) {
        dbContext.Remove(TareaActual);
        await dbContext.SaveChangesAsync();
        return Results.Ok("Tarea removida correctamente");
    }
    return Results.NotFound();
 
});

app.Run();
