using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public class Day_02 : Shared
    {
        public Day_02()
        {
            Console.WriteLine(Day_02_Part1());
            Console.WriteLine(Day_02_Part2());
        }

        private string Day_02_Part1()
        {
            var opcodes = GetAllInput().Split(',').Select(x => int.Parse(x)).ToArray();

            return Result(RunInstructions(opcodes, 12, 2));
        }

        private string Day_02_Part2()
        {
            var opcodes = GetAllInput().Split(',').Select(x => int.Parse(x)).ToArray();

            var finished = false;
            var result = 0;
            for (int noun = 0; noun <= 99 && !finished; noun++)
            {
                for (int verb = 0; verb <= 99 && !finished; verb++)
                {
                    if (RunInstructions(opcodes.ToArray(), noun, verb) == 19690720) return Result(result = 100 * noun + verb);
                }
            }
            throw new Exception();
        }

        private int RunInstructions(int[] opcodes, int noun, int verb)
        {
            opcodes[1] = noun;
            opcodes[2] = verb;
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
            return opcodes[0];
        }
    }
}
