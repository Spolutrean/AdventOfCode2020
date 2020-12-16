using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day16
{
    class Program
    {
        public static void BasicPart()
        {
            var rules = new List<string>();
            var myTicket = "";
            var otherTickets = new List<string>();

            int step = 0;

            foreach (var line in File.ReadLines(
                @"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day16\day16\input.txt"))
            {
                if (line.Length == 0)
                {
                    step++;
                    continue;
                }

                switch (step)
                {
                    case 0:
                        rules.Add(line);
                        break;
                    case 1 when !line.StartsWith("your ticket:"):
                        myTicket = line;
                        break;
                    case 2 when !line.StartsWith("nearby tickets:"):
                        otherTickets.Add(line);
                        break;
                }
            }

            var allowedNumbers = new HashSet<int>();

            void AddSubsequence(int l, int r)
            {
                for (int i = l; i <= r; ++i)
                {
                    allowedNumbers.Add(i);
                }
            }

            foreach (var rule in rules)
            {
                var s = rule.Split(':')[1];
                var s1 = s.Split(' ')[1];
                var s2 = s.Split(' ')[3];
                AddSubsequence(int.Parse(s1.Split('-')[0]), int.Parse(s1.Split('-')[1]));
                AddSubsequence(int.Parse(s2.Split('-')[0]), int.Parse(s2.Split('-')[1]));
            }

            int result = 0;
            foreach (var otherTicket in otherTickets)
            {
                result += otherTicket.Split(',').Select(int.Parse).Where(i => !allowedNumbers.Contains(i)).Sum();
            }

            Console.WriteLine(result);
        }

        public static void AdvancedPart()
        {
            var rules = new List<string>();
            var myTicket = "";
            var otherTickets = new List<string>();

            int step = 0;

            foreach (var line in File.ReadLines(
                @"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day16\day16\input.txt"))
            {
                if (line.Length == 0)
                {
                    step++;
                    continue;
                }

                switch (step)
                {
                    case 0:
                        rules.Add(line);
                        break;
                    case 1 when !line.StartsWith("your ticket:"):
                        myTicket = line;
                        break;
                    case 2 when !line.StartsWith("nearby tickets:"):
                        otherTickets.Add(line);
                        break;
                }
            }

            var allowedNumbers = new HashSet<int>();

            void AddSubsequence(int l, int r)
            {
                for (int i = l; i <= r; ++i)
                {
                    allowedNumbers.Add(i);
                }
            }

            foreach (var rule in rules)
            {
                var s = rule.Split(':')[1];
                var s1 = s.Split(' ')[1];
                var s2 = s.Split(' ')[3];
                AddSubsequence(int.Parse(s1.Split('-')[0]), int.Parse(s1.Split('-')[1]));
                AddSubsequence(int.Parse(s2.Split('-')[0]), int.Parse(s2.Split('-')[1]));
            }

            var numbersByIndex = new List<HashSet<int>>();
            foreach (var otherTicket in otherTickets)
            {
                var ints = otherTicket.Split(',').Select(int.Parse).ToList();
                if (!ints.All(i => allowedNumbers.Contains(i))) continue;
                for (int i = 0; i < ints.Count; ++i)
                {
                    while (numbersByIndex.Count <= i)
                    {
                        numbersByIndex.Add(new HashSet<int>());
                    }

                    numbersByIndex[i].Add(ints[i]);
                }
            }


            for (int row = 0; row < 20; ++row)
            {
                for (int coll = 0; coll < 20; ++coll)
                {
                    var s = rules[row].Split(':')[1];
                    var l1 = int.Parse(s.Split(' ')[1].Split('-')[0]);
                    var r1 = int.Parse(s.Split(' ')[1].Split('-')[1]);
                    var l2 = int.Parse(s.Split(' ')[3].Split('-')[0]);
                    var r2 = int.Parse(s.Split(' ')[3].Split('-')[1]);

                    bool localOk = true;
                    foreach (var x in numbersByIndex[coll])
                    {
                        localOk &= x >= l1 && x <= r1 || x >= l2 && x <= r2;
                        if (!localOk) break;
                    }

                    Console.Write(localOk ? 1337 : 0);
                    Console.Write(" ");
                }

                Console.Write("\n");
            }

            //put matrix on online calculator -- https://comnuan.com/cmnn03/cmnn03005/cmnn03005.php
        }

        static void Main(string[] args)
        {
            //BasicPart();
            AdvancedPart();
        }
    }
}