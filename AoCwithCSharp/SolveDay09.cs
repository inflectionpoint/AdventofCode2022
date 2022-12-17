using System.Drawing;

namespace AoCwithCSharp
{
    public class SolveDay09 : SolverInt
    {
        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private readonly string InputFile;

        private readonly List<(string direction, int distance)> Movements = new();

        /// <summary>
        /// The Answer to Part A
        /// </summary>
        override public int PartA => ComputePartA();

        /// <summary>
        /// The Answer to Part B
        /// </summary>
        override public int PartB => ComputePartB();


        //CONSTRUCTOR
        public SolveDay09(string dataFilePath)
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
                Movements.Add((x[0], int.Parse(x[1])));
            }
        }

        private Point MoveFollower(Point head, Point tail)
        {
            Size delta = new(head.X - tail.X, head.Y - tail.Y);

            string derp = delta.ToString();

            switch (derp)
            {
                //EAST
                case "{Width=2, Height=0}":
                    tail.X++;
                    return tail;
                //WEST
                case "{Width=-2, Height=0}":
                    tail.X--;
                    return tail;
                //NORTH
                case "{Width=0, Height=2}":
                    tail.Y++;
                    return tail;
                //SOUTH
                case "{Width=0, Height=-2}":
                    tail.Y--;
                    return tail;
                //NORTH EAST
                case "{Width=2, Height=1}":
                case "{Width=1, Height=2}":
                case "{Width=2, Height=2}":
                    tail.X++;
                    tail.Y++;
                    return tail;
                //NORTH WEST
                case "{Width=-2, Height=1}":
                case "{Width=-1, Height=2}":
                case "{Width=-2, Height=2}":
                    tail.X--;
                    tail.Y++;
                    return tail;
                //SOUTH EAST
                case "{Width=2, Height=-1}":
                case "{Width=1, Height=-2}":
                case "{Width=2, Height=-2}":
                    tail.X++;
                    tail.Y--;
                    return tail;
                //SOUTH WEST
                case "{Width=-2, Height=-1}":
                case "{Width=-1, Height=-2}":
                case "{Width=-2, Height=-2}":
                    tail.X--;
                    tail.Y--;
                    return tail;
                //NO MOVE
                default:
                    return tail;
            }
        }

        /// <summary>
        /// The positional shift based on the direction provided.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private static Point MoveHead(string direction, Point head)
        {
            switch (direction)
            {
                case "U":
                    head.Y++;
                    return head;
                case "D":
                    head.Y--;
                    return head;
                case "L":
                    head.X--;
                    return head;
                case "R":
                    head.X++;
                    return head;
                default:
                    return head;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="knots"></param>
        /// <param name="rope"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private List<Point> UpdateRope(int knots, List<Point> rope, string direction)
        {
            List<Point> newRope = new()
            {
                MoveHead(direction, rope[0])
            };

            for (int knot = 1; knot < knots; knot++)
            {
                newRope.Add(MoveFollower(newRope[knot - 1], rope[knot]));
            }

            return newRope;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="knots"></param>
        /// <returns></returns>
        private int Simulate(int knots)
        {
            List<Point> rope = new();

            for (int i = 0; i < knots; i++)
            {
                rope.Add(new Point(0, 0));
            }

            List<string> tailPositions = new()
            {
                rope.Last().ToString()
            };

            //Total Movement required
            foreach ((string direction, int steps) in Movements)
            {
                //Intermediate movement steps
                for (int step = 0; step < steps; step++)
                {
                    //Resulting Movement of the Rope Knots
                    rope = UpdateRope(knots, rope, direction);

                    tailPositions.Add(rope.Last().ToString());
                }
            }

            return tailPositions.Distinct().Count();
        }

        /// <summary>
        /// Logic to Solve Question 1:
        /// How many positions does the tail of the rope visit at least once?
        /// </summary>
        private int ComputePartA()
        {
            return Simulate(2);
        }

        /// <summary>
        /// Logic to Solve Question 2:
        /// How many positions does the tail of the rope visit at least once?
        /// </summary>
        private int ComputePartB()
        {
            return Simulate(10);
        }
    }
}
