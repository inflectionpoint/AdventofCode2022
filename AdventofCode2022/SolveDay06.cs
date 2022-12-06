namespace AoCwithCSharp
{
    public class SolveDay06
    {
        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private readonly string InputFile;

        private string datastream;

        /// <summary>
        /// The Answer to Part A
        /// </summary>
        public int PartA => ComputePartA();

        /// <summary>
        /// The Answer to Part B
        /// </summary>
        public int PartB => ComputePartB();


        //CONSTRUCTOR
        public SolveDay06(string dataFilePath)
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
            datastream = File.ReadAllText(InputFile);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private int ComputeStream(int size)
        {
            string data = datastream[..size];

            for (int i = size; i < datastream.Length; i++)
            {
                if (data.Distinct().Count() == size)
                {
                    return i;
                }
                else
                {
                    data = data[1..];
                    data += datastream[i];
                }
            }

            return -1;
        }


        /// <summary>
        /// Logic to Solve Question 1:
        /// How many characters need to be processed before the first start-of-packet marker is detected?
        /// </summary>
        private int ComputePartA()
        {
            return ComputeStream(4);
        }

        /// <summary>
        /// Logic to Solve Question 2:
        /// 
        /// </summary>
        private int ComputePartB()
        {
            return ComputeStream(14);
        }
    }
}
