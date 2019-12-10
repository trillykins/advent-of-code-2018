using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public class Day_03 : Shared
    {
        public Day_03()
        {
            Console.WriteLine(Day_03_Part1());
            Console.WriteLine(Day_03_Part2());
        }

        private string Day_03_Part1()
        {
            var input = GetAllInput().Split('\n');
            var firstInput = input[0].Split(',');
            var secondInput = input[1].Split(',');

            var first = new List<Point>() { Point.Empty };
            var second = new List<Point>() { Point.Empty };

            foreach (var f in firstInput)
            {
                first.AddRange(TranslateWireCompletePath(f, first.Last()));
            }

            foreach (var s in secondInput)
            {
                second.AddRange(TranslateWireCompletePath(s, second.Last()));
            }

            var diffs = first.Intersect(second).Distinct().Where(p => p != Point.Empty).ToArray();
            var result = diffs.Select(p => Math.Abs(p.X) + Math.Abs(p.Y)).OrderBy(x => x).ToArray();
            return Result(result.Min());
        }

        private string Day_03_Part2()
        {
            var input = GetAllInput().Split('\n');
            var firstInput = input[0].Split(',');
            var secondInput = input[1].Split(',');

            var first = new List<Point>() { Point.Empty };
            var second = new List<Point>() { Point.Empty };

            foreach (var f in firstInput)
            {
                first.AddRange(TranslateWireCompletePath(f, first.Last()));
            }

            foreach (var s in secondInput)
            {
                second.AddRange(TranslateWireCompletePath(s, second.Last()));
            }
            var intersectingWires = first.Intersect(second).Where(p => p != Point.Empty).ToArray();

            var splat = first.IndexOf(intersectingWires[0]);
            var kat = second.IndexOf(intersectingWires[0]);
            var result = splat + kat;

            return Result(result);
        }

        private Point[] TranslateWireCompletePath(string wirePath, Point currentPosition)
        {
            if (!int.TryParse(wirePath.Substring(1), out var steps)) throw new Exception();
            var result = new List<Point>();
            for (int i = 1; i <= steps; i++)
            {
                var pos = (wirePath[0]) switch
                {
                    'U' => new Point(currentPosition.X, currentPosition.Y + i),
                    'D' => new Point(currentPosition.X, currentPosition.Y - i),
                    'R' => new Point(currentPosition.X + i, currentPosition.Y),
                    'L' => new Point(currentPosition.X - i, currentPosition.Y),
                    _ => throw new Exception(),
                };
                result.Add(pos);
            }
            return result.ToArray();
        }
    }
}
