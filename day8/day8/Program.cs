using System;
using System.Collections.Generic;
using System.IO;

namespace day8
{
    class Program
    {
        public static void advancedPart()
        {
            var lines = File.ReadAllLines(@"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day8\day8\input.txt");

            for (var i = 0; i < lines.Length; ++i)
            {
                var line = lines[i];
                if (line.StartsWith("nop"))
                {
                    lines[i] = line.Replace("nop", "jmp");
                }
                else if (line.StartsWith("jmp"))
                {
                    lines[i] = line.Replace("jmp", "nop");
                }
                else
                {
                    continue;
                }

                if (fullExec(lines)) return;

                line = lines[i];
                if (line.StartsWith("nop"))
                {
                    lines[i] = line.Replace("nop", "jmp");
                }
                else if (line.StartsWith("jmp"))
                {
                    lines[i] = line.Replace("jmp", "nop");
                }
            }

            bool fullExec(string[] program)
            {
                int i = 0, acc = 0;
                var used = new HashSet<int>();
                while (true)
                {
                    if (i < 0 || i >= program.Length)
                    {
                        Console.WriteLine(acc);
                        return true;
                    }

                    if (!used.Contains(i))
                    {
                        used.Add(i);
                        exec(program[i]);
                    }
                    else
                    {
                        return false;
                    }
                }

                void exec(string line)
                {
                    var split = line.Split(' ');
                    string command = split[0];
                    int val = Int32.Parse(split[1]);
                    if (command == "nop")
                    {
                        i++;
                    }
                    else if (command == "acc")
                    {
                        acc += val;
                        i++;
                    }
                    else if (command == "jmp")
                    {
                        i += val;
                    }
                }
            }
        }

        public static void basicPart()
        {
            var lines = File.ReadAllLines(@"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day8\day8\input.txt");
            int i = 0, acc = 0;
            var used = new HashSet<int>();
            while (true)
            {
                if (!used.Contains(i))
                {
                    used.Add(i);
                    exec();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(acc);

            void exec()
            {
                var split = lines[i].Split(' ');
                string command = split[0];
                int val = Int32.Parse(split[1]);
                if (command == "nop")
                {
                    i++;
                }
                else if (command == "acc")
                {
                    acc += val;
                    i++;
                }
                else if (command == "jmp")
                {
                    i += val;
                }
            }
        }

        static void Main(string[] args)
        {
            advancedPart();
        }
    }
}