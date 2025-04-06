using System.ComponentModel.DataAnnotations;

namespace web_api_catalog.Models;

public class CategoryDto
{

    public string? Nome { get; set; }
    public string? ImagemUrl { get; set; }
}
