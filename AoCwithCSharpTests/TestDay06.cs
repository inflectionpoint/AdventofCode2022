using AoCwithCSharp;
using System.IO;

namespace AoCwithCSharpTests
{
    public class TestDay06
    {
        private readonly string day;
        private readonly ITestOutputHelper output;

        public TestDay06(ITestOutputHelper output)
        {
            this.output = output;
            day = GetType().Name[7..];
        }

        [Theory]
        [InlineData(Common.BasePath + $"Data - Sample\\Sample06.txt",true, 7)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", false, 5)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", false, 6)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", false, 10)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", false, 11)]
        [InlineData(Common.BasePath + $"Data - Puzzle\\Puzzle06.txt",true, 1909)]
        public void TestPartA(string data, bool isPath, int expect)
        {
            //Arrange
            SolveDay06 solver = new(data, isPath);

            //Act
            int result = solver.PartA;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }

        [Theory]
        [InlineData(Common.BasePath + $"Data - Sample\\Sample06.txt", true, 19)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", false, 23)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", false, 23)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", false, 29)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", false, 26)]
        [InlineData(Common.BasePath + $"Data - Puzzle\\Puzzle06.txt", true, 3380)]
        public void TestPartB(string data, bool isPath, int expect)
        {
            //Arrange
            SolveDay06 solver = new(data, isPath);

            //Act
            int result = solver.PartB;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }

    }
}