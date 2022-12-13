using AoCwithCSharp;

namespace AoCwithCSharpTests
{
    public class TestDay07
    {
        private readonly string day;
        private readonly ITestOutputHelper output;

        public TestDay07(ITestOutputHelper output)
        {
            this.output = output;
            day = GetType().Name[7..];
        }

        [Theory]
        [InlineData("Sample", 95437)]
        [InlineData("Puzzle", 1743217)]
        public void TestPartA(string type, int expect)
        {
            //Arrange
            SolveDay07 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = solver.PartA;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);
        }

        [Theory]
        [InlineData("Sample", 24933642)]
        [InlineData("Puzzle", 8319096)]
        public void TestPartB(string type, int expect)
        {
            //Arrange
            SolveDay07 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = solver.PartB;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }
    }
}