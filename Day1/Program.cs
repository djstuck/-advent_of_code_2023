using System.Security.AccessControl;
using System.Linq;
using System.Text.RegularExpressions;
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
    public void Calculate(bool calculateWithSpeltNumbers)
    {
        string nextLine = DataHandling.GetLine();

        while (nextLine != null)
        {
            int extractedNumber;
            if(calculateWithSpeltNumbers)
            {
                extractedNumber = ExtractFirstAndLastDigitFromStringWithSpeltDigits(nextLine);
            }
            else
            {
                extractedNumber = ExtractFirstAndLastDigitFromString(nextLine);
            }
            
            result.Add(extractedNumber);

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
    /// Extracts the first and last digit in line of chars and puts the two numbers together as a two digit number
    /// </summary>
    /// <param name="line"></param>
    /// <returns>int containing first and last digit in a line</returns>
    public int ExtractFirstAndLastDigitFromString(string line)
    {
        char firstDigit = line.First(char.IsDigit);
        char lastDigit = line.Last(char.IsDigit);

        return int.Parse($"{firstDigit}{lastDigit}");
    }

    public int  /// <summary>
    /// Extracts the first and last digit in line of chars and puts the two numbers together as a two digit number
    /// This method will also pick up if a number is written and will call that the number
    /// </summary>
    /// <param name="line"></param>
    /// <returns>int containing first and last digit in a line</returns>
    ExtractFirstAndLastDigitFromStringWithSpeltDigits(string line)
    {

        List<int> digits = new List<int>();
        Dictionary<string, int> wordToNumber = new Dictionary<string, int>
            {
                {"one", 1},
                {"two", 2},
                {"three", 3},
                {"four", 4},
                {"five", 5},
                {"six", 6},
                {"seven", 7},
                {"eight", 8},
                {"nine", 9}
            };

        // This next block of code will go through each of the characters in the line and if it is numeric, add the number to the list of digits and if it is a letter will check if its a start of one of the words from the dictonary.

        int counter = 0;
        foreach(char c in line)
        {
            if(!char.IsDigit(c))
            {
                foreach(var keyValuePair in wordToNumber)
                {
                    if (line.Substring(counter).StartsWith(keyValuePair.Key))
                    {
                        digits.Add(keyValuePair.Value);
                        break;
                    }
                }
            }
            else
            {
                digits.Add(c - '0'); // Have to minus 49 from ASCII to get the actual number
            }
            counter++;
        }

        return int.Parse($"{digits.FirstOrDefault(0)}{digits.LastOrDefault(0)}");
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
        day1.Calculate(false); // False to note that spelt numbers is not taken into account for part1
        // day1.PrintResults();
        int summedResult = day1.GetSummedResult();
        Console.WriteLine("Answer to part 1: {0}", summedResult);
        day1.Calculate(true); // True to note that spelt numbers are being taken into account for part2
        // day1.PrintResults();
        summedResult = day1.GetSummedResult();
        Console.WriteLine("Answer to part 2: {0}", summedResult);
    }
}
