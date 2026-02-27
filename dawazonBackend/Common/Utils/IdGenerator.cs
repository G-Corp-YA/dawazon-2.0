using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace dawazonBackend.Common.Utils;

/// <summary>
/// Generador de identificadores personalizados cortos y aleatorios.
/// Utilizado para IDs de productos, categorías y carritos.
/// </summary>
public class IdGenerator : ValueGenerator<string>
{
    private const string Chars = "QWRTYPSDFGHJKLZXCVBNMqwrtypsdfghjklzxcvbnm1234567890-_";

    private const int Length = 12;

    /// <inheritdoc/>
    public override bool GeneratesTemporaryValues => false;

    /// <summary>
    /// Genera un nuevo ID aleatorio de 12 caracteres.
    /// </summary>
    /// <param name="entry">Entrada de la entidad en EF Core.</param>
    /// <returns>Una cadena aleatoria única.</returns>
    public override string Next(EntityEntry entry)
    {
        var bytes= new byte[Length];
        RandomNumberGenerator.Fill(bytes);
        var id= new char[Length];
        for (int i = 0; i<Length; i++)
        {
            id[i]=Chars[bytes[i] % Chars.Length];
        }
        return new string(id);
    }
}