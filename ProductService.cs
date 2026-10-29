public sealed record Product(int Id, string Name, decimal Price);

public interface IProductService
{
    Task<Product?> GetAsync(int id, CancellationToken cancellationToken);
}

public sealed class ProductService : IProductService
{
    private static readonly IReadOnlyDictionary<int, Product> Products =
        new Dictionary<int, Product>
        {
            [1] = new(1, "Keyboard", 199.00m),
            [2] = new(2, "Mouse", 89.00m)
        };

    public Task<Product?> GetAsync(int id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        Products.TryGetValue(id, out var product);
        return Task.FromResult(product);
    }
}
