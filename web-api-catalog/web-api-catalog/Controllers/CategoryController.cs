﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api_catalog.Context;
using web_api_catalog.Models;

namespace web_api_catalog.Controllers;
public class CategoryController : ControllerBase
{

    public readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("api/[controller]/listcategories")]
    public ActionResult Get()
    {
        var categories = _context.categories.ToList();
        
        if(categories is null)
        {
            return NotFound("Categories is not found");
        }

        return Ok(categories);
    }

    [HttpGet("api/[controller]/listcategoriebyid/{id:int}")]
    public ActionResult GetById(int id)
    {
        var category = _context.categories.FirstOrDefault(x => x.CategoryId == id);

        if(category is null)
        {
            return NotFound("Category is not found");
        }

        return Ok(category);
    }

    [HttpPost("api/[controller]/addcategory")]
    public ActionResult Create([FromBody] Category category)
    {
        if(category is null)
        {
            return BadRequest();
        }

        _context.categories.Add(category);
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
}
