using System.ComponentModel.DataAnnotations;
using dawazonBackend.Products.Models;

namespace dawazonBackend.Cart.Models;

public class CartLine
{ 
    [Required]
    public string CartId { get; set; } = string.Empty;

    [Required]
    public string ProductId { get; set; } = string.Empty;
    
    public Product? Product { get; set; }

    [Required] 
    public int Quantity { get; set; } = 0;

    [Required]
    public double ProductPrice { get; set; }
    
    [Required]
    public Status  Status { get; set; }
    public double TotalPrice => ProductPrice * Quantity;
}