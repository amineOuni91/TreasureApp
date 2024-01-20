using TreasureApp.Models;

namespace TreasureApp.Interfaces;

public interface IMapManager
{
    /// <summary>
    /// Gets or sets the width.
    /// </summary>
    /// <param name="x"> The X axis.</param>
    /// <param name="y"> The Y axis.</param>
    void AddMountain(int x, int y);
    
    /// <summary>
    /// Gets or sets the height.
    /// </summary>
    /// <param name="x"> The X axis.</param>
    /// <param name="y"> The Y axis.</param>
    /// <param name="count"> The treasure count.</param>
    void AddTreasure(int x, int y, int count);
    
    /// <summary>
    /// Gets or sets the cells.
    /// </summary>
    /// <param name="name"> The name.</param>
    /// <param name="x"> The X axis.</param>
    /// <param name="y"> The Y axis.</param>
    /// <param name="orientation"> The orientation.</param>
    /// <param name="movementSequence"> The movement sequence.</param>
    void AddAdventurer(string name, int x, int y, char orientation, string movementSequence);

    /// <summary>
    /// The map creator.
    /// </summary>
    /// <param name="filePath"> The file path.</param>
    Map CreateMap(string filePath);

    /// <summary>
    /// The movement simulation.
    /// </summary>
    void SimulateMovements();
}
