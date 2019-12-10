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
                first.AddRange(TranslateWireCompletePath(firstInput[i], first.Last()));
                second.AddRange(TranslateWireCompletePath(secondInput[i], second.Last()));
            }

            var crossedWires = new List<(int x, int y)>(first.Count());
            int splat = 0;

            foreach (var (x1, y1) in first)
            {
                foreach (var (x2, y2) in second)
                {
                    if (x1 == x2 && y1 == y2) crossedWires.Add((x1, y1));
                    splat++;
                }
            }
            var result = crossedWires.Where(x => x.x != 0 && x.y != 0).Min(w => Math.Abs(w.x + w.y));
            return Result(result);
        }

        public string Day_03_Part2()
        {
            throw new NotImplementedException();
        }

        //private (int x, int y)[] GetPath((int x, int y) start, (int x, int y) end)
        //{
        //    var result = new List<(int, int)>();
        //    if (start.x == end.x)
        //    {
        //        for(int i = 0; i < Math.Abs(start.y+end.y); i++)
        //        {

        //        }
        //    }
        //    else
        //    {

        //    }
        //    return
        //}

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
        private (int x, int y)[] TranslateWireCompletePath(string wirePath, (int x, int y) currentPosition)
        {
            if (!int.TryParse(wirePath.Substring(1), out var steps)) throw new Exception();
            var result = new List<(int, int)>();
            for (int i = 1; i < steps; i++)
            {
                var pos = (wirePath[0]) switch
                {
                    'U' => (currentPosition.x, currentPosition.y + i),
                    'D' => (currentPosition.x, currentPosition.y - i),
                    'R' => (currentPosition.x + i, currentPosition.y),
                    'L' => (currentPosition.x - i, currentPosition.y),
                    _ => throw new Exception(),
                };
                result.Add(pos);
            }
            return result.ToArray();
        }
    }
}
