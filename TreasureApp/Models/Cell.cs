namespace TreasureApp.Models; 

/// <summary>
/// The map cells record. 
/// </summary>
/// <param name="X">The X axis.</param>
/// <param name="Y">The Y axis.</param>
public record Cell(int X, int Y)
{
    /// <summary>
    /// Is mountain.
    /// </summary>
    public bool IsMountain { get; set; }
    /// <summary>
    /// The treasure count.
    /// </summary>
    public int TreasureCount { get; set; }
}
