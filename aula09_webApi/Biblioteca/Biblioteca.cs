

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

var biblioteca = new List<Livro>();


app.MapPost("/adicionarlivro", (Livro l) =>
    {
        biblioteca.Add(l);
        return "Livro adicionado!";
    });

app.MapGet("/listartodos", () => biblioteca);

app.MapGet("/buscar/{titulo}", (string titulo) => 
{
    foreach(var l in biblioteca){
        if(l.Titulo.ToLower() == titulo.ToLower()){
            return Results.Ok(l);
        }
    }
        return Results.NotFound ("Livro não encontrado!");
});

app.MapGet("/buscardisponiveis", () =>
{
    var disponiveis = new List<Livro>();

    foreach (var l in biblioteca)
    {
        if (l.Disponivel)
        {
            disponiveis.Add(l);
        }
    }

    return disponiveis;
});

app.MapPut("/emprestar/{titulo}", (string titulo) =>
{
    foreach (var l in biblioteca)
    {
        if (l.Titulo.ToLower() == titulo.ToLower())
        {
            return l.Emprestar();
        }
    }

    return "Livro não encontrado!";
});

app.MapPut("/devolver/{titulo}", (string titulo) =>
{
    foreach (var l in biblioteca)
    {
        if (l.Titulo.ToLower() == titulo.ToLower())
        {
            return l.Devolver();
        }
    }

    return "Livro não encontrado!";
});

app.Run();

public class Livro{
    public string Titulo {get; set;}
    public int Ano {get; set;}
    public bool Disponivel {get; set;}

    public string Emprestar(){
        if(Disponivel){
            Disponivel = false;
            return "Livro emprestado!";
        }
        return "Livro não disponível para empréstimo!";
    }

     public string Devolver(){
            Disponivel = true;
            return "Livro devolvido!";
        }
}