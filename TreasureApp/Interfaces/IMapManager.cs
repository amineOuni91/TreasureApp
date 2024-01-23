using TreasureApp.Models;

namespace TreasureApp.Interfaces;

public interface IMapManager
{
    public Map Map { get; set; }

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
