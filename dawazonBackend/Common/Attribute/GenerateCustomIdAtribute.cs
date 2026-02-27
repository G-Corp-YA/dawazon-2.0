namespace dawazonBackend.Common.Attribute;
using System;
/// <summary>
/// Atributo personalizado para marcar propiedades que deben generar un ID único automáticamente.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class GenerateCustomIdAtribute: Attribute
{
    
}