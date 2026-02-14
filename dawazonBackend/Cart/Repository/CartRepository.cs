using dawazonBackend.Cart.Dto;
using dawazonBackend.Cart.Models;
using dawazonBackend.Common.Database;
using Microsoft.EntityFrameworkCore;

namespace dawazonBackend.Cart.Repository;

public class CartRepository(
    DawazonDbContext context,
    ILogger<CartRepository> logger
    ): ICartRepository
{
    public async Task<bool> UpdateCartLineStatusAsync(string id, string productId, Status status)
    {
        logger.LogInformation($"Actualizando linea de carrito {id} con status {status}");
        
        var oldCart = await context.Carts.Include(c => c.CartLines)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (oldCart == null) return false;
        
        oldCart.CartLines.Find(cl => cl.ProductId == productId)!.Status = status;
        context.Carts.Update(oldCart);
        await context.SaveChangesAsync();
        
        return true;
    }

    public Task<IEnumerable<Models.Cart>> FindByUserIdAsync(long userId, FilterCartDto filter)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddCartLineAsync(string cartId, CartLine cartLine)
    {
        logger.LogInformation($"Añadiendo línea de carrito al carrito con ID: {cartId}");
    
        var cart = await context.Carts.Include(c => c.CartLines)
            .FirstOrDefaultAsync(c => c.Id == cartId);
    
        if(cart == null) return false;

        var existingLine = cart.CartLines
            .FirstOrDefault(cl => cl.ProductId == cartLine.ProductId);

        if (existingLine != null) existingLine.Quantity = cartLine.Quantity; 
        
        else cart.CartLines.Add(cartLine);
        
        context.Carts.Update(cart);
        await context.SaveChangesAsync();
    
        return true;
    }

    public Task<long> RemoveCartLineAsync(string cartId, CartLine cartLine)
    {
        throw new NotImplementedException();
    }

    public Task<Models.Cart?> FindByUserIdAndPurchasedAsync(long userId, bool purchased)
    {
        throw new NotImplementedException();
    }

    public Task<Models.Cart?> FindCartByIdAsync(string cartId)
    {
        throw new NotImplementedException();
    }

    public Task<Models.Cart> CreateCartAsync(Models.Cart cart)
    {
        throw new NotImplementedException();
    }

    public Task<Models.Cart> UpdateCartAsync(string id, Models.Cart cart)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCartAsync(string id)
    {
        throw new NotImplementedException();
    }
}