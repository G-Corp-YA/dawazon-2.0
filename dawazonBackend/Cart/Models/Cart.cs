using System.ComponentModel.DataAnnotations;
using dawazonBackend.Common.Attribute;

namespace dawazonBackend.Cart.Models;

/// <summary>
/// Representa un carrito de compra o un pedido finalizado.
/// </summary>
public class Cart
{
    /// <summary>
    /// Identificador único del carrito (Custom ID).
    /// </summary>
    [Key]
    [GenerateCustomIdAtribute]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// ID del usuario propietario del carrito.
    /// </summary>
    [Required]
    public long UserId {get; set;}

    /// <summary>
    /// Indica si el carrito ya ha sido comprado (convertido en pedido).
    /// </summary>
    [Required]
    public bool Purchased {get; set;}

    /// <summary>
    /// Información del cliente que realiza el pedido.
    /// </summary>
    [Required] 
    public Client Client { get; set; } = new();

    /// <summary>
    /// Líneas de productos contenidas en el carrito.
    /// </summary>
    [Required] 
    public List<CartLine> CartLines { get; set; } = [];

    /// <summary>
    /// Cantidad total de productos en el carrito.
    /// </summary>
    [Required]
    public int TotalItems {get; set;}

    /// <summary>
    /// Precio total del carrito.
    /// </summary>
    [Required]
    public double Total {get; set;}

    /// <summary>
    /// Fecha de creación del carrito.
    /// </summary>
    [Required]
    public DateTime CreatedAt {get; set;}= DateTime.UtcNow;

    /// <summary>
    /// Fecha de la última actualización del carrito.
    /// </summary>
    [Required]
    public DateTime UploadAt {get; set;}= DateTime.UtcNow;

    /// <summary>
    /// Indica si hay un proceso de checkout (pago) en curso.
    /// </summary>
    [Required] 
    public bool CheckoutInProgress { get; set; } = false;

    /// <summary>
    /// Fecha y hora en la que se inició el proceso de checkout.
    /// </summary>
    public DateTime? CheckoutStartedAt {get; set;} 

    /// <summary>
    /// Obtiene los minutos transcurridos desde que se inició el checkout.
    /// </summary>
    /// <returns>Minutos transcurridos o 0 si no hay checkout iniciado.</returns>
    public long GetMinutesSinceCheckoutStarted()
    {
        if (this.CheckoutStartedAt== null)
        {
            return 0;
        }
        return (long)(DateTime.UtcNow - CheckoutStartedAt.Value).TotalMinutes;
    }
}