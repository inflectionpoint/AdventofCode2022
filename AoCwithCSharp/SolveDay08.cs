namespace AoCwithCSharp
{
    public class SolveDay08 : SolverInt
    {
        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private readonly string InputFile;

        private (int height, bool isVisible, int score)[,] Trees;
        private int Rows = 0;
        private int Cols = 0;

        /// <summary>
        /// The Answer to Part A
        /// </summary>
        override public int PartA => ComputePartA();

        /// <summary>
        /// The Answer to Part B
        /// </summary>
        override public int PartB => ComputePartB();


        //CONSTRUCTOR
        public SolveDay08(string dataFilePath)
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

            Rows = Data.GetLength(0);
            Cols = Data[0].Length;

            Trees = new (int, bool, int)[Rows, Cols];

            for (int i = 0; i < Rows; i++)
            {
                var d = Data[i].ToCharArray();

                for (int j = 0; j < Cols; j++)
                {
                    int height = int.Parse(d[j].ToString());

                    //Intialize Tree Heights, All Edge Trees ARE visible. 
                    if (i == 0 || j == 0 || i == Rows - 1 || j == Cols - 1)
                    {
                        Trees[i, j] = (height, true, 0);
                    }
                    //Assume all internal trees are NOT visible
                    else
                    {
                        Trees[i, j] = (height, false, 0);
                    }

                }
            }
        }

        /// <summary>
        /// Logic to Solve Question 1:
        /// How many trees are visible from outside the grid?
        /// </summary>
        private int ComputePartA()
        {
            //Zero -> Shortest
            //Nine -> Tallest

            int totalTrees = 0;

            //View from Left:
            for (int row = 1; row < Rows - 1; row++)
            {
                int heightLimit = Trees[row, 0].height;

                for (int col = 1; col < Cols - 1; col++)
                {
                    int height = Trees[row, col].height;

                    //Tree Max height exit
                    if (heightLimit == 9)
                    {
                        break;
                    }

                    if (height > heightLimit)
                    {
                        heightLimit = height;
                        Trees[row, col] = (height, true, 0);
                    }
                }
            }

            //View from Right:
            for (int row = 1; row < Rows - 1; row++)
            {
                int heightLimit = Trees[row, Cols - 1].height;

                for (int col = Cols - 2; col > 0; col--)
                {
                    int height = Trees[row, col].height;

                    //Tree Max height exit
                    if (heightLimit == 9)
                    {
                        break;
                    }

                    if (height > heightLimit)
                    {
                        heightLimit = height;
                        Trees[row, col] = (height, true, 0);
                    }

                }
            }

            //View from Above:
            for (int col = 1; col < Cols - 1; col++)
            {
                int heightLimit = Trees[0, col].height;

                for (int row = 1; row < Rows - 1; row++)
                {
                    int height = Trees[row, col].height;

                    //Tree Max height exit
                    if (heightLimit == 9)
                    {
                        break;
                    }

                    if (height > heightLimit)
                    {
                        heightLimit = height;
                        Trees[row, col] = (height, true, 0);
                    }
                }
            }

            //View from Below:
            for (int col = 1; col < Cols - 1; col++)
            {
                int heightLimit = Trees[Rows - 1, col].height;

                for (int row = Rows - 2; row > 0; row--)
                {
                    int height = Trees[row, col].height;

                    //Tree Max height exit
                    if (heightLimit == 9)
                    {
                        break;
                    }

                    if (height > heightLimit)
                    {
                        heightLimit = height;
                        Trees[row, col] = (height, true, 0);
                    }
                }
            }

            //Count all the visible trees:
            foreach (var tree in Trees)
            {
                if (tree.isVisible)
                {
                    totalTrees++;
                }
            }

            return totalTrees;
        }

        /// <summary>
        /// Logic to Solve Question 2:
        /// What is the highest scenic score possible for any tree?
        /// </summary>
        private int ComputePartB()
        {
            //Min Tree Score is 1, Edges are always 0

            int maxScore = 0;

            for (int row = 1; row <= Rows - 2; row++)
            {
                for (int col = 1; col <= Cols - 2; col++)
                {
                    int tree;
                    int myTree = Trees[row, col].height;

                    int scoreLeft = 0;
                    int scoreRight = 0;
                    int scoreAbove = 0;
                    int scoreBelow = 0;

                    //Look Left
                    for (int i = 1; i <= col; i++)
                    {
                        tree = Trees[row, col - i].height;

                        if (tree < myTree)
                        {
                            scoreLeft++;
                        }
                        else
                        {
                            scoreLeft++;
                            break;
                        }
                    }
                    //Look Right
                    for (int i = 1; i < (Cols - col); i++)
                    {
                        tree = Trees[row, col + i].height;
                        if (tree < myTree)
                        {
                            scoreRight++;
                        }
                        else
                        {
                            scoreRight++;
                            break;
                        }
                    }
                    //Look Above
                    for (int i = 1; i <= row; i++)
                    {
                        tree = Trees[row - i, col].height;
                        if (tree < myTree)
                        {
                            scoreAbove++;
                        }
                        else
                        {
                            scoreAbove++;
                            break;
                        }
                    }
                    //Look Below
                    for (int i = 1; i < (Rows - row); i++)
                    {
                        tree = Trees[row + i, col].height;
                        if (tree < myTree)
                        {
                            scoreBelow++;
                        }
                        else
                        {
                            scoreBelow++;
                            break;
                        }

                    }

                    int score = scoreLeft * scoreRight * scoreAbove * scoreBelow;

                    Trees[row, col] = (Trees[row, col].height, Trees[row, col].isVisible, score);

                    if (score > maxScore)
                    {
                        maxScore = score;
                    }
                }
            }

            return maxScore;
        }
    }
}
