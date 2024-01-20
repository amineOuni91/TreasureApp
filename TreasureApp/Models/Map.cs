namespace TreasureApp.Models;

/// <summary>
/// The map class.
/// </summary>
public class Map
{
    /// <summary>
    /// Gets or sets the width.
    /// </summary>
    public int Width { get; set; }
    /// <summary>
    /// Gets or sets the height.
    /// </summary>
    public int Height { get; set; }
    /// <summary>
    /// Gets or sets the cells.
    /// </summary>
    public Cell[,] Cells { get; set; }

    /// <summary>
    /// Gets or sets the adventurers.
    /// </summary>
    public List<Adventurer> Adventurers { get; set; }

    /// <summary>
    /// The map constructor.
    /// </summary>
    public Map(int width, int height)
    {
        Width = width;
        Height = height;
        Cells = new Cell[width, height];
        Adventurers = [];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cells[x, y] = new Cell(x, y);
            }
        }
    }
}