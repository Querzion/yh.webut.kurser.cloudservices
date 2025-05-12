using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApi.Models;

namespace ServerApi.Controllers;

/* https://localhost:7171/api/Products */
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private static readonly List<ProductRequest> _products = [];

    /*
        POST https://localhost:7171/api/Products HTTP/1.1
        Content-Type: application/json
        Body: { "name " : "Acer Aspire GO 14", "price " : 3999.00 }
    */
    [HttpPost]
    public IActionResult Create(ProductRequest req)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        _products.Add(req);
        return Ok(new { message = "Product added successfully" });
    }

    /*
        GET https://localhost:7171/api/Products HTTP/1.1
        Content-Type: application/json
        Body: [{ "id" : "u09e87u0-e9oa-9u9e-0o82-u092u4k9euo3", "name" : "Acer Aspire GO 14", "price" : 3999.00 }]
    */
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_products);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var product = _products.FirstOrDefault(x => x.Id == id);
        return product != null 
            ? Ok(product) 
            : NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, ProductRequest req)
    {
        var product = _products.FirstOrDefault(x => x.Id == id);
        if (product == null)
            return NotFound();
        
        product.Name = req.Name;
        product.Price = req.Price;
        
        return Ok(product);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var product = _products.FirstOrDefault(x => x.Id == id);
        if (product == null)
            return NotFound();

        _products.Remove(product);
        
        return Ok(_products);
    }
}