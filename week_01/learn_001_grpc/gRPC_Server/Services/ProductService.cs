using Grpc.Core;

namespace gRPC_Server.Services;

public class ProductService : ProductHandler.ProductHandlerBase
{
    // This is instead of actually adding a database to seek information from.
    // Simplified from "new List<Product> {products}" to "[products]"
    private List<Product> _products =
    [
        // Simplified from "new Product" to "new()"
        new() { Id = 1, Name = "Product 1", Price = 100 },
        new() { Id = 1, Name = "Product 2", Price = 200 },
        new() { Id = 1, Name = "Product 3", Price = 300 }
    ];
    
    public override Task<GetProductsReply> GetProducts(GetProductsRequest request, ServerCallContext context)
    {
        var reply = new GetProductsReply();
        reply.Products.AddRange(_products);
        
        return Task.FromResult(reply);
    }
}