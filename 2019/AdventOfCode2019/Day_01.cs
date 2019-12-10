using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public class Day_01 : Shared
    {
        public Day_01()
        {
            Console.WriteLine(Day_01_Part1());
            Console.WriteLine(Day_01_Part2());
        }

        private string Day_01_Part1()
        {
            return Result(GetAllInput().Split('\n').Select(x => (int.Parse(x) / 3) - 2).Sum());
        }

        private string  Day_01_Part2()
        {
            var result = 0;
            var fuel = GetAllInput().Split('\n').Select(x => (int.Parse(x)));
            foreach (var f in fuel)
            {
                result += CalculateFuel(f);
            }

            return Result(result);
        }

        private int CalculateFuel(int i)
        {
            var result = 0;
            while (i > 0)
            {
                var fuel = (i / 3) - 2;
                if (fuel <= 0) break;
                result += fuel;
                i = fuel;
            }
            return result;
        }
    }
}
