// Remplacez le chemin du fichier d'entrée par le chemin réel de votre fichier
using Treasure;

// La méthode principale
string inputFile = @"result/input.txt";
string outputFile = @"result/output.txt";

// Lecture du fichier d'entrée et création de la carte
Map map = ReadInputFile(inputFile);

// Simulation des mouvements des aventuriers
map.SimulateMovements();

// Écriture du fichier de sortie
map.WriteOutputFile(outputFile);

Console.WriteLine("Simulation terminée. Résultats enregistrés dans le fichier de sortie.");

// Méthode pour lire le fichier d'entrée et créer la carte
static Map ReadInputFile(string fileName)
{
    Map map = null;

    try
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("#"))
                {
                    // Ignorer les commentaires
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
                        map.AddMountain(mountainX, mountainY);
                        break;

                    case "T":
                        // Ajouter des trésors
                        int treasureX = int.Parse(parts[1]);
                        int treasureY = int.Parse(parts[2]);
                        int treasureCount = int.Parse(parts[3]);
                        map.AddTreasure(treasureX, treasureY, treasureCount);
                        break;

                    case "A":
                        // Ajouter un aventurier
                        string adventurerName = parts[1];
                        int adventurerX = int.Parse(parts[2]);
                        int adventurerY = int.Parse(parts[3]);
                        char adventurerOrientation = char.Parse(parts[4]);
                        string movementSequence = parts[5];
                        map.AddAdventurer(adventurerName, adventurerX, adventurerY, adventurerOrientation, movementSequence);
                        break;
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur lors de la lecture du fichier d'entrée : {ex.Message}");
    }

    return map;
}
