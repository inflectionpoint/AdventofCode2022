using AoCwithCSharp;

namespace AoCwithCSharpTests
{
    public class TestDay01
    {
        private readonly string day;
        private readonly ITestOutputHelper output;

        public TestDay01(ITestOutputHelper output)
        {
            this.output = output;
            day = GetType().Name[7..];
        }

        [Theory]
        [InlineData("Sample",24000)]
        [InlineData("Puzzle",70698)]
        public void TestPartA(string type, int expect)
        {
            //Arrange
            SolveDay01 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = solver.PartA;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }

        [Theory]
        [InlineData("Sample", 45000)]
        [InlineData("Puzzle", 206643)]
        public void TestPartB(string type, int expect)
        {
            //Arrange
            SolveDay01 puzzle = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = puzzle.PartB;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }
    }
}