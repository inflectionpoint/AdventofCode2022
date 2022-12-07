using AoCwithCSharp;

namespace AoCwithCSharpTests
{
    public class TestDay04
    {
        private readonly string day;
        private readonly ITestOutputHelper output;

        public TestDay04(ITestOutputHelper output)
        {
            this.output = output;
            day = GetType().Name[7..];
        }

        [Theory]
        [InlineData("Sample", 2)]
        [InlineData("Puzzle", 540)]
        public void TestPartA(string type, int expect)
        {
            //Arrange
            SolveDay04 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = solver.PartA;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }

        [Theory]
        [InlineData("Sample", 4)]
        [InlineData("Puzzle", 872)]
        public void TestPartB(string type, int expect)
        {
            //Arrange
            SolveDay04 puzzle = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = puzzle.PartB;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }

    }
}