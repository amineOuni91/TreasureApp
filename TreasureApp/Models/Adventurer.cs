
namespace TreasureApp.Models;

/// <summary>
/// The adventurer record.
/// </summary>
public class Adventurer
{
    /// <summary>
    /// The name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The position.
    /// </summary>
    public Cell Position { get; set; }

    /// <summary>
    /// The orientation.
    /// </summary>
    public char Orientation { get; set; }

    /// <summary>
    /// The movement sequence.
    /// </summary>
    public string MovementSequence { get; set; }

    /// <summary>
    /// The treasure count.
    /// </summary>
    public int TreasureCount { get; set; }
}
