using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public class Day_03 : Shared
    {
        public string Day_03_Part1()
        {
            var input = GetAllInput().Split('\n');
            var firstInput = input[0].Split(',');
            var secondInput = input[1].Split(',');
            if (firstInput.Length != secondInput.Length) throw new Exception();

            var first = new List<(int x, int y)>() { (0, 0) };
            var second = new List<(int x, int y)>() { (0, 0) };

            for (int i = 0; i < firstInput.Length; i++)
            {
                first.Add(TranslateWirePath(firstInput[i], first.Last()));
                second.Add(TranslateWirePath(secondInput[i], second.Last()));
            }

            var crossedWires = new List<(int x, int y)>(first.Count());
            int splat = 0;
            foreach(var f in first)
            {
                foreach(var (x, y) in second)
                {
                    if (f.x == x && f.y == y) crossedWires.Add(f);
                    splat++;
                }
            }

            return Result(crossedWires.Min(w => Math.Abs(w.x + w.y)));
        }

        public string Day_03_Part2()
        {
            throw new NotImplementedException();
        }

        private (int x, int y) TranslateWirePath(string wirePath, (int x, int y) currentPosition)
        {
            if (!int.TryParse(wirePath.Substring(1), out var direction)) throw new Exception();
            var result = (wirePath[0]) switch
            {
                'U' => (currentPosition.x, currentPosition.y + direction),
                'D' => (currentPosition.x, currentPosition.y - direction),
                'R' => (currentPosition.x + direction, currentPosition.y),
                'L' => (currentPosition.x - direction, currentPosition.y),
                _ => throw new Exception(),
            };
            return result;
        }
    }
}
