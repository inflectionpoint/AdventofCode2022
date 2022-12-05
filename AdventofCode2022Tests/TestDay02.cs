using AdventofCode2022;

namespace AdventofCode2022Tests
{
    public class TestDay02
    {
        private readonly string basePathPuzzle;
        private readonly string basePathSample;
        private readonly ITestOutputHelper output;

        public TestDay02(ITestOutputHelper output)
        {
            this.output = output;
            string day = GetType().Name[7..];
            basePathPuzzle = Common.BasePath + $"Data - Puzzle\\Puzzle{day}.txt";
            basePathSample = Common.BasePath + $"Data - Sample\\Sample{day}.txt";
        }

        [Fact]
        public void CheckIfTotalScoreSimpleEquals()
        {
            //Arrange
            SolveDay02 puzzle = new(basePathSample);

            //Act
            int partA = puzzle.TotalScoreA;
            output.WriteLine(partA.ToString());

            //Assert
            Assert.Equal(15, partA);
        }

        [Fact]
        public void CheckIfTotalScoreComplexEquals()
        {
            //Arrange
            SolveDay02 puzzle = new(basePathSample);

            //Act
            int partB = puzzle.TotalScoreB;
            output.WriteLine(partB.ToString());

            //Assert
            Assert.Equal(12, partB);
        }

        [Fact]
        public void ComputesNonZeroTotalScoreSimple()
        {
            //Arrange
            SolveDay02 puzzle = new(basePathPuzzle);

            //Act
            int partA = puzzle.TotalScoreA;
            output.WriteLine(partA.ToString());

            //Assert
            Assert.True(partA > 0);
        }

        [Fact]
        public void ComputesNonZeroTotalScoreComplex()
        {
            //Arrange
            SolveDay02 puzzle = new(basePathPuzzle);

            //Act
            int partB = puzzle.TotalScoreB;
            output.WriteLine(partB.ToString());

            //Assert
            Assert.True(partB > 0);
        }

    }
}