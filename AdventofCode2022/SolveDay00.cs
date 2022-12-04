namespace AdventofCode2022
{
    public class SolveDay04
    {
        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private readonly string InputFile;

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
                Console.WriteLine(line);
            }
        }

        /// <summary>
        /// Logic to Solve Question 1:
        /// 
        /// </summary>
        private int ComputePartA()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Logic to Solve Question 2:
        /// 
        /// </summary>
        private int ComputePartB()
        {
            throw new NotImplementedException();
        }
    }
}
