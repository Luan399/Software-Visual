using API.Models;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> produtos = new List<Produto>()
    {
        new Produto { Nome = "Caneta", Preco = 1.50, Quantidade = 100 },
        new Produto { Nome = "Caderno", Preco = 15.00, Quantidade = 50 },
        new Produto { Nome = "Mochila", Preco = 120.00, Quantidade = 20 },
        new Produto { Nome = "Lápis", Preco = 0.80, Quantidade = 200 },
        new Produto { Nome = "Borracha", Preco = 2.00, Quantidade = 75 }
    };

app.MapGet("/", () => "API de Produtos");

app.MapGet("/api/produto/listar", () =>
{
    return produtos;
});
app.MapPost("/api/produto/cadastrar", (Produto produto) =>
{
   
produtos.Add(produto);  
   
});

app.Run();







