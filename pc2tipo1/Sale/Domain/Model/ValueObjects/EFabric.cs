namespace Pc2_Tipo1.API.Sale.Domain.Model.ValueObjects;


/// <summary>
/// Fabric enumeration value object
/// </summary>
/// <remarks>
/// Represents the available fabric types for purchase orders.
/// Author: [Tu Nombre y Apellidos]
/// </remarks>
public class EFabric
{
    public int Id { get; }
    public string Name { get; }
    
    private EFabric(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public static readonly EFabric Algodon = new(1, "Algodon");
    public static readonly EFabric Modal = new(2, "Modal");
    public static readonly EFabric Elastano = new(3, "Elastano");
    public static readonly EFabric Poliester = new(4, "Poliester");
    public static readonly EFabric Nailon = new(5, "Nailon");
    public static readonly EFabric Acrilico = new(6, "Acrilico");
    public static readonly EFabric Rayon = new(7, "Rayon");
    public static readonly EFabric Lyocell = new(8, "Lyocell");
    
    private static readonly EFabric[] All = {
        Algodon, Modal, Elastano, Poliester, Nailon, Acrilico, Rayon, Lyocell
    };
    
    /// <summary>
    /// Gets fabric type by ID
    /// </summary>
    /// <param name="id">Fabric ID</param>
    /// <returns>EFabric instance or null if not found</returns>
    public static EFabric? FromId(int id) => All.FirstOrDefault(f => f.Id == id);
    
    /// <summary>
    /// Validates if fabric ID is valid
    /// </summary>
    /// <param name="id">Fabric ID to validate</param>
    /// <returns>True if valid, false otherwise</returns>
    public static bool IsValid(int id) => All.Any(f => f.Id == id);
    
    /// <summary>
    /// Gets default fabric (Algodon)
    /// </summary>
    /// <returns>Default fabric</returns>
    public static EFabric GetDefault() => Algodon;
    
    public static EFabric? FromName(string name)
    {
        return All.FirstOrDefault(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
    
    public override string ToString() => Name;
}