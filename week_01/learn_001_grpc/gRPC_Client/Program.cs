using gRPC_Client;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("https://localhost:7109");
var greeterClient = new Greeter.GreeterClient(channel);
var productClient = new ProductHandler.ProductHandlerClient(channel);

Console.WriteLine("Press any key to continue.");
Console.ReadKey();

var helloReply = await greeterClient.SayHelloAsync(new HelloRequest { Name = "Slisk" });
Console.WriteLine($"Response: {helloReply.Message}");
Console.ReadKey();

var fullNameReply = await greeterClient.GetFullNameAsync(new FullNameRequest { FirstName = "Slisk", LastName = "Lindqvist" });
Console.WriteLine($"Response: {fullNameReply.FullName}");
Console.ReadKey();

const string currency = "KR";
var productsReply = await productClient.GetProductsAsync( new GetProductsRequest() );
foreach (var product in productsReply.Products)
    Console.WriteLine($"{product.Id} {product.Name} ({product.Price} {currency})");
Console.ReadKey();