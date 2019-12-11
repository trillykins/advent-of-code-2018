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
            //var result = RunInstructions(new int[] { 3, 0, 4, 0, 99 });  // Test case
            var result = RunInstructions(input);  // Test case
            return Result(result);
        }

        private string Day_05_Part2()
        {
            return Result(0);
        }

        // From day 2
        private int RunInstructions(int[] opcodes)
        {
            int i = 0;
            var output = new List<int>();
            while (true)
            {
                var instructionPointer = 2;
                if (opcodes[i] == 99) break;
                var a = opcodes[i + 0];   // opcode
                var b = opcodes[i + 1];   // parameter 1
                if (a == 1 || a == 2)
                {
                    opcodes = AddOrMultiply(opcodes, i, a, new int[] { 0, 0 });
                    instructionPointer = 4;
                }
                else if (a == 3)
                {
                    opcodes[b] = 1;
                }
                else if (a == 4)
                {
                    output.Add(opcodes[b]);
                }
                else if (a.ToString().Length > 1)
                {
                    // e.g. 1101
                    var str = a.ToString();
                    if (str.Length == 2) throw new ArgumentOutOfRangeException($"{str} doesn't really make sense, does it?");
                    str = a.ToString("0000");
                    var opcode = int.Parse(str.Substring(2));
                    var parameterModes = str.Substring(0, 2).ToCharArray().Select(x => int.Parse($"{x}")).ToArray();
                    if (opcode == 1 || opcode == 2)
                    {
                        AddOrMultiply(opcodes, i, opcode, parameterModes);
                        instructionPointer = 4;
                    }
                    else if (opcode == 3)
                    {
                        opcodes[b] = 1;
                    }
                    else if (opcode == 4)
                    {
                        if (parameterModes.Any(x => x == 1)) output.Add(b);
                        else output.Add(opcodes[b]);
                    }
                    else
                    {
                        throw new NotSupportedException();
                    }
                }
                else
                {
                    throw new NotSupportedException();
                }
                if (instructionPointer != 4 && instructionPointer != 2) throw new Exception("Bad instruction!");
                i += instructionPointer;
            }
            return output.Last();
        }

        private int[] AddOrMultiply(int[] opcodes, int i, int a, int[] modes)
        {
            var b = opcodes[i + 1];   // value 1
            var c = opcodes[i + 2];   // value 2
            var d = opcodes[i + 3];   // position
            opcodes[d] = a switch
            {
                1 => PositionOrImmediate(opcodes, b, modes[0]) + PositionOrImmediate(opcodes, c, modes[1]),
                2 => PositionOrImmediate(opcodes, b, modes[0]) * PositionOrImmediate(opcodes, c, modes[1]),
                _ => throw new Exception("Invalid opcode!"),
            };
            return opcodes;
        }

        private int PositionOrImmediate(int[] opcodes, int value, int decider)
        {
            if (decider == 0) return opcodes[value];    // Position
            if (decider == 1) return value;             // Immediate
            throw new NotSupportedException();
        }
    }
}
