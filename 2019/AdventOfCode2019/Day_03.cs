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

            var first = new List<(int x, int y)>() { (0, 0) };
            var second = new List<(int x, int y)>() { (0, 0) };

            foreach (var f in firstInput)
            {
                first.AddRange(TranslateWireCompletePath(f, first.Last()));
            }

            foreach (var s in secondInput)
            {
                second.AddRange(TranslateWireCompletePath(s, second.Last()));
            }

            var diffs = first.Intersect(second).Distinct().Where(pos => pos.x != 0 && pos.y != 0).ToArray();
            var result = diffs.Select(pos => Math.Abs(pos.x - 0) + Math.Abs(pos.y - 0)).OrderBy(x => x).ToArray();
            return Result(result.Min());
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

        private (int x, int y)[] TranslateWireCompletePath(string wirePath, (int x, int y) currentPosition)
        {
            if (!int.TryParse(wirePath.Substring(1), out var steps)) throw new Exception();
            var result = new List<(int, int)>();
            for (int i = 1; i <= steps; i++)
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
