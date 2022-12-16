using AoCwithCSharp;

namespace AoCwithCSharpTests
{
    public class TestDay10
    {
        private readonly string day;
        private readonly ITestOutputHelper output;

        private const string AnswerPartB = 
            "##..##..##..##..##..##..##..##..##..##.." +
            "###...###...###...###...###...###...###." +
            "####....####....####....####....####...." +
            "#####.....#####.....#####.....#####....." +
            "######......######......######......####" +
            "#######.......#######.......#######....."; 

        public TestDay10(ITestOutputHelper output)
        {
            this.output = output;
            day = GetType().Name[7..];
        }

        [Theory]
        [InlineData("Sample", 13140)]
        [InlineData("Puzzle", 17840)]
        public void TestPartA(string type, int expect)
        {
            //Arrange
            SolveDay10 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            int result = solver.PartA;
            output.WriteLine(result.ToString());

            //Assert
            Assert.Equal(expect, result);

        }

        [Theory]
        [InlineData("Sample", AnswerPartB)]
        [InlineData("Puzzle", "")]  //EALGULPG
        public void TestPartB(string type, string expect)
        {
            //Arrange
            SolveDay10 solver = new(Common.BasePath + $"Data - {type}\\{type}{day}.txt");

            //Act
            string result = solver.PartB;
            output.WriteLine(result.ToString());
            output.WriteLine(solver.Display.ToString());

            //Assert
            Assert.Equal(expect, result);

        }
    }
}