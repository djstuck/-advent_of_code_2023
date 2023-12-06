namespace DataHandling;

public class DataImporter
{
    private string line;
    private static StreamReader streamReader;

    public DataImporter(string filename)
    {
        try
        {
            streamReader = new StreamReader(filename);
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    public string GetLine()
    {
        try
        {
            line = streamReader.ReadLine();
            return line;
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
            return null;
        }
    }
}

