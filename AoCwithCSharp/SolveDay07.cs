using AoCwithCSharp.Supporting;

namespace AoCwithCSharp
{
    public class SolveDay07 : SolverInt
    {
        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private readonly string InputFile;

        private readonly Dictionary<string, Node> Nodes = new();

        /// <summary>
        /// The Answer to Part A
        /// </summary>
        override public int PartA => ComputePartA();

        /// <summary>
        /// The Answer to Part B
        /// </summary>
        override public int PartB => ComputePartB();


        //CONSTRUCTOR
        public SolveDay07(string dataFilePath)
        {
            InputFile = dataFilePath;
            ManipulateData();
        }


        //METHODS

        /// <summary>
        /// Logic to Transform Data to Solve Questions:
        /// Populate a Tree from the text file
        /// </summary>
        private void ManipulateData()
        {
            string currentPath = "";

            foreach (string line in File.ReadLines(InputFile))
            {
                var x = line.Replace("$ ", "").Split(" ");

                //CD = Change Directories 
                if (x[0] == "cd")
                {
                    //Move up a level
                    if (x[1] == "..")
                    {
                        //Shorten the path a level
                        currentPath = Nodes[currentPath].Parent;
                    }
                    //Move down a level
                    else
                    {
                        //Append to the path a directory level.
                        string dirPath = $"{currentPath}{x[1]}";

                        //Create new Empty Node with Path.
                        Nodes.Add(dirPath, new Node { Parent = currentPath, Size = 0, Type = "dir" });

                        //Reset Current Path
                        currentPath = dirPath;
                    }
                }
                else
                {
                    //not list command, not a directory (aka file)
                    if (x[0] != "ls" && x[0] != "dir")
                    {
                        //Get the file size
                        int size = int.Parse(x[0]);

                        //Append filename to current Path
                        string filePath = $"{currentPath}{x[1]}";

                        //Added Files to Structure, Not Required for Problem Set.
                        Nodes.Add(filePath, new Node { Parent = currentPath, Size = size, Type = "file" });

                        //Set the parent Path for the Loop
                        string parentPath = Nodes[filePath].Parent;

                        //Update the parent directory sizes
                        while (parentPath != "")
                        {
                            Nodes[parentPath].Size += size;
                            parentPath = Nodes[parentPath].Parent;

                        }
                    }
                }
            }
        }


        /// <summary>
        /// Logic to Solve Question 1:
        /// What is the sum of the total sizes of those directories?
        /// </summary>
        private int ComputePartA()
        {
            //Return a total size of directories that are smaller than 100,000.
            return Nodes.Select(x => x).Where(x => x.Value.Size <= 100_000
                && x.Value.Type == "dir").Select(y => y.Value.Size).Sum();
        }

        /// <summary>
        /// Logic to Solve Question 2:
        /// What is the total size of that directory?
        /// </summary>
        private int ComputePartB()
        {
            //Total Space Available: 70_000_000
            //Unused Space Required: 30_000_000
            //Return the smallest single directory that will result in sufficent free space. 

            int deltaRequired = 30000000 - (70000000 - Nodes["/"].Size);

            return Nodes.Select(x => x).Where(x => x.Value.Size >= deltaRequired
                && x.Value.Type == "dir").OrderBy(x => x.Value.Size).First().Value.Size;

        }
    }

    internal class Node
    {
        public string Parent { get; set; } = "";

        public int Size { get; set; } = 0;

        public string Type { get; set; } = "";

    }
}