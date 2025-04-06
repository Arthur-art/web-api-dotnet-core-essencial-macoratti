using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_catalog.Models;

[Table("Categories")]
public class Category
{
    public Category()
    {
        Products = new Collection<Product>();
    }

    public Category(int categoryId)
    {
        CategoryId = categoryId;
    }

    public Category(string? nome, string? imagemUrl)
    {
        Nome = nome;
        ImagemUrl = imagemUrl;
    }

    [Key]
    public int CategoryId { get; set; }
    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    public ICollection<Product>? Products { get; set; }
}
