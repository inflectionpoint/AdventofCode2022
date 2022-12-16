using AoCwithCSharp;

namespace AoCwithCSharpTests
{
    public class TestDay09
    {
        private readonly string day;
        private readonly ITestOutputHelper output;

        public TestDay09(ITestOutputHelper output)
        {
            this.output = output;
            day = GetType().Name[7..];
        }

        [Theory]
        [InlineData("Sample", 13)]
        [InlineData("Puzzle", 6337)]
        public void TestPartA(string type, int expect)
        {
            //Arrange
            SolveDay09 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = solver.PartA;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);
        }

        [Theory]
        [InlineData("Sample","", 1)]
        [InlineData("Sample","B", 36)]
        [InlineData("Puzzle","", 2455)]
        public void TestPartB(string type, string alt, int expect)
        {
            //Arrange
            SolveDay09 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}{alt}.txt");

            //Act
            int result = solver.PartB;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }
    }
}