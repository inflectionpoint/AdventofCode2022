﻿using AdventofCode2022;
using System.IO;

namespace AdventofCode2022Tests
{
    public class TestDay02
    {
        private readonly string basePathPuzzle;
        private readonly string basePathSample;
        private readonly ITestOutputHelper output;

        public TestDay02(ITestOutputHelper output)
        {
            this.output = output;
            string day = GetType().Name.Substring(7);
            basePathPuzzle = Common.BasePath + $"Input{day}.txt";
            basePathSample = Common.BasePath + $"Sample{day}.txt";
        }

        [Fact]
        public void TestCaseA()
        {
            //Arrange
            SolveDay02 puzzle = new(basePathSample);

            //Act
            int partA = puzzle.PartA;
            output.WriteLine(partA.ToString());

            //Assert
            Assert.Equal(15, partA);
        }

        [Fact]
        public void TestCaseB()
        {
            //Arrange
            SolveDay02 puzzle = new(basePathSample);

            //Act
            int partB = puzzle.PartB;
            output.WriteLine(partB.ToString());

            //Assert
            Assert.Equal(12, partB);
        }

        [Fact]
        public void TestCaseANonZero()
        {
            //Arrange
            SolveDay02 puzzle = new(basePathPuzzle);

            //Act
            int partA = puzzle.PartA;
            output.WriteLine(partA.ToString());

            //Assert
            Assert.True(partA > 0);
        }

        [Fact]
        public void TestCaseBNonZero()
        {
            //Arrange
            SolveDay02 puzzle = new(basePathPuzzle);

            //Act
            int partB = puzzle.PartB;
            output.WriteLine(partB.ToString());

            //Assert
            Assert.True(partB > 0);
        }

    }
}