using CSharpFunctionalExtensions;
using dawazonBackend.Common;
using dawazonBackend.Common.Error;

namespace dawazonBackend.Stripe;

/// <summary>
/// Interfaz para el servicio de integración con Stripe.
/// </summary>
public interface IStripeService
{
    /// <summary>
    /// Crea una sesión de checkout de Stripe para procesar el pago de un carrito.
    /// </summary>
    /// <param name="cart">El carrito de compras con los productos y datos del cliente.</param>
    /// <returns>Un resultado exitoso con la URL de la sesión de pago de Stripe o un error de dominio.</returns>
    Task<Result<string, DomainError>> CreateCheckoutSessionAsync(Cart.Models.Cart cart);
}