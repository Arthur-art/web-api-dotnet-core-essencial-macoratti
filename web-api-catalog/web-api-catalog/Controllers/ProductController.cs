using Microsoft.AspNetCore.Mvc;
using web_api_catalog.Context;

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
    public IActionResult Get()
    {

        var products = _context.products.ToList();
        if (products == null || !products.Any())
        {
            return NotFound("No products found.");
        }
        return Ok(products);
    }
}
