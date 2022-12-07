using AoCwithCSharp;

namespace AoCwithCSharpTests
{
    public class TestDay05
    {
        private readonly string day;
        private readonly ITestOutputHelper output;

        public TestDay05(ITestOutputHelper output)
        {
            this.output = output;
            day = GetType().Name[7..];
        }

        [Theory]
        [InlineData("Sample", "CMZ")]
        [InlineData("Puzzle", "CNSZFDVLJ")]
        public void TestPartA(string type, string expect)
        {
            //Arrange
            SolveDay05 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            string result = solver.PartA;
            output.WriteLine(result);

            //Assert
            Assert.Equal(expect, result);

        }

        [Theory]
        [InlineData("Sample", "MCD")]
        [InlineData("Puzzle", "QNDWLMGNS")]
        public void TestPartB(string type, string expect)
        {
            //Arrange
            SolveDay05 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            string result = solver.PartB;
            output.WriteLine(result);

            //Assert
            Assert.Equal(expect, result);

        }

    }
}