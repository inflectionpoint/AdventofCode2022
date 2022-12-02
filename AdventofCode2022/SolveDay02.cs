using System.Text.RegularExpressions;
using static System.Formats.Asn1.AsnWriter;

namespace AdventofCode2022
{
    public class SolveDay02
    {
        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private string InputFile;

        public List<(string A, string B)> GameResults { get; private set; } = new();

        /// <summary>
        /// The Answer to Part A
        /// </summary>
        public int PartA => ComputePartA();

        /// <summary>
        /// The Answer to Part B
        /// </summary>
        public int PartB => ComputePartB();


        //CONSTRUCTOR
        public SolveDay02(string dataFilePath)
        {
            InputFile = dataFilePath;
            ManipulateData();
        }
        

        //METHODS

        /// <summary>
        /// Logic to Transform Data to Solve Questions:
        /// Parses and populates a list of characters representing throws
        /// </summary>
        private void ManipulateData()
        {
            foreach (string line in File.ReadLines(InputFile))
            {
                string[] parts = line.Split(' ');
                GameResults.Add((parts[0], parts[1]));
            }
        }

        /// <summary>
        /// Determines the score value of 
        /// </summary>
        private static int ComputeScore(string playerA, string playerB)
        {
            var score = playerB switch
            {
                //A,X: Rock, Value(1)
                "X" => 1,
                //B,Y: Paper, Value(2)
                "Y" => 2,
                //C,Z: Scissors, Value(3)
                "Z" => 3,
                _ => 0,
            };

            score += ComputeOutcomeScore(playerA + playerB);
            
            return score;

        }
        
        /// <summary>
        /// Determines the score value based on the match outcome.
        /// </summary>
        private static int ComputeOutcomeScore(string match)
        {
            return match switch
            {
                //Wins: Value (6)
                "AY" or "BZ" or "CX" => 6,
                //Draw: Value (3)
                "AX" or "BY" or "CZ" => 3,
                //Loss: Value (0)
                _ => 0,
            };
        }

        /// <summary>
        /// Determines the required throw based on the desired match outcome.
        /// </summary>
        private static string ComputeThrow(string match)
        {
            return match switch
            {
                //Wins Required: (Z)
                "AZ" => "Y",
                "BZ" => "Z",
                "CZ" => "X",
                
                //Draw Required: (Y)
                "AY" => "X",
                "BY" => "Y",
                "CY" => "Z",

                //Loss Required: (X)
                "AX" => "Z",
                "BX" => "X",
                "CX" => "Y",

                _ => "",
            };
        }


        /// <summary>
        /// Logic to Solve Question 1:
        /// What would your total score be if everything goes exactly according to your strategy guide?
        /// </summary>
        private int ComputePartA()
        {
            int scoreTotal = 0;

            foreach (var (playerA, playerB) in GameResults)
            {
                scoreTotal += ComputeScore(playerA, playerB);
            }

            return scoreTotal;
        }

        /// <summary>
        /// Logic to Solve Question 2:
        /// What would your total score be if everything goes exactly according to your strategy guide?
        /// </summary>
        private int ComputePartB()
        {
            int scoreTotal = 0;

            foreach (var (opponent, result) in GameResults)
            {
                string mine = ComputeThrow(opponent + result);

                scoreTotal += ComputeScore(opponent, mine);
            }

            return scoreTotal;
        }
    }
}
