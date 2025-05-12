using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClientApp;

var productRequest = new ProductRequest();

Console.Write("Enter Product Name: ");
productRequest.Name = Console.ReadLine()!;

Console.Write("Enter Product Price: ");
productRequest.Price = decimal.Parse(Console.ReadLine()!);

using var http = new HttpClient();
var result = await http.PostAsJsonAsync("https://localhost:7140/api/products/", productRequest);

Console.WriteLine("\n");
// using var http = new HttpClient();
var readResult = await http.GetFromJsonAsync<IEnumerable<ProductResponse>>("https://localhost:7140/api/products");

foreach (var product in readResult!)
{
    Console.WriteLine($"{product.Id} - {product.Name} ({product.Price} SEK)");
}

Console.ReadKey();


