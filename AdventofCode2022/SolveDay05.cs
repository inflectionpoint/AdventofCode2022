using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AoCwithCSharp
{
    public class SolveDay05
    {
        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private readonly string InputFile;

        private readonly List<Stack<char>> Ship = new();
        private readonly List<char[]> chars = new();
        private readonly List<(int, int, int)> Actions = new();


        /// <summary>
        /// The Answer to Part A
        /// </summary>
        public string PartA => ComputePartA();

        /// <summary>
        /// The Answer to Part B
        /// </summary>
        public string PartB => ComputePartB();


        //CONSTRUCTOR
        public SolveDay05(string dataFilePath)
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
                //Check for "m" in move to denote action line parse.
                if (line.StartsWith('m'))
                {
                    var x = line.Split(" ");
                    Actions.Add((int.Parse(x[1]), int.Parse(x[3]), int.Parse(x[5])));
                }
                //Otherwise Ship Diagram Parsing.
                else
                {
                    chars.Add(line.ToCharArray());
                }
            }

            chars.Reverse();
            chars.RemoveRange(0, 2);

            for (int i = 0; i < (chars[0].Length + 1) / 4; i++)
            {
                Ship.Add(new Stack<char>());
            }

            foreach (var item in chars)
            {
                int index = 0;

                for (int i = 0; i < item.Length; i++)
                {
                    if (char.IsLetter(item[i]))
                    {
                        Ship[index].Push(item[i]);
                    }

                    index = (i + 1) / 4;
                }
            }
        }


        /// <summary>
        /// Common function to return the top container in each stack.
        /// </summary>
        /// <returns></returns>
        private string GetTopRow()
        {
            string ans = "";

            foreach (Stack<char> containerStack in Ship)
            {
                ans += containerStack.Peek().ToString();
            }

            return ans;
        }


        /// <summary>
        /// Logic to Solve Question 1:
        /// After the rearrangement procedure completes, what crate ends up on top of each stack?
        /// </summary>
        private string ComputePartA()
        {
            foreach ((int Count, int from, int dest) in Actions)
            {
                for (int i = 0; i < Count; i++)
                {
                    Ship[dest - 1].Push(Ship[from - 1].Pop());
                }
            }

            return GetTopRow();
        }

        /// <summary>
        /// Logic to Solve Question 2:
        /// After the rearrangement procedure completes, what crate ends up on top of each stack?
        /// </summary>
        private string ComputePartB()
        {
            Stack<char> temp = new();

            foreach ((int Count, int from, int dest) in Actions)
            {

                for (int i = 0; i < Count; i++)
                {
                    temp.Push(Ship[from - 1].Pop());
                }

                for (int i = 0; i < Count; i++)
                {
                    Ship[dest - 1].Push(temp.Pop());
                }
            }

            return GetTopRow();
        }
    }
}
