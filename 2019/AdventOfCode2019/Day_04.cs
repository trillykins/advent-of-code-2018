using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode2019
{
    public class Day_04 : Shared
    {
        public Day_04()
        {
            Console.WriteLine(Day_04_Part1());
            Console.WriteLine(Day_04_Part2());
        }

        private string Day_04_Part1()
        {
            var input = GetAllInput().Split('-').Select(x => int.Parse(x)).ToArray();
            var lowerBound = input[0];
            var upperBound = input[1];

            if (lowerBound > upperBound) throw new Exception();
            var result = new List<int>();
            for (int current = lowerBound; current < upperBound; current++)
            {
                var valid = TestNumber(current);
                if (valid) result.Add(current);
            }
            return Result(result.Count());
        }

        private string Day_04_Part2()
        {
            var input = GetAllInput().Split('-').Select(x => int.Parse(x)).ToArray();
            var lowerBound = input[0];
            var upperBound = input[1];

            if (lowerBound > upperBound) throw new Exception();
            var result = new List<int>();
            for (int current = lowerBound; current < upperBound; current++)
            {
                var valid = TestNumber(current);
                if (valid) valid = TestAdjacentNumbers(current);
                if (valid) result.Add(current);
            }

            return Result(result.Count());
        }

        private bool TestAdjacentNumbers(int number)
        {
            var str = "" + number;
            var hasPair = false;
            for (int i = 0; i < 10; i++)
            {
                var count = str.Count(x => x == char.Parse("" + i));
                if (count == 1) continue;
                if (count == 2) hasPair = true;
            }
            return hasPair;
        }

        private bool TestNumber(int number)
        {
            var valid = false;
            var str = "" + number;
            for (int i = 1; i < str.Length; i++)
            {
                var first = int.Parse($"{str[i - 1]}");
                var second = int.Parse($"{str[i]}");
                if (first > second) return false;
                if (str[i] == str[i - 1]) valid = true;
            }
            return valid;
        }
    }
}
