using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode2022
{
    public class Solver01
    {
        public List<Elf> Elves { get; private set; }
        
        public string InputFile { get; init; }

        public Solver01(string path)
        {
            Elves = new List<Elf>();
            InputFile = path;
            PouplateElf();
        }

        private void PouplateElf()
        {
            //Elf Identifier
            int elfId = 1;

            Elves.Add(new Elf(elfId));

            //Parse every line in the Data file
            foreach (string line in File.ReadLines(InputFile))
            {
                //If the line is empty, create a new elf
                if (line is "")
                {
                    //Add existing elf to list of elves
                    Elves.Add(new Elf(elfId));

                    //Increment the elf count
                    elfId++;
                }
                //otherwise add calories to the exisitng elf
                else
                {
                    Elves[elfId - 1].AddToCalorieTotal(int.Parse(line));
                }
            }
        }

        /// <summary>
        /// Part 1 Question:
        /// Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?
        /// </summary>
        /// <returns></returns>
        public int FindMaxCalories()
        {
            return Elves.Max(elf => elf.TotalCalories);
        }

        /// <summary>
        /// Part 2 Question:
        /// Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?
        /// </summary>
        /// <returns></returns>
        public int FindTopThreeCalories()
        {
            return Elves.OrderByDescending(elf => elf.TotalCalories).Take(3).Sum(elf => elf.TotalCalories);
        }

    }
}
