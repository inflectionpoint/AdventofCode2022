using AdventofCode2022;

namespace AdventofCode2022Tests
{
    public class TestDay05
    {
        private readonly string basePathPuzzle;
        private readonly string basePathSample;
        private readonly ITestOutputHelper output;

        public TestDay05(ITestOutputHelper output)
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
            SolveDay05 puzzle = new(basePathSample);

            //Act
            string partA = puzzle.PartA;
            output.WriteLine(partA);

            //Assert
            Assert.Equal("CMZ", partA);
        }

        [Fact]
        public void TestCaseB()
        {
            //Arrange
            SolveDay05 puzzle = new(basePathSample);

            //Act
            string partB = puzzle.PartB;
            output.WriteLine(partB);

            //Assert
            Assert.Equal("MCD", partB);
        }

        [Fact]
        public void TestCaseANonZero()
        {
            //Arrange
            SolveDay05 puzzle = new(basePathPuzzle);

            //Act
            string partA = puzzle.PartA;
            output.WriteLine(partA);

            //Assert
            Assert.True(partA.Length > 0);
        }

        [Fact]
        public void TestCaseBNonZero()
        {
            //Arrange
            SolveDay05 puzzle = new(basePathPuzzle);

            //Act
            string partB = puzzle.PartB;
            output.WriteLine(partB);

            //Assert
            Assert.True(partB.Length > 0);
        }

    }
}