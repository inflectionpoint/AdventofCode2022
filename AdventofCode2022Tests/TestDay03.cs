using AdventofCode2022;

namespace AdventofCode2022Tests
{
    public class TestDay03
    {
        private readonly string basePathPuzzle;
        private readonly string basePathSample;
        private readonly ITestOutputHelper output;

        public TestDay03(ITestOutputHelper output)
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
            SolveDay03 puzzle = new(basePathSample);

            //Act
            int partA = puzzle.PrioritySumA;
            output.WriteLine(partA.ToString());

            //Assert
            Assert.Equal(157, partA);
        }

        [Fact]
        public void TestCaseB()
        {
            //Arrange
            SolveDay03 puzzle = new(basePathSample);

            //Act
            int partB = puzzle.PriortySumB;
            output.WriteLine(partB.ToString());

            //Assert
            Assert.Equal(70, partB);
        }

        [Fact]
        public void TestCaseANonZero()
        {
            //Arrange
            SolveDay03 puzzle = new(basePathPuzzle);

            //Act
            int partA = puzzle.PrioritySumA;
            output.WriteLine(partA.ToString());

            //Assert
            Assert.True(partA > 0);
        }

        [Fact]
        public void TestCaseBNonZero()
        {
            //Arrange
            SolveDay03 puzzle = new(basePathPuzzle);

            //Act
            int partB = puzzle.PriortySumB;
            output.WriteLine(partB.ToString());

            //Assert
            Assert.True(partB > 0);
        }

    }
}