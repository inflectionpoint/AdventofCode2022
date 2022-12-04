namespace AdventofCode2022
{
    public class SolveDay00
    {
        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private readonly string InputFile;

        private List<List<int>> Assigments = new();

        /// <summary>
        /// The Answer to Part A
        /// </summary>
        public int PartA => ComputePartA();

        /// <summary>
        /// The Answer to Part B
        /// </summary>
        public int PartB => ComputePartB();


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
                var a = line.Split(",");
                var b = a[0].Split("-");
                var c = a[1].Split("-");

                List<int> groups = new()
                {
                    int.Parse(b[0]),
                    int.Parse(b[1]),
                    int.Parse(c[0]),
                    int.Parse(c[1])
                };

                Assigments.Add(groups);

            }
        }

        /// <summary>
        /// Logic to Solve Question 1:
        /// In how many assignment pairs does one range fully contain the other?
        /// </summary>
        private int ComputePartA()
        {
            int duplicates = 0;

            foreach (List<int> assigment in Assigments)
            {
                if ((assigment[0] <= assigment[2] &&
                    assigment[1] >= assigment[3]) ||
                    (assigment[0] >= assigment[2] &&
                    assigment[1] <= assigment[3]))
                {
                    duplicates++;
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

            foreach (List<int> assigment in Assigments)
            {
                //Full Overlap
                if ((assigment[0] <= assigment[2] &&
                    assigment[1] >= assigment[3]) ||
                    (assigment[0] >= assigment[2] &&
                    assigment[1] <= assigment[3]))
                {
                    duplicates++;
                }

                //Matching Boundry 
                else if (assigment[0] == assigment[2] || assigment[0] == assigment[3])
                {
                    duplicates++;
                }
                //Matching Boundry
                else if (assigment[1] == assigment[2] || assigment[1] == assigment[3])
                {
                    duplicates++;
                }
                //Partial Overlap
                else if (assigment[0] >= assigment[2] && assigment[0] <= assigment[3])
                {
                    duplicates++;
                }
                else if (assigment[1] >= assigment[2] && assigment[1] <= assigment[3])
                {
                    duplicates++;
                }
                else if (assigment[2] >= assigment[0] && assigment[2] <= assigment[1])
                {
                    duplicates++;
                }
                else if (assigment[3] >= assigment[0] && assigment[3] <= assigment[1])
                {
                    duplicates++;
                }

            }

            return duplicates;
        }
    }
}
