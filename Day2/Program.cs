using System.Dynamic;
using System.Reflection.Metadata;
using DataHandling;
namespace Day2;

public struct Game
{
    int id {get;}
    int blue {get;}
    int red {get;}
    int green {get;}

    public Game(int id, int blue, int red, int green)
    {
        this.id = id;
        this.blue = blue;
        this.red = red;
        this.green = green;
    }

    public Game(int id)
    {
        this.id = id;
        this.red = 0;
        this.blue = 0;
        
        this.green = 0;
    }

    public void addBlue(int num)
    {
        this.blue += num;
    }
    public void addRed(int num)
    {
        this.red += num;
    }
    public void addGreen(int num)
    {
        this.green += num;
    }
}

public class Bag()
{
    DataImporter dataImporter;
    private List<int> possibleGameIds;

    private List<string> colours = new List<string>{"blue", "red", "green"};

    public Bag(string dataFileName)
    {
        dataImporter = new DataImporter(dataFileName);
        possibleGameIds = new List<int>();
    }

    public List<int> FindPossibleGameIds()
    {
        string line = dataImporter.GetLine();
        int id = 1;
        while(line != null)
        {
            Game game = new Game(id);
            foreach (string colour in colours)
            {
                for(int counter = 0; counter < line.Length; counter++)
                {
                    if(line.Substring(counter).StartsWith(colour))
                    {
                        int numberOfCubes = line.ElementAt(counter - 2) - '0';
                        if(colour == "red")
                        {
                            game.addRed(numberOfCubes);
                        }
                        else if(colour == "blue")
                        {
                            game.addBlue(numberOfCubes);
                        }
                        else
                        {
                            game.addGreen(numberOfCubes);
                        }                        

                    }
                }
            }

            if()

            line = dataImporter.GetLine();
            id ++;
        }

        return possibleGameIds;
    }

}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
