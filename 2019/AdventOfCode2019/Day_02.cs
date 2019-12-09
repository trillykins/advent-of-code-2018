using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public class Day_02 : Shared
    {
        public string Day_02_Part1()
        {
            var opcodes = GetInput().Split(',').Select(x => int.Parse(x)).ToArray();
            opcodes[1] = 12;
            opcodes[2] = 2;
            for (int i = 0; i < opcodes.Length; i++)
            {
                if (i % 4 != 0) continue;
                if (opcodes[i] == 99) break;
                var a = opcodes[i + 0];   // opcode
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

            return Result(opcodes[0]);
        }
    }
}
