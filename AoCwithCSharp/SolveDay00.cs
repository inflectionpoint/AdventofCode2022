namespace AoCwithCSharp
{
    public class SolveDay00 : SolverInt
    {
        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private readonly string InputFile;

        /// <summary>
        /// The Answer to Part A
        /// </summary>
        override public int PartA => ComputePartA();

        /// <summary>
        /// The Answer to Part B
        /// </summary>
        override public int PartB => ComputePartB();


        //CONSTRUCTOR
        public SolveDay00(string dataFilePath)
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
