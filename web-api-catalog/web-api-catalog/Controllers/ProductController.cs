using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api_catalog.Context;
using web_api_catalog.Models;

namespace web_api_catalog.Controllers;

public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context; 
    }

    [HttpGet]
    [Route("api/[controller]")]
    public ActionResult<IEnumerable<Product>> Get()
    {

        var products = _context.products.ToList();
        if (products == null || !products.Any())
        {
            return NotFound("No products found.");
        }
        return products;
    }

    [HttpGet]
    [Route("api/[controller]/{id:int}", Name = "Product")]
    public ActionResult<Product> Get(int id)
    {
        var product = _context.products.FirstOrDefault( x=> x.ProductId == id);
        if (product == null) {
            return NotFound("Product is not found");
        }
        return product;
    }

    [HttpPost]
    [Route("api/[controller]/add/product")]
    public ActionResult Post(Product product)
    {
        if (product is null)
        {
            return BadRequest();
        }

        _context.products.Add(product);
        _context.SaveChanges();

        return new CreatedAtRouteResult("Product", new {id = product.ProductId}, product);
    }
}
