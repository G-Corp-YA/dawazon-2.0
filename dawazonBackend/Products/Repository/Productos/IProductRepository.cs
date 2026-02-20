using dawazonBackend.Common.Dto;
using dawazonBackend.Products.Models;

namespace dawazonBackend.Products.Repository.Productos;

/// <summary>
/// Interfaz para el repositorio de productos.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Obtiene todos los productos de forma paginada y filtrada.
    /// </summary>
    /// <param name="filter">Filtros de búsqueda.</param>
    /// <returns>Una tupla con los productos y el conteo total.</returns>
    Task<(IEnumerable<Product> Items, int TotalCount)> GetAllAsync(FilterDto filter);

    /// <summary>
    /// Obtiene productos creados entre dos fechas.
    /// </summary>
    /// <param name="start">Fecha de inicio.</param>
    /// <param name="end">Fecha de fin.</param>
    /// <returns>Lista de productos encontrados.</returns>
    Task<List<Product>> GetAllByCreatedAtBetweenAsync(DateTime start, DateTime end);

    /// <summary>
    /// Resta stock de un producto de forma atómica usando concurrencia optimista.
    /// </summary>
    /// <param name="id">ID del producto.</param>
    /// <param name="amount">Cantidad a restar.</param>
    /// <param name="version">Versión del producto para control de concurrencia.</param>
    /// <returns>1 si tuvo éxito, 0 en caso contrario.</returns>
    Task<int> SubstractStockAsync(string id, int amount, long version);

    /// <summary>
    /// Busca todos los productos creados por un usuario específico.
    /// </summary>
    /// <param name="userId">ID del creador.</param>
    /// <param name="filter">Filtros de paginación.</param>
    /// <returns>Productos del creador y conteo total.</returns>
    Task<(IEnumerable<Product> Items, int TotalCount)> FindAllByCreatorId(long userId, FilterDto filter);

    /// <summary>
    /// Elimina un producto por su ID (borrado lógico).
    /// </summary>
    /// <param name="id">ID del producto.</param>
    Task DeleteByIdAsync(string id);

    /// <summary>
    /// Obtiene un producto por su ID incluyendo categorías y comentarios.
    /// </summary>
    /// <param name="id">ID del producto.</param>
    /// <returns>El producto encontrado o null.</returns>
    Task<Product?> GetProductAsync(string id);

    /// <summary>
    /// Actualiza un producto existente.
    /// </summary>
    /// <param name="product">Datos actualizados.</param>
    /// <param name="id">ID del producto.</param>
    /// <returns>El producto actualizado o null.</returns>
    Task<Product?> UpdateProductAsync(Product product, string id);

    /// <summary>
    /// Crea un nuevo producto en la base de datos.
    /// </summary>
    /// <param name="product">El producto a crear.</param>
    /// <returns>El producto creado.</returns>
    Task<Product?> CreateProductAsync(Product product);
}