using System.Security.AccessControl;
using DataHandling;

namespace day1;

public class Day1
{
    private DataImporter DataHandling;
    private List<int> result;
    private int sumOfResults;

    /// <summary>
    /// Constructor for day1 problem. Initiates the DataImporter.
    /// </summary>
    /// <param name="dataFileName"></param> Absolute Path of the data file.
    public Day1(string dataFileName)
    {
        DataHandling = new DataImporter(dataFileName);
        result = new List<int>();
    }

    /// <summary>
    /// Part one of problem, goes through each line and gets the first and last digit and sums the numbers.
    /// </summary>
    public void Calculate()
    {
        string nextLine = DataHandling.GetLine();

        while (nextLine != null)
        {
            int first_digit =0; 
            int last_digit = 0;
            int i = 0;
            bool first_digit_found = false;
            while (i < nextLine.Length && !first_digit_found)
            {
                if(nextLine[i] > '0' && nextLine[i] <= '9')
                {
                    first_digit_found = true;
                    first_digit = (int)nextLine[i] - (int)'0';  // need to subtract the Unicode code point of '0'. The Unicode code point of '0' is 48.
                }
                else
                {
                    i++;
                }
            }
            while (i < nextLine.Length)
            {
                if(nextLine[i] > '0' && nextLine[i] <= '9')
                {
                    last_digit = (int)nextLine[i] - (int)'0'; // need to subtract the Unicode code point of '0'. The Unicode code point of '0' is 48.
                }
                i++;
            }
            
            result.Add(((first_digit * 10) + last_digit));

            nextLine = DataHandling.GetLine();
        }

        sumOfResults = 0;
        if(result.Count > 0)
        {
            foreach(int lineResult in result)
            {
                sumOfResults += lineResult;
            }
        }
        else
        {
            Console.WriteLine("No Data Collected");
        }

    }

    /// <summary>
    /// prints out the digits for each line. Used for debugging purposes
    /// </summary>
    public void PrintResults()
    {
        foreach(int lineResult in result)
        {
            Console.WriteLine(lineResult);
        }
    }
    /// <summary>
    /// Get function for the sum of the digits for part one.
    /// </summary>
    /// <returns>Returns the sum of the digits for part one</returns>
    public int GetSummedResult()
    {
        return sumOfResults;
    } 
}

class Program
{
    static void Main(string[] args)
    {
        Day1 day1 = new Day1("Data.txt");
        day1.Calculate();
        day1.PrintResults();
        int summedResult = day1.GetSummedResult();
        Console.WriteLine(summedResult);
    }
}
