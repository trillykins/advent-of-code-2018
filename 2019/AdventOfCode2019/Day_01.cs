using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public class Day_01 : Shared
    {
        public string Day_01_Part1()
        {
            return Result(GetInput().Split('\n').Select(x => (int.Parse(x) / 3) - 2).Sum());
        }

        public string Day_01_Part2()
        {
            var result = 0;
            var stuff = GetInput().Split('\n').Select(x => (int.Parse(x)));
            foreach (var s in stuff)
            {
                result += Hat(s);
            }

            return Result(result);
        }

        private int Hat(int i)
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
