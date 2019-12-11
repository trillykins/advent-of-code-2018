using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode2019
{
    public class Day_05 : Shared
    {
        public Day_05()
        {
            Console.WriteLine(Day_05_Part1());
            Console.WriteLine(Day_05_Part2());
        }

        private string Day_05_Part1()
        {
            var input = GetAllInput().Split(',').Select(x => int.Parse(x)).ToArray();
            var result = RunInstructions(input, 1);  // Test case
            return Result(result);
        }

        private string Day_05_Part2()
        {
            var input = GetAllInput().Split(',').Select(x => int.Parse(x)).ToArray();
            var result = RunInstructions(new int[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 }, 5);  // Test case
            //var result = RunInstructions(input, 5);  // Test case
            return Result(result);
        }

        // From day 2
        private int RunInstructions(int[] opcodes, int systemId)
        {
            int i = 0;
            var output = new List<int>();
            while (opcodes[i] != 99)
            {
                var opcode = opcodes[i + 0] % 10;

                var a = opcodes[i + 0];   // opcode
                var param1 = opcodes[i + 1];
                var param2 = opcodes[i + 2];
                var param3 = opcodes[i + 3];

                int param1Mode = (a / 100) % 10;
                int param2Mode = (a / 1000) % 10;

                var param1Value = (param1Mode == 0) ? opcodes[param1] : param1;

                if (opcode == 1 || opcode == 2)
                {
                    var param2Value = (param2Mode == 0) ? opcodes[param2] : param2;
                    opcodes[param3] = opcode switch
                    {
                        1 => param1Value + param2Value,
                        2 => param1Value * param2Value,
                        _ => throw new Exception("Invalid opcode!"),
                    };
                    i += 4;
                }
                else if (opcode == 3)
                {
                    opcodes[param1] = systemId;
                    i += 2;
                }
                else if (opcode == 4)
                {
                    output.Add(param1Value);
                    i += 2;
                }
                else if (opcode == 5 || opcode == 6)
                {
                    var param2Value = (param2Mode == 0) ? opcodes[param2] : param2;
                    if (opcode == 5 && param1Value != 0) i = param2Value;
                    if (opcode == 6 && param1Value == 0) i = param2Value;
                }
                else if (opcode == 7 || opcode == 8)
                {
                    var param2Value = (param2Mode == 0) ? opcodes[param2] : param2;
                    if (opcode == 7)
                    {
                        if (param1Value < param2Value) opcodes[param3] = 1;
                        else opcodes[param3] = 0;
                    }
                    else
                    {
                        if (param1Value == param2Value) opcodes[param3] = 1;
                        else opcodes[param3] = 2;
                    }
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
            return output.Last();
        }

        private int PositionOrImmediate(int[] opcodes, int value, int decider)
        {
            if (decider == 0) return opcodes[value];    // Position
            if (decider == 1) return value;             // Immediate
            throw new NotSupportedException();
        }
    }
}
