using AoCwithCSharp;

namespace AoCwithCSharpTests
{
    public class TestDay00
    {
        private readonly string day;
        private readonly ITestOutputHelper output;

        public TestDay00(ITestOutputHelper output)
        {
            this.output = output;
            day = GetType().Name[7..];
        }

        [Theory]
        [InlineData("Sample", 0)]
        [InlineData("Puzzle", 0)]
        public void TestPartA(string type, int expect)
        {
            //Arrange
            SolveDay00 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = solver.PartA;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }

        [Theory]
        [InlineData("Sample", 0)]
        [InlineData("Puzzle", 0)]
        public void TestPartB(string type, int expect)
        {
            //Arrange
            SolveDay00 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = solver.PartB;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }
    }
}