using AoCwithCSharp;

namespace AoCwithCSharpTests
{
    public class TestDay06
    {
        private readonly string basePathPuzzle;
        private readonly string basePathSample;
        private readonly ITestOutputHelper output;

        public TestDay06(ITestOutputHelper output)
        {
            this.output = output;
            string day = GetType().Name[7..];
            basePathPuzzle = Common.BasePath + $"Data - Puzzle\\Puzzle{day}.txt";
            basePathSample = Common.BasePath + $"Data - Sample\\Sample{day}.txt";
        }

        [Fact]
        public void TestCaseA()
        {
            //Arrange
            SolveDay06 puzzle = new(basePathSample);

            //Act
            int partA = puzzle.PartA;
            output.WriteLine(partA.ToString());

            //Assert
            Assert.Equal(7, partA);
        }

        [Fact]
        public void TestCaseB()
        {
            //Arrange
            SolveDay06 puzzle = new(basePathSample);

            //Act
            int partB = puzzle.PartB;
            output.WriteLine(partB.ToString());

            //Assert
            Assert.Equal(19, partB);
        }

        [Fact]
        public void TestCaseANonZero()
        {
            //Arrange
            SolveDay06 puzzle = new(basePathPuzzle);

            //Act
            int partA = puzzle.PartA;
            output.WriteLine(partA.ToString());

            //Assert
            Assert.True(partA > 0);
        }

        [Fact]
        public void TestCaseBNonZero()
        {
            //Arrange
            SolveDay06 puzzle = new(basePathPuzzle);

            //Act
            int partB = puzzle.PartB;
            output.WriteLine(partB.ToString());

            //Assert
            Assert.True(partB > 0);
        }

    }
}