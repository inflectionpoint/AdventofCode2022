using AoCwithCSharp;

namespace AoCwithCSharpTests
{
    public class TestDay02
    {
        private readonly string day;
        private readonly ITestOutputHelper output;

        public TestDay02(ITestOutputHelper output)
        {
            this.output = output;
            day = GetType().Name[7..];
        }

        [Theory]
        [InlineData("Sample", 15)]
        [InlineData("Puzzle", 15691)]
        public void TestPartA(string type, int expect)
        {
            //Arrange
            SolveDay02 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = solver.PartA;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }

        [Theory]
        [InlineData("Sample", 12)]
        [InlineData("Puzzle", 12989)]
        public void TestPartB(string type, int expect)
        {
            //Arrange
            SolveDay02 puzzle = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = puzzle.PartB;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }
    }
}