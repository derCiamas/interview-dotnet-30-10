var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IProductService, ProductService>();

var app = builder.Build();

app.MapGet("/products/{id:int}", async (
    int id,
    IProductService service,
    CancellationToken cancellationToken) =>
{
    var product = await service.GetAsync(id, cancellationToken);

    return product is null
        ? Results.NotFound()
        : Results.Ok(product);
});

app.Run();
