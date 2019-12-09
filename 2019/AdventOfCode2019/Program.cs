using System;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    class Program
    {
        static void Main()
        {
            var list = new List<(string day, int answer)> {
                (nameof(Day_01), new Day_01().Answer()),
            };
            foreach (var (day, answer) in list)
            {
                Console.WriteLine($"{day}: {answer}");
            }
        }
    }
}
