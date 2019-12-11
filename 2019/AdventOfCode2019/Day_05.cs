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
            //RunInstructions(new int[] { 3, 0, 4, 0, 99 });  // Test case
            RunInstructions(input);  // Test case
            return Result(0);
        }

        private string Day_05_Part2()
        {
            return Result(0);
        }

        // From day 2
        private int RunInstructions(int[] opcodes)
        {
            int i = 0;
            while (true)
            {
                var instructionPointer = 2;
                if (opcodes[i] == 99) break;
                var a = opcodes[i + 0];   // opcode
                var str = a.ToString();
                if (a == 1 || a == 2)
                {
                    instructionPointer = 4;
                    var b = opcodes[i + 1];   // value 1
                    var c = opcodes[i + 2];   // value 2
                    var d = opcodes[i + 3];   // position
                    opcodes[d] = a switch
                    {
                        1 => opcodes[b] + opcodes[c],
                        2 => opcodes[b] * opcodes[c],
                        _ => throw new Exception("Invalid opcode!"),
                    };
                }
                else if (a == 3)
                {
                    var b = opcodes[i + 1];
                    opcodes[b] = 1;
                }
                else if (a == 4)
                {
                    var b = opcodes[i + 1];
                    Console.WriteLine(opcodes[b]);
                }
                else if (str.Length > 1)
                {
                    // e.g. 1101
                    Console.WriteLine();
                }
                if (instructionPointer != 4 && instructionPointer != 2) throw new Exception("Bad instruction!");
                i += instructionPointer;
            }
            return opcodes[0];
        }
    }
}
