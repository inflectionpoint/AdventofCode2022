using AdventofCode2022;

namespace AdventofCode2022Tests
{
    public class TestDay01
    {
        private readonly string basePathPuzzle;
        private readonly string basePathSample;
        private readonly ITestOutputHelper output;

        public TestDay01(ITestOutputHelper output)
        {
            this.output = output;
            string day = GetType().Name.Substring(7);
            basePathPuzzle = Common.BasePath + $"Input{day}.txt";
            basePathSample = Common.BasePath + $"Sample{day}.txt";
        }

        [Fact]
        public void CheckIfMaxCaloriesEquals()
        {
            //Arrange
            SolveDay01 puzzle = new(basePathSample);

            //Act
            int maxCalories = puzzle.MaxCalories;
            output.WriteLine(maxCalories.ToString());

            //Assert
            Assert.Equal(24000, maxCalories);

        }

        [Fact]
        public void ComputeNonZeroCalories()
        {
            //Arrange
            SolveDay01 puzzle = new(basePathPuzzle);

            //Act
            int maxCalories = puzzle.MaxCalories;
            output.WriteLine(maxCalories.ToString());

            //Assert
            Assert.True(maxCalories > 0);

        }

        [Fact]
        public void CheckIfTopThreeCaloriesEquals()
        {
            //Arrange
            SolveDay01 puzzle = new(basePathSample);

            //Act
            int topThreeCalories = puzzle.TopThreeCalories;
            output.WriteLine(topThreeCalories.ToString());

            //Assert
            Assert.Equal(45000, topThreeCalories);

        }

        [Fact]
        public void ComputeNonZeroTopThreeCalories()
        {
            //Arrange
            SolveDay01 puzzle = new(basePathPuzzle);

            //Act
            int topThreeCalories = puzzle.TopThreeCalories;
            output.WriteLine(topThreeCalories.ToString());

            //Assert
            Assert.True(topThreeCalories > 0);

        }
    }
}