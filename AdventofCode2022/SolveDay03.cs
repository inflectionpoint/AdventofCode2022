namespace AdventofCode2022
{
    public class SolveDay03
    {
        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private readonly string InputFile;

        public List<string> Rucksacks { get; private set; } = new List<string>();

        /// <summary>
        /// The Answer to Part A
        /// </summary>
        public int PrioritySumA => ComputePriortySumA();

        /// <summary>
        /// The Answer to Part B
        /// </summary>
        public int PriortySumB => ComputePriortySumB();


        //CONSTRUCTOR
        public SolveDay03(string dataFilePath)
        {
            InputFile = dataFilePath;
            ManipulateData();
        }

        //METHODS

        /// <summary>
        /// Logic to Transform Data to Solve Questions:
        /// What is the sum of the priorities of those item types?
        /// </summary>
        private void ManipulateData()
        {
            foreach (string line in File.ReadLines(InputFile))
            {
                Rucksacks.Add(line);
            }
        }

        private int GetPriortyValue(int val)
        {
            //Char codes 97 to 122 are lowercase letters
            if (val > 96)
            {
                //a=1, z=26
                return val - 96;
            }
            //Char codes 65 to 90 are Uppercase letters
            else
            {
                //A=27, Z=52
                return val - 38;
            }
        }

        /// <summary>
        /// Logic to Solve Question 1:
        /// What is the sum of the priorities of those item types?
        /// </summary>
        private int ComputePriortySumA()
        {
            int prioritySum = 0;

            foreach (string rucksack in Rucksacks)
            {
                int size = rucksack.Length / 2;

                char[] compartA = rucksack[..size].ToCharArray();
                char[] compartB = rucksack[size..].ToCharArray();

                int common = compartA.Intersect(compartB).ToArray()[0];

                prioritySum += GetPriortyValue(common);
            }

            return prioritySum;
        }

        /// <summary>
        /// Logic to Solve Question 2:
        /// What is the sum of the priorities of those item types?
        /// </summary>
        private int ComputePriortySumB()
        {
            int prioritySum = 0;

            for (int i = 0; i < Rucksacks.Count; i += 3)
            {
                char[] A = Rucksacks[i + 0].ToCharArray();
                char[] B = Rucksacks[i + 1].ToCharArray();
                char[] C = Rucksacks[i + 2].ToCharArray();

                int badge = A.Intersect(B).Intersect(C).ToArray()[0];

                prioritySum += GetPriortyValue(badge);
            }

            return prioritySum;
        }
    }
}
