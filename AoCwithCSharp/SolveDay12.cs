namespace AoCwithCSharp
{
    public class SolveDay12 : SolverInt
    {
        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private readonly string InputFile;

        private int[,] HeightMap;
        private (int, int) Start;
        private (int, int) Finish;


        /// <summary>
        /// The Answer to Part A
        /// </summary>
        override public int PartA => ComputePartA();

        /// <summary>
        /// The Answer to Part B
        /// </summary>
        override public int PartB => ComputePartB();


        //CONSTRUCTOR
        public SolveDay12(string dataFilePath)
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
            var Data = File.ReadAllLines(InputFile);

            int Rows = Data.GetLength(0);
            int Cols = Data[0].Length;

            HeightMap = new int[Rows, Cols];
            int row = 0;

            foreach (string line in File.ReadLines(InputFile))
            {
                var z = line.ToCharArray().Select(x => x - 96).ToArray();

                for (int col = 0; col < z.Length; col++)
                {
                    if (z[col] == -13)
                    {
                        Start = (row, col);
                        HeightMap[row, col] = 0;
                    }
                    else if (z[col] == -27)
                    {
                        Finish = (row, col);
                        HeightMap[row, col] = 27;
                    }
                    else
                    {
                        HeightMap[row, col] = z[col];
                    }
                }

                row++;

            }
        }

        /// <summary>
        /// Logic to Solve Question 1:
        /// What is the fewest steps required to move from your current position to the location that should get the best signal?
        /// </summary>
        private int ComputePartA()
        {
            while (true)
            {

            }

            return 0;
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
