namespace AoCwithCSharp.Supporting
{
    /// <summary>
    /// Abstract Class to Format Solvers for Integer Answers
    /// </summary>
    abstract public class SolverInt
    {
        abstract public int PartA { get; }
        abstract public int PartB { get; }
    }

    /// <summary>
    /// Abstract Class to Format Solvers for String Answers
    /// </summary>
    abstract public class SolverStr
    {
        abstract public string PartA { get; }
        abstract public string PartB { get; }
    }
}
