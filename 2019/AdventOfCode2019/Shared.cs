using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AdventOfCode2019
{
    public abstract class Shared
    {
        protected string GetInput(int day, [CallerMemberName] string callerName = "")
        {
            var path = Path.Combine("puzzle_input", $"{day.ToString("00")}.txt");
            var result = File.ReadAllText(path);
            return result;
        }
    }
}
