namespace AoCwithCSharp
{
    public class SolveDay01
    {
        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private readonly string InputFile;

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


        //CONSTRUCTOR
        public SolveDay01(string dataFilePath)
        {
            Elves = new List<int>();
            InputFile = dataFilePath;
            PouplateElfData();
        }


        //METHODS

        /// <summary>
        /// Logic to Transform Data to Solve Questions:
        /// Populate the list of Elf from the text file
        /// </summary>
        private void PouplateElfData()
        {
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

            //Include Last Elf
            Elves.Add(calorieSum);
        }

        /// <summary>
        /// Part 1 Question:
        /// Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?
        /// </summary>
        private int FindMaxCalories()
        {
            return Elves.Max();
        }

        /// <summary>
        /// Part 2 Question:
        /// Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?
        /// </summary>
        private int FindTopThreeCalories()
        {
            return Elves.OrderByDescending(v => v).Take(3).Sum();
        }

    }
}
