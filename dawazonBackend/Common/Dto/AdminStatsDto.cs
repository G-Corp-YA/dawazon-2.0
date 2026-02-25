namespace dawazonBackend.Common.Dto;

/// <summary>
/// DTO que contiene las estadísticas generales del panel de administración.
/// </summary>
public class AdminStatsDto
{
    /// <summary>
    /// Número total de productos en la tienda.
    /// </summary>
    public int TotalProducts { get; set; }

    /// <summary>
    /// Número total de usuarios registrados.
    /// </summary>
    public int TotalUsers { get; set; }

    /// <summary>
    /// Número total de ventas realizadas.
    /// </summary>
    public int TotalSales { get; set; }

    /// <summary>
    /// Ganancias totales generadas por las ventas.
    /// </summary>
    public double TotalEarnings { get; set; }

    /// <summary>
    /// Número de productos sin stock.
    /// </summary>
    public int OutOfStockCount { get; set; }

    /// <summary>
    /// Distribución de productos por categoría.
    /// </summary>
    public Dictionary<string, int> ProductsByCategory { get; set; } = new();
}
