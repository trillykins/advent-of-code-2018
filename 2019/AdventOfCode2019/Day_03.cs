using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public class Day_03 : Shared
    {
        //private List<(int x, int y)> first;
        //private List<(int x, int y)> second;
        //private (int x, int y)[] diffs;

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
            var result = diffs.Select(pos => Math.Abs(pos.x) + Math.Abs(pos.y)).OrderBy(x => x).ToArray();
            return Result(result.Min());
        }

        public string Day_03_Part2()
        {
            //var firstInput = "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51".Split(',');
            //var secondInput = "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7".Split(',');

            var input = GetAllInput().Split('\n');
            var firstInput = input[0].Split(',');
            var secondInput = input[1].Split(',');

            var first = new List<(int x, int y, int totalSteps)>() { (0, 0, 0) };
            var second = new List<(int x, int y, int totalSteps)>() { (0, 0, 0) };

            foreach (var f in firstInput)
            {
                first.AddRange(TranslateWireCompletePath(f, first.Last()));
            }

            foreach (var s in secondInput)
            {
                second.AddRange(TranslateWireCompletePath(s, second.Last()));
            }

            var firstWithoutSteps = first.Select(pos => (pos.x, pos.y)).ToArray();
            var secondWithoutSteps = second.Select(pos => (pos.x, pos.y)).ToArray();

            var intersectingWires = firstWithoutSteps.Intersect(secondWithoutSteps).Where(pos => pos.x != 0 && pos.y != 0).ToArray();
            var intersectingSteps = intersectingWires.Select(pos => first.First(f => pos.x == f.x && pos.y == f.y).totalSteps + second.First(s => pos.x == s.x && s.y == pos.y).totalSteps).ToArray();
            var result = intersectingSteps.OrderBy(x => x).ToArray();

            return Result(result.Min());
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

        private (int x, int y, int totalSteps)[] TranslateWireCompletePath(string wirePath, (int x, int y, int totalSteps) currentPosition)
        {
            if (!int.TryParse(wirePath.Substring(1), out var steps)) throw new Exception();
            var result = new List<(int, int, int)>();
            for (int i = 1; i <= steps; i++)
            {
                var pos = (wirePath[0]) switch
                {
                    'U' => (currentPosition.x, currentPosition.y + i, currentPosition.totalSteps + i),
                    'D' => (currentPosition.x, currentPosition.y - i, currentPosition.totalSteps + i),
                    'R' => (currentPosition.x + i, currentPosition.y, currentPosition.totalSteps + i),
                    'L' => (currentPosition.x - i, currentPosition.y, currentPosition.totalSteps + i),
                    _ => throw new Exception(),
                };
                result.Add(pos);
            }
            return result.ToArray();
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
