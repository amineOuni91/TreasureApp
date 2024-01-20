namespace TreasureApp.Interfaces;

public interface IResultWriter
{
    ///<summary>
    /// The output file writer.
    /// </summary>
    /// <param name="fileName"> The file name.</param> 
    void WriteOutputFile(string fileName);
}
