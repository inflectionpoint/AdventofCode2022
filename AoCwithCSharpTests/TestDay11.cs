using AoCwithCSharp;

namespace AoCwithCSharpTests
{
    public class TestDay11
    {
        private readonly string day;
        private readonly ITestOutputHelper output;

        public TestDay11(ITestOutputHelper output)
        {
            this.output = output;
            day = GetType().Name[7..];
        }

        [Theory]
        [InlineData("Sample", 10605)]
        [InlineData("Puzzle", 55930)]
        public void TestPartA(string type, long expect)
        {
            //Arrange
            SolveDay11 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            long result = solver.PartA;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);
            //56168 too high??
        }

        [Theory]
        [InlineData("Sample", 2713310158)]
        [InlineData("Puzzle", 14636993466)]
        public void TestPartB(string type, long expect)
        {
            //Arrange
            SolveDay11 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            long result = solver.PartB;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }
    }
}