using TreasureApp.Interfaces;
using TreasureApp.Models;

namespace TreasureApp;

public class ResultWriter(Map map) : IResultWriter
{
    /// <summary>
    /// Write the output file.
    /// </summary>
    /// <param name="fileName">The file name.</param>
    public void WriteOutputFile(string fileName)
    {
        using (var writer = new StreamWriter(fileName))
        {
            writer.WriteLine($"C - {map.Width} - {map.Height}");

            foreach (var cell in map.Cells)
            {
                if (cell.IsMountain)
                {
                    writer.WriteLine($"M - {cell.X} - {cell.Y}");
                }
            }

            foreach (var cell in map.Cells)
            {
                if (cell.TreasureCount > 0)
                {
                    writer.WriteLine($"T - {cell.X} - {cell.Y} - {cell.TreasureCount}");
                }
            }

            foreach (var adventurer in map.Adventurers)
            {
                writer.WriteLine($"A - {adventurer.Name} - {adventurer.Position.X} - {adventurer.Position.Y} - {adventurer.Orientation} - {adventurer.TreasureCount}");
            }
        }
    }
}
