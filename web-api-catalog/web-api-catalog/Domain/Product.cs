using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_catalog.Models;

[Table("Products")]
public class Product
{
    public Product()
    {
        
    }
    public Product(int productId, string? name, string? description, decimal price, string? imageUrl, float rating, DateTime dateOfRegistration, int categoryId)
    {
        ProductId = productId;
        Name = name;
        Description = description;
        Price = price;
        ImageUrl = imageUrl;
        Rating = rating;
        DateOfRegistration = dateOfRegistration;
        CategoryId = categoryId;
    }

    [Key]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "O Nome do produto é obrigatório.")]
    [StringLength(80, ErrorMessage = "O produto deve ter no máximo 80 caracteres.")]
    public string? Name { get; set; }

    [Required]
    [StringLength(300)]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }

    public float Rating { get; set; }

    public DateTime DateOfRegistration { get; set; }

    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}
