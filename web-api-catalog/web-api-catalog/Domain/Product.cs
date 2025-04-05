using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_catalog.Models;

[Table("Products")]
public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    [StringLength(80)]
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
