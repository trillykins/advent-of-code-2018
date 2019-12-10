using System;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    class Program
    {
        static void Main()
        {
            var list = new List<string> {
                new Day_01().Day_01_Part1(),
                new Day_01().Day_01_Part2(),
                new Day_02().Day_02_Part1(),
                new Day_02().Day_02_Part2(),
                new Day_03().Day_03_Part1(),
                new Day_03().Day_03_Part2(),
                new Day_04().Day_04_Part1(),
            };
            foreach (var answer in list)
            {
                Console.WriteLine(answer);
            }
        }
    }
}
