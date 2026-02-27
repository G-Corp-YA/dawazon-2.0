using System.ComponentModel.DataAnnotations;
using dawazonBackend.Products.Models;

namespace dawazonBackend.Cart.Models;

/// <summary>
/// Representa un producto y su cantidad dentro de un carrito.
/// </summary>
public class CartLine
{ 
    /// <summary>
    /// ID del carrito al que pertenece la línea.
    /// </summary>
    [Required]
    public string CartId { get; set; } = string.Empty;

    /// <summary>
    /// ID del producto.
    /// </summary>
    [Required]
    public string ProductId { get; set; } = string.Empty;
    
    /// <summary>
    /// Referencia al modelo del producto (para navegación).
    /// </summary>
    public Product? Product { get; set; }

    /// <summary>
    /// Cantidad del producto solicitada.
    /// </summary>
    [Required] 
    public int Quantity { get; set; } = 0;

    /// <summary>
    /// Precio unitario del producto en el momento de la línea.
    /// </summary>
    [Required]
    public double ProductPrice { get; set; }
    
    /// <summary>
    /// Estado actual de esta línea de pedido (ej. Preparado, Cancelado).
    /// </summary>
    [Required]
    public Status  Status { get; set; }

    /// <summary>
    /// Obtiene el precio total de esta línea (Precio * Cantidad).
    /// </summary>
    public double TotalPrice => ProductPrice * Quantity;
}