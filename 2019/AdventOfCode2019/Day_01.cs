using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public class Day_01 : Shared
    {
        public int Answer()
        {
            return GetInput(1).Split('\n').Select(x => (int.Parse(x) / 3) - 2).Sum();
        }
    }
}
