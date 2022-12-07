namespace AoCwithCSharp
{
    public class SolveDay04
    {
        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private readonly string InputFile;

        private readonly List<int[]> Assigments = new();

        /// <summary>
        /// The Answer to Part A
        /// </summary>
        public int PartA => ComputePartA();

        /// <summary>
        /// The Answer to Part B
        /// </summary>
        public int PartB => ComputePartB();


        //CONSTRUCTOR
        public SolveDay04(string dataFilePath)
        {
            InputFile = dataFilePath;
            ManipulateData();
        }


        //METHODS

        /// <summary>
        /// Logic to Transform Data to Solve Questions:
        /// 
        /// </summary>
        private void ManipulateData()
        {
            foreach (string line in File.ReadLines(InputFile))
            {
                var a = line.Split(new char[] { ',', '-' });

                int i = 0;
                int[] vals = a.Where(x => int.TryParse(x, out i)).Select(x => i).ToArray();

                Assigments.Add(vals);

            }
        }

        /// <summary>
        /// Logic to Solve Question 1:
        /// In how many assignment pairs does one range fully contain the other?
        /// </summary>
        private int ComputePartA()
        {
            int duplicates = 0;

            foreach (var ints in Assigments)
            {
                if (ints[0] <= ints[2] && ints[1] >= ints[3] ||
                    ints[0] >= ints[2] && ints[1] <= ints[3])
                {
                    duplicates += 1;
                }
            }

            return duplicates;
        }

        /// <summary>
        /// Logic to Solve Question 2:
        /// 
        /// </summary>
        private int ComputePartB()
        {
            int duplicates = 0;

            foreach (var ints in Assigments)
            {
                if (!(ints[1] < ints[2] || ints[3] < ints[0]))
                {
                    duplicates += 1;
                }
            }

            return duplicates;
        }
    }
}
