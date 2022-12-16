using Microsoft.Win32;
using System.Collections;
using System.Formats.Asn1;

namespace AoCwithCSharp
{
    public class SolveDay10 
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

        private readonly Queue<(Actions task, int value)> instructions = new();
        private readonly Dictionary<int,int> Signals = new();
        public List<string> Display = new();
        private string CRT = "";

        /// <summary>
        /// The Answer to Part A
        /// </summary>
        public int PartA => ComputePartA();

        /// <summary>
        /// The Answer to Part B
        /// </summary>
        public string PartB => ComputePartB();


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
                    //noop takes one cycle to complete. It has no other effect.
                    instructions.Enqueue((Actions.noop, 0));
                }
                else
                {
                    //addx V takes two cycles to complete. After two cycles, the X register is increased by the value V.
                    instructions.Enqueue((Actions.addx, int.Parse(x[1])));
                }
            }

            ProcessSignals();
        }

        private void GenerateCRT(int clock, int register)
        {
            int pixel = clock % 40; //clock - (40 * (clock / 40)) - 1;

            if (Math.Abs(pixel - register) < 2)
            {
                CRT += "#";
            }
            else
            {
                CRT += ".";
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void ProcessSignals()
        {
            //The CPU has a single register, X, which starts with the value 1. 
            int register = 1;
            int clock = 0;
            int wait = 0;
            int value = 0;

            while (instructions.Count > 0)
            {
                clock++;

                if (wait == 0)
                {
                    register += value;
                    Signals.Add(clock, register);
                    GenerateCRT(clock, register);

                    var instruction = instructions.Dequeue();

                    if (instruction.task is Actions.noop)
                    {
                        value = instruction.value;
                    }
                    else if (instruction.task is Actions.addx)
                    {
                        value = instruction.value;
                        wait++;
                    }
                }
                else
                {
                    Signals.Add(clock, register);
                    GenerateCRT(clock, register);
                    wait--;
                }
            }
        }


        /// <summary>
        /// Logic to Solve Question 1:
        /// What is the sum of these six signal strengths?
        /// </summary>
        private int ComputePartA()
        {

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
        /// What eight capital letters appear on your CRT?
        /// </summary>
        private string ComputePartB()
        {
            //Sprite 3pixel wide, x defines middle pixel.
            //Display Size : 6 Rows, 40 Columns.

            for (int i = 0; i < 6; i++)
            {
                int row = i * 40;
                Display.Add(CRT.Substring(row, 40));
            };

            return CRT;
        }
    }
}
