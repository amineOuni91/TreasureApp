using TreasureApp.Interfaces;
using TreasureApp.Models;

namespace TreasureApp;

public class MapManager() : IMapManager
{

    private Map map;

    /// <inheritdoc cref="IMapManager.AddMountain(int, int)"/>
    public void AddMountain(int x, int y)
    {
        map.Cells[x, y].IsMountain = true;
    }

    /// <inheritdoc cref="IMapManager.AddTreasure(int, int, int)"/>
    public void AddTreasure(int x, int y, int count)
    {
        map.Cells[x, y].TreasureCount = count;
    }

    /// <inheritdoc cref="IMapManager.AddAdventurer(string, int, int, char, string)"/>
    public void AddAdventurer(string name, int x, int y, char orientation, string movementSequence)
    {
        var adventurer = new Adventurer
        {
            Name = name,
            Position = map.Cells[x, y],
            Orientation = orientation,
            MovementSequence = movementSequence
        };

        map.Adventurers.Add(adventurer);
    }

    /// <inheritdoc cref="IMapManager.CreateMap"/>"
    public Map CreateMap(string filePath)
    {
        try
        {
            using StreamReader reader = new(filePath);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith('#'))
                {
                    continue;
                }

                string[] parts = line.Split('-');

                switch (parts[0].Trim())
                {
                    case "C":
                        // Dimensions de la carte
                        int width = int.Parse(parts[1]);
                        int height = int.Parse(parts[2]);
                        map = new Map(width, height);
                        break;

                    case "M":
                        // Ajouter une montagne
                        int mountainX = int.Parse(parts[1]);
                        int mountainY = int.Parse(parts[2]);
                        AddMountain(mountainX, mountainY);
                        break;

                    case "T":
                        // Ajouter des trésors
                        int treasureX = int.Parse(parts[1]);
                        int treasureY = int.Parse(parts[2]);
                        int treasureCount = int.Parse(parts[3]);
                        AddTreasure(treasureX, treasureY, treasureCount);
                        break;

                    case "A":
                        // Ajouter un aventurier
                        string adventurerName = parts[1];
                        int adventurerX = int.Parse(parts[2]);
                        int adventurerY = int.Parse(parts[3]);
                        char adventurerOrientation = char.Parse(parts[4]);
                        string movementSequence = parts[5];
                        AddAdventurer(adventurerName, adventurerX, adventurerY, adventurerOrientation, movementSequence);
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la lecture du fichier d'entrée : {ex.Message}");
        }

        return map;
    }

    /// <summary>
    /// Simulate the adventurers movements.
    /// </summary>
    public void SimulateMovements()
    {
        int maxMoves = map.Adventurers.Max(a => a.MovementSequence.Length);

        for (int i = 0; i < maxMoves; i++)
        {
            foreach (var adventurer in map.Adventurers)
            {
                if (i < adventurer.MovementSequence.Length)
                {
                    char move = adventurer.MovementSequence[i];

                    switch (move)
                    {
                        case 'A':
                            MoveForward(adventurer);
                            break;
                        case 'G':
                            TurnLeft(adventurer);
                            break;
                        case 'D':
                            TurnRight(adventurer);
                            break;
                    }
                }
            }
        }
    }

    private void MoveForward(Adventurer adventurer)
    {
        int newX = adventurer.Position.X;
        int newY = adventurer.Position.Y;

        switch (adventurer.Orientation)
        {
            case 'N':
                newY--;
                break;
            case 'S':
                newY++;
                break;
            case 'E':
                newX++;
                break;
            case 'O':
                newX--;
                break;
        }

        if (IsValidPosition(newX, newY))
        {
            adventurer.Position = map.Cells[newX, newY];

            if (adventurer.Position.TreasureCount > 0)
            {
                adventurer.TreasureCount++;
                adventurer.Position.TreasureCount--;
            }
        }
    }

    private static void TurnLeft(Adventurer adventurer)
    {
        switch (adventurer.Orientation)
        {
            case 'N':
                adventurer.Orientation = 'O';
                break;
            case 'S':
                adventurer.Orientation = 'E';
                break;
            case 'E':
                adventurer.Orientation = 'N';
                break;
            case 'O':
                adventurer.Orientation = 'S';
                break;
        }
    }

    private static void TurnRight(Adventurer adventurer)
    {
        switch (adventurer.Orientation)
        {
            case 'N':
                adventurer.Orientation = 'E';
                break;
            case 'S':
                adventurer.Orientation = 'O';
                break;
            case 'E':
                adventurer.Orientation = 'S';
                break;
            case 'O':
                adventurer.Orientation = 'N';
                break;
        }
    }

    private bool IsValidPosition(int x, int y)
    {
        if (x < 0 || x >= map.Width || y < 0 || y >= map.Height)
        {
            return false;
        }

        if (map.Cells[x, y].IsMountain)
        {
            return false;
        }

        if (map.Adventurers.Any(a => a.Position == map.Cells[x, y]))
        {
            return false;
        }

        return true;
    }

}
