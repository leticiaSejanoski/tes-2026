
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

var agenda = new List<Contato>();


app.MapPost("/contatos", (Contato c) =>
    {
        agenda.Add(c);
        return "contato adicionado!";
    });

app.MapGet("/listarTodos", () => agenda);

app.MapGet("/buscar/{nome}", (string nome) =>{
    foreach(var c in agenda){
        if(c.Nome.ToLower() == nome.ToLower()){
            return Results.Ok(c);
        }
    }
        return Results.NotFound ("Contato não encontrado!");
});

app.Run();
  
public class Contato{
    public string Nome {get; set;}
    public string Telefone {get; set;}

}
