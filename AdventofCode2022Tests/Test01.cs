using AdventofCode2022;

namespace AdventofCode2022Tests
{
    public class Test01
    {
        private readonly ITestOutputHelper output;

        public Test01(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void CheckIfMaxCaloriesEquals()
        {
            //Arrange
            string path = @"C:\Users\APK\source\repos\AdventofCode2022\Sample01.txt";
            Solver01 puzzle = new(path);

            //Act
            int maxCalories = puzzle.FindMaxCalories();
            output.WriteLine(maxCalories.ToString());

            //Assert
            Assert.Equal(24000, maxCalories);

        }

        [Fact]
        public void ComputeNonZeroCalories()
        {
            //Arrange
            string path = @"C:\Users\APK\source\repos\AdventofCode2022\Input01.txt";
            Solver01 puzzle = new(path);

            //Act
            int maxCalories = puzzle.FindMaxCalories();
            output.WriteLine(maxCalories.ToString());

            //Assert
            Assert.True(maxCalories > 0);

        }

        [Fact]
        public void CheckIfTopThreeCaloriesEquals()
        {
            //Arrange
            string path = @"C:\Users\APK\source\repos\AdventofCode2022\Sample01.txt";
            Solver01 puzzle = new(path);

            //Act
            int topThreeCalories = puzzle.FindTopThreeCalories();
            output.WriteLine(topThreeCalories.ToString());

            //Assert
            Assert.Equal(45000, topThreeCalories);

        }

        [Fact]
        public void ComputeNonZeroTopThreeCalories()
        {
            //Arrange
            string path = @"C:\Users\APK\source\repos\AdventofCode2022\Input01.txt";
            Solver01 puzzle = new(path);

            //Act
            int topThreeCalories = puzzle.FindTopThreeCalories();
            output.WriteLine(topThreeCalories.ToString());

            //Assert
            Assert.True(topThreeCalories > 0);

        }


    }
}