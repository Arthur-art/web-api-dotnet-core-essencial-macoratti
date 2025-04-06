using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api_catalog.Context;
using web_api_catalog.Models;

namespace web_api_catalog.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{

    public readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("api/[controller]/listcategories")]
    public async Task<ActionResult<IEnumerable<Category>>> GetAsync()
    {
        var categories = await _context.categories.AsNoTracking().ToListAsync();
        
        if(categories is null)
        {
            return NotFound("Categories is not found");
        }

        return Ok(categories);
    }

    [HttpGet("api/[controller]/listcategoriebyid/{id:int}")]
    public ActionResult GetById(int id)
    {
        var category = _context.categories.AsNoTracking().FirstOrDefault(x => x.CategoryId == id);

        if(category is null)
        {
            return NotFound("Category is not found");
        }

        return Ok(category);
    }

    [HttpGet("api/[controller]/listproductsbycategoryid/{id:int}")]
    public ActionResult<IEnumerable<Category>> GetProductsByCategoryId(int id)
    {
        var category = _context.categories.AsNoTracking().FirstOrDefault(x => x.CategoryId == id);
        var products = _context.categories.Include(x => x.Products).AsNoTracking().FirstOrDefault(x => x.CategoryId == id);

        if (category is null)
        {
            return NotFound("Category is not found");
        }

        return Ok(products);
    }

    [HttpPost("api/[controller]/addcategory")]
    public ActionResult Create([FromBody] CategoryDto category)
    {
        if(category is null)
        {
            return BadRequest();
        }

        var categoryPayload = new Category(category.Nome, category.ImagemUrl);

        _context.categories.Add(categoryPayload);
        _context.SaveChanges();

        return Ok(category);
    }

    [HttpPut("api/[controller]/updatecategory/{id:int}")]
    public ActionResult Update([FromBody] Category category, int id)
    {
        var categoryExist = _context.categories.AsNoTracking().FirstOrDefault(x => x.CategoryId == id);

        if (categoryExist is null)
        {
            return NotFound("Category is not found");
        }

        _context.Attach(category);
        _context.Update(category);
        _context.SaveChanges();

        return Ok(category);
    }

    [HttpDelete("api/[controller]/deletecategory/{id:int}")]
    public ActionResult Delete(int id)
    {
        var categoryExist = _context.categories.FirstOrDefault(x => x.CategoryId == id);

        if (categoryExist is null)
        {
            return NotFound("Category is not found");
        }

        _context.categories.Remove(categoryExist);
        _context.SaveChanges();

        return Ok(categoryExist);
    }
}
