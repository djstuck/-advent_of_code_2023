using day1;
namespace Day1Test;

[TestClass]
public class UnitTestDay1
{
    /// <summary>
    /// Test method to test if the correct answer is calculated from the test data
    /// </summary>
    [TestMethod]
    public void TestDataMethod()
    {
        Day1 day1 = new Day1("/workspaces/advent_of_code_2023/Day1Test/TestData.txt");
        day1.Calculate();
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
        day1.Calculate();
        // day1.PrintResults();
        int summedResult = day1.GetSummedResult();
        Assert.AreEqual(54667, summedResult);
    }

}