namespace AoCwithCSharp
{
    public class SolveDay10 : SolverInt
    {
        enum Actions
        {
            noop,
            addx
        }

        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private readonly string InputFile;

        private readonly Queue<(Actions, int)> instructions = new();
        private readonly Dictionary<int,int> Signals = new();

        /// <summary>
        /// The Answer to Part A
        /// </summary>
        override public int PartA => ComputePartA();

        /// <summary>
        /// The Answer to Part B
        /// </summary>
        override public int PartB => ComputePartB();


        //CONSTRUCTOR
        public SolveDay10(string dataFilePath)
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
                var x = line.Split(" ");
                
                if (x[0] == "noop")
                {
                    instructions.Enqueue((Actions.noop, 0));
                }
                else
                {
                    instructions.Enqueue((Actions.addx, int.Parse(x[1])));
                }
            }
        }

        /// <summary>
        /// Logic to Solve Question 1:
        /// What is the sum of these six signal strengths?
        /// </summary>
        private int ComputePartA()
        {
            int clock = 0;
            int register = 1;


            foreach ((Actions action, int value) in instructions)
            {
                if (action is Actions.noop)
                {
                    Signals.Add(clock, register);
                }
                else
                {
                    Signals.Add(clock, register);
                }
            }


            //Signals to Index
            List<int> cycles = new() { 20, 60, 100, 140, 180, 220 };

            int totalSignal = 0;

            //Signal Strength is Cycle * Register
            foreach (int cycle in cycles)
            {
                totalSignal += cycle * Signals[cycle];
            }
            
            return totalSignal;

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
