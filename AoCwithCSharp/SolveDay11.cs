namespace AoCwithCSharp
{
    public class SolveDay11 //
    {
        //PROPERTIES

        /// <summary>
        /// File path for the data source
        /// </summary>
        private readonly string InputFile;

        private readonly Dictionary<int, Monkey> Monkeys = new();

        private long Factor = 0;

        /// <summary>
        /// The Answer to Part A
        /// </summary>
        public long PartA => ComputePartA();

        /// <summary>
        /// The Answer to Part B
        /// </summary>
        public long PartB => ComputePartB();


        //CONSTRUCTOR
        public SolveDay11(string dataFilePath)
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
            string input = File.ReadAllText(InputFile);
            var x = input.Split('\n').ToList();

            for (int i = 0; i < x.Count; i += 7)
            {
                Monkey monkey = new();

                Queue<long> worries = new();

                var rowA = x[i + 1][18..].Replace(" ", "").Split(",").ToList();
                var rowB = x[i + 2][23..].Split(" ").ToList();
                var rowC = x[i + 3][21..].ToString();
                var rowD = x[i + 4][29..].ToString();
                var rowE = x[i + 5][30..].ToString();

                foreach (var item in rowA)
                {
                    worries.Enqueue(long.Parse(item));
                }

                monkey.WorryItems = worries;
                monkey.OperationType = rowB[0];
                monkey.TestValue = long.Parse(rowC);
                monkey.Recipients = (int.Parse(rowD), int.Parse(rowE));

                if (rowB[1].Contains("old"))
                {
                    monkey.OperationValue = 0;
                }
                else
                {
                    monkey.OperationValue = long.Parse(rowB[1]);
                }

                Monkeys.Add(i / 7, monkey);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rounds"></param>
        /// <param name="isWorried"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        private long MonkeyBuisness(int rounds, bool isWorried, long factor)
        {

            for (int i = 0; i < rounds; i++)
            {
                foreach (var monkey in Monkeys.Values)
                {
                    List<(int id, long val)> changes = monkey.MonkeyAround(isWorried, factor);

                    foreach (var (id, val) in changes)
                    {
                        Monkeys[id].WorryItems.Enqueue(val);
                    }
                }
            }

            return Monkeys.Select(x => x.Value.Inspections)
                          .OrderByDescending(x => x)
                          .Take(2)
                          .Aggregate((x, y) => x * y);
        }


        /// <summary>
        /// Logic to Solve Question 1:
        /// 
        /// </summary>
        private long ComputePartA()
        {
            return MonkeyBuisness(20, true, 1);

        }

        /// <summary>
        /// Logic to Solve Question 2:
        /// 
        /// </summary>
        private long ComputePartB()
        {
            //Common Value between all divisors
            var factor = Monkeys
                .Select(m => m.Value.TestValue)
                .Aggregate((f1, f2) => f1 * f2);

            return MonkeyBuisness(10_000, false, factor);
        }
    }

    class Monkey
    {
        public Queue<long> WorryItems { get; set; }

        public long Inspections { get; set; } = 0;

        public (int T, int F) Recipients { get; set; }

        public string OperationType { get; set; } = "";

        public long OperationValue { get; set; } = 0;

        public long TestValue { get; set; }

        public List<(int, long)> MonkeyAround(bool isWorried, long factor = 1)
        {
            List<(int, long)> changes = new();

            while (WorryItems.Count > 0)
            {
                Inspections++;

                long x = WorryItems.Dequeue();
                long y;

                switch (OperationType)
                {
                    case "+":
                        y = x + OperationValue;
                        break;
                    case "*":
                        if (OperationValue == 0)
                        {
                            y = x * x;
                        }
                        else
                        {
                            y = x * OperationValue;
                        }
                        break;
                    default:
                        y = 0;
                        break;
                }


                if (isWorried)
                {
                    y /= 3;
                }
                else
                {
                    y %= factor;
                }


                if (y % TestValue == 0)
                {
                    changes.Add((Recipients.T, y));
                }
                else
                {
                    changes.Add((Recipients.F, y));
                }
            }

            return changes;
        }
    }
}
