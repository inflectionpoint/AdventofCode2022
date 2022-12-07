namespace AoCwithCSharp
{
    public class SolveDay06 : SolverInt
    {
        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private readonly string InputFile = "";

        private string DataStream = "";

        /// <summary>
        /// The Answer to Part A
        /// </summary>
        override public int PartA => ComputePartA();

        /// <summary>
        /// The Answer to Part B
        /// </summary>
        override public int PartB => ComputePartB();


        //CONSTRUCTOR

        public SolveDay06(string data, bool isPath)
        {
            if (isPath)
            {
                InputFile = data;
                ManipulateData();
            }
            else
            {
                DataStream = data;
            }

        }


        //METHODS

        /// <summary>
        /// Logic to Transform Data to Solve Questions:
        /// 
        /// </summary>
        private void ManipulateData()
        {
            DataStream = File.ReadAllText(InputFile);

        }


        /// <summary>
        /// How many characters need to be processed before the first start-of-packet marker is detected?
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private int ComputeStream(int size)
        {
            string data = DataStream[..size];

            for (int i = size; i < DataStream.Length; i++)
            {
                if (data.Distinct().Count() == size)
                {
                    return i;
                }
                else
                {
                    data = data[1..];
                    data += DataStream[i];
                }
            }

            return -1;
        }


        /// <summary>
        /// Logic to Solve Question 1:
        /// Packet Size 4
        /// </summary>
        private int ComputePartA()
        {
            return ComputeStream(4);
        }

        /// <summary>
        /// Logic to Solve Question 2:
        /// Packet Size 14
        /// </summary>
        private int ComputePartB()
        {
            return ComputeStream(14);
        }
    }
}
