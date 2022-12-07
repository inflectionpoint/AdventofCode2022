using AoCwithCSharp;

namespace AoCwithCSharpTests
{
    public class TestDay03
    {
        private readonly string day;
        private readonly ITestOutputHelper output;

        public TestDay03(ITestOutputHelper output)
        {
            this.output = output;
            day = GetType().Name[7..];
        }

        [Theory]
        [InlineData("Sample", 157)]
        [InlineData("Puzzle", 8018)]
        public void TestPartA(string type, int expect)
        {
            //Arrange
            SolveDay03 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = solver.PartA;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }

        [Theory]
        [InlineData("Sample", 70)]
        [InlineData("Puzzle", 2518)]
        public void TestPartB(string type, int expect)
        {
            //Arrange
            SolveDay03 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = solver.PartB;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }

    }
}