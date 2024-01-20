
using TreasureApp;
using TreasureApp.Interfaces;

string inputFile = @"Files/input.txt";
string outputFile = @"Files/output.txt";


// Lecture du fichier d'entrée et création de la carte
IMapManager mapManager = new MapManager();
mapManager.CreateMap(inputFile);
mapManager.SimulateMovements();
var resultWriter = new ResultWriter(mapManager.Map);
resultWriter.WriteOutputFile(outputFile);

Console.WriteLine("Simulation terminée. Résultats enregistrés dans le fichier de sortie.");