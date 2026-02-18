using CSharpFunctionalExtensions;
using dawazonBackend.Common;

namespace dawazonBackend.Stripe;

public interface IStripeService
{
    Task<Result<string, DomainError>> CreateCheckoutSessionAsync(Cart.Models.Cart cart);
}