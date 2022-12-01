namespace AdventofCode2022
{
    public class SolveDay01
    {
        //Properties

        /// <summary>
        /// File path for the data source
        /// </summary>
        private string InputFile;
        
        /// <summary>
        /// A list elves with total calorie count for each elf
        /// </summary>
        public List<int> Elves { get; private set; }

        /// <summary>
        /// The Answer to Part A
        /// </summary>
        public int MaxCalories => FindMaxCalories(); 
        
        /// <summary>
        /// The Answer to Part B
        /// </summary>
        public int TopThreeCalories => FindTopThreeCalories();

        /// <summary>
        /// Generate the solver with the required 
        /// </summary>
        /// <param name="path"></param>
        public SolveDay01(string dataFilePath)
        {
            Elves = new List<int>();
            InputFile = dataFilePath;
            PouplateElfData();
        }

        /// <summary>
        /// Logic to Transform Data to Solve Questions:
        /// Populate the list of Elf from the text file
        /// </summary>
        private void PouplateElfData()
        {
            //Elf Identifier
            int calorieSum = 0;

            //Parse every line in the Data file
            foreach (string line in File.ReadLines(InputFile))
            {
                //If the line is empty, create a new elf
                if (line is "")
                {
                    //Add new Elf to List
                    Elves.Add(calorieSum);

                    //Reset calorie total
                    calorieSum = 0;
                }
                //otherwise add calories to the exisitng elf total
                else
                {
                    calorieSum += int.Parse(line);
                }
            }

            //Last Elf
            Elves.Add(calorieSum);
        }

        /// <summary>
        /// Part 1 Question:
        /// Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?
        /// </summary>
        /// <returns></returns>
        private int FindMaxCalories()
        {
            return Elves.Max();
        }

        /// <summary>
        /// Part 2 Question:
        /// Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?
        /// </summary>
        /// <returns></returns>
        private int FindTopThreeCalories()
        {
            return Elves.OrderByDescending(v => v).Take(3).Sum();
        }

    }
}
