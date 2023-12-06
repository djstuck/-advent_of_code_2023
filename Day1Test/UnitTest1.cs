using day1;
namespace Day1Test;

[TestClass]
public class UnitTestDay1Part1
{
    /// <summary>
    /// Test method to test if the correct answer is calculated from the test data
    /// </summary>
    [TestMethod]
    public void TestDataMethod()
    {
        Day1 day1 = new Day1("/workspaces/advent_of_code_2023/Day1Test/TestData.txt");
        day1.Calculate(false); // False to note that spelt numbers is not taken into account for part1
        // day1.PrintResults();
        int summedResult = day1.GetSummedResult();
        Assert.AreEqual(142, summedResult);
    }
    
    /// <summary>
    /// Test method to test if the correct answer is calculated from the real data
    /// </summary>
    [TestMethod]
    public void RealDataMethod()
    {
        Day1 day1 = new Day1("/workspaces/advent_of_code_2023/Day1/Data.txt");
        day1.Calculate(false); // False to note that spelt numbers is not taken into account for part1
        // day1.PrintResults();
        int summedResult = day1.GetSummedResult();
        Assert.AreEqual(54667, summedResult);
    }

}

[TestClass]
public class UnitTestDay1Part2
{
    /// <summary>
    /// Test method to test if the correct answer is calculated from the test data
    /// </summary>
    [TestMethod]
    public void TestDataMethod()
    {
        Day1 day1 = new Day1("/workspaces/advent_of_code_2023/Day1Test/TestData2.txt");
        day1.Calculate(true); // True to note that spelt numbers are being taken into account for part2
        // day1.PrintResults();
        int summedResult = day1.GetSummedResult();
        Assert.AreEqual(281, summedResult);
    }
    
    /// <summary>
    /// Test method to test if the correct answer is calculated from the real data
    /// </summary>
    [TestMethod]
    public void RealDataMethod()
    {
        Day1 day1 = new Day1("/workspaces/advent_of_code_2023/Day1/Data.txt");
        day1.Calculate(true); // True to note that spelt numbers are being taken into account for part2
        // day1.PrintResults();
        int summedResult = day1.GetSummedResult();
        Assert.AreEqual(54203, summedResult);
    }

}