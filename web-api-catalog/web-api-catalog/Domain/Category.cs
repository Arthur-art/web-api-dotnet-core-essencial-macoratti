﻿using System.Collections.ObjectModel;

namespace web_api_catalog.Models;

public class Category
{
    public Category()
    {
        Products = new Collection<Product>();
    }
    public int CategoryId { get; set; }

    public string? Nome { get; set; }

    public string? ImagemUrl { get; set; }

    public ICollection<Product>? Products { get; set; }
}
