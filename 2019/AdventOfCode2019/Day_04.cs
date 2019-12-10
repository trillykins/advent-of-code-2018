using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public class Day_04 : Shared
    {
        public string Day_04_Part1()
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

        public string Day_04_Part2()
        {
            var input = GetAllInput().Split('-');
            throw new NotImplementedException();
        }

        private bool TestNumber(int number)
        {
            var valid = false;
            var str = "" + number;
            for (int i = 1; i < str.Length; i++)
            {
                var first = int.Parse($"{str[i - 1]}");
                var second = int.Parse($"{str[i]}");
                if (first > second)
                {
                    return false;
                }
                if (str[i] == str[i - 1])
                {
                    valid = true;
                }
            }
            return valid;
        }
    }
}
