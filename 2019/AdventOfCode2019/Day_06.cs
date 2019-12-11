using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode2019
{
    public class Day_06 : Shared
    {
        public Day_06()
        {
            Console.WriteLine(Day_06_Part1());
            Console.WriteLine(Day_06_Part2());
        }

        private string Day_06_Part1()
        {
            var testInput = "COM)B\r\nB)C\r\nC)D\r\nD)E\r\nE)F\r\nB)G\r\nG)H\r\nD)I\r\nE)J\r\nJ)K\r\nK)L";
            //var input = GetAllInput().Split(Environment.NewLine).ToArray();
            var input = testInput.Split(Environment.NewLine).ToArray();

            return Result(-1);
        }

        private string Day_06_Part2()
        {
            var input = GetAllInput().Split(Environment.NewLine).ToArray();
            return Result(-1);
        }

        private int Orbitor(string[] map)
        {

            return -1;
        }
    }
}
