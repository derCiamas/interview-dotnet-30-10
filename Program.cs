var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IProductService, ProductService>();

var app = builder.Build();

app.MapGet("/products/{id:int}", async (
    int id,
    IProductService service,
    CancellationToken cancellationToken) =>
{
    try
    {
        var product = await service.GetAsync(id, cancellationToken);
        return Results.Ok(product);
    }
    catch (Exception)
    {
        return Results.BadRequest();
    }
});

app.Run();
