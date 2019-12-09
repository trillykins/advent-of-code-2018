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
        protected string Result(int result, [CallerMemberName] string callerName = "")
        {
            return $"{callerName}: {result}";
        }

        protected string GetAllInput([CallerMemberName] string callerName = "")
        {
            var number = callerName.Substring(callerName.IndexOf('_') + 1, 2);
            if (!int.TryParse(number, out var day)) throw new Exception();
            var path = Path.Combine("puzzle_input", $"{day.ToString("00")}.txt");
            if (!File.Exists(path)) throw new FileNotFoundException();
            var result = File.ReadAllText(path);
            return result;
        }
    }
}
