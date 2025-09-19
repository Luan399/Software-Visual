using API.Models;
using Microsoft.AspNetCore.Mvc;  // Importar esse namespace para usar [FromBody] e [FromRoute]

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> produtos = new List<Produto>()
{
    new Produto { Nome = "Caneta", Preco = 1.50, Quantidade = 100 },
    // new Produto { Nome = "Caderno", Preco = 15.00, Quantidade = 50 },
    // new Produto { Nome = "Mochila", Preco = 120.00, Quantidade = 20 },
    // new Produto { Nome = "Lápis", Preco = 0.80, Quantidade = 200 },
    // new Produto { Nome = "Borracha", Preco = 2.00, Quantidade = 75 }
};

app.MapGet("/", () => "API de Produtos");

app.MapGet("/api/produto/listar", () =>
{
    if (produtos.Count == 0)
    {
        return Results.BadRequest("Não tem itens cadastrados");
    }
    return Results.Ok(produtos);
});

// Método POST corrigido com [FromBody]
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto) =>
{
    foreach (Produto produtoCadastrado in produtos)
    {
        if (produtoCadastrado.Nome == produto.Nome)
        {
            return Results.Conflict("Produto já cadastrado");
        }
    }
    produtos.Add(produto);
    return Results.Created("", produto);
});

// Método GET corrigido com [FromRoute]
app.MapGet("/api/produto/buscar/{nome}", ([FromRoute] string nome) =>
{
    Produto? produto = produtos.FirstOrDefault(p => p.Nome == nome);
    if (produto == null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    return Results.Ok(produto);
});

app.MapDelete("/api/produto/remover/{id}", ([FromRoute] string id) =>
{
    Produto? resultado = produtos.FirstOrDefault(p => p.Id == id);  // Usando 'Id' para buscar
    if (resultado == null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    produtos.Remove(resultado);
    return Results.Ok(resultado);  // Retorna o produto removido
});

app.MapPatch("/api/produto/alterar/{id}", ([FromRoute] string id ,[FromBody]Produto produtoAlterado) =>
{
    Produto? resultado = produtos.FirstOrDefault(p => p.Id == id);  // Usando 'Id' para buscar
    if (resultado == null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    resultado.Nome = produtoAlterado.Nome;
    resultado.Quantidade = produtoAlterado.Quantidade;
    resultado.Preco = produtoAlterado.Preco;

    return Results.Ok(resultado);  // Retorna o produto removido
});





app.Run();







