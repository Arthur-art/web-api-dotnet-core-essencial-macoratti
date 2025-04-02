namespace web_api_catalog.Models;

public class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public float Rating { get; set; }

    public DateTime DateOfRegistration { get; set; }
}
