using AoCwithCSharp;

namespace AoCwithCSharpTests
{
    public class TestDay08
    {
        private readonly string day;
        private readonly ITestOutputHelper output;

        public TestDay08(ITestOutputHelper output)
        {
            this.output = output;
            day = GetType().Name[7..];
        }

        [Theory]
        [InlineData("Sample", 21)]
        [InlineData("Puzzle", 1820)]
        public void TestPartA(string type, int expect)
        {
            //Arrange
            SolveDay08 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = solver.PartA;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }

        [Theory]
        [InlineData("Sample", 8)]
        [InlineData("Puzzle", 385112)]
        public void TestPartB(string type, int expect)
        {
            //Arrange
            SolveDay08 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = solver.PartB;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }
    }
}