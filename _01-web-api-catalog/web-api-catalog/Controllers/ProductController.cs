﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api_catalog.Context;
using web_api_catalog.Filters;
using web_api_catalog.Models;

namespace web_api_catalog.Controllers;

[ApiController]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context; 
    }

    [HttpGet]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ApiLoggingFilter))]
    public ActionResult<IEnumerable<Product>> Get([FromQuery]int pageSize = 0)
    {

        try
        {
            var products = _context.products.Take(pageSize).AsNoTracking().ToList();
            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }
            return products;
        }
        catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno");
        }
    }

    [HttpGet]
    [Route("api/[controller]/{id:int}", Name = "Product")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _context.products.AsNoTracking().FirstOrDefault( x=> x.ProductId == id);
        if (product == null) {
            return NotFound("Product is not found");
        }
        return product;
    }

    [HttpPost]
    [Route("api/[controller]/add/product")]
    public ActionResult Post([FromBody] ProductDto product)
    {
        if (product is null)
        {
            return BadRequest();
        }

        var productPayload = new Product(
              product.ProductId,
              product.Name,
              product.Description,
              product.Price,
              product.ImageUrl,
              product.Rating,
              product.DateOfRegistration,
              product.CategoryId
            );

        _context.products.Add(productPayload);
        _context.SaveChanges();

        return new CreatedAtRouteResult("Product", new {id = product.ProductId}, product);
    }

    [HttpPut("api/[controller]/update/product/{id:int}")]
    public ActionResult Put([FromRoute] int id, [FromBody]Product product) 
    {
        var productExist = _context.products.AsNoTracking().FirstOrDefault(x => x.ProductId == id);

        if(productExist == null)
        {
            return BadRequest("Product is not found");
        }

        _context.Attach(product);
        _context.Update(product);
        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete("api/[controller]/delete/product/{id:int}")]
    public ActionResult Delete(int id)
    {
        var productExist = _context.products.FirstOrDefault(x => x.ProductId == id);

        if(productExist is null)
        {
            return NotFound("Product is not found");
        }

        _context.products.Remove(productExist);
        _context.SaveChanges();

        return Ok("Product is deleted");
    }
}
