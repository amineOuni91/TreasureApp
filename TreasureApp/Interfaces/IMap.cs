using TreasureApp.Models;

namespace TreasureApp.Interfaces;

public interface IMapManager
{
    public Map Map { get; set; }
    /// <summary>
    /// Gets or sets the width.
    /// </summary>
    /// <param name="x"> The X axis.</param>
    /// <param name="y"> The Y axis.</param>

    /// <summary>
    /// The map creator.
    /// </summary>
    /// <param name="filePath"> The file path.</param>
    void CreateMap(string filePath);

    /// <summary>
    /// The movement simulation.
    /// </summary>
    void SimulateMovements();
}
