using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web_api_catalog.Models;

public class ProductDto
{

    public int ProductId { get; set; }

    /*[Required(ErrorMessage = "O Nome do produto é obrigatório.")]
    [StringLength(80, ErrorMessage = "O produto deve ter no máximo 80 caracteres.")]*/
    public string? Name { get; set; }

    [Required]
    [StringLength(300)]
    public string? Description { get; set; }

    /*[Required(ErrorMessage = "O preço do produto é obrigatório.")]
    [Range(0.01,9999.99, ErrorMessage = "O preço deve conter no minimo 3 caracteres.")]*/
    public decimal Price { get; set; }

    /*[Required(ErrorMessage = "A imagem do produto é obrigatório.")]*/
    [StringLength(300)]
    public string? ImageUrl { get; set; }

    public float Rating { get; set; }

    public DateTime DateOfRegistration { get; set; }

    public int CategoryId { get; set; }
}
