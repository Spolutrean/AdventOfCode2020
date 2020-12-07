using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace day7
{
    class Program
    {
        public static void basicPart()
        {
            var dictionary = new Dictionary<string, List<string>>();

            void addRule(string s)
            {
                if (s.EndsWith("contain no other bags.")) return;
                var splitedS = s.Split(' ');
                var s1 = splitedS[0] + " " + splitedS[1];
                for (int i = 4; i < splitedS.Length; i += 4)
                {
                    int num = Int32.Parse(splitedS[i]);
                    var s2 = splitedS[i + 1] + " " + splitedS[i + 2];
                    if(!dictionary.ContainsKey(s2)) dictionary[s2] = new List<string>();
                    dictionary[s2].Add(s1);
                }
            }

            foreach (var line in File.ReadAllLines(@"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day7\day7\input.txt"))
            {
                addRule(line);
            }
            
            var answer = new HashSet<string>();

            dfs("shiny gold");
            
            void dfs(string color)
            {
                answer.Add(color);
                if (dictionary.ContainsKey(color))
                {
                    foreach (var toColor in dictionary[color])
                    {
                        if (!answer.Contains(toColor)) dfs(toColor);
                    }
                }
            }
            
            Console.WriteLine(answer.Count - 1);
        }
        
        public static void advancedPart()
        {
            var dictionary = new Dictionary<string, List<(string, int)>>();

            void addRule(string s)
            {
                if (s.EndsWith("contain no other bags.")) return;
                var splitedS = s.Split(' ');
                var s1 = splitedS[0] + " " + splitedS[1];
                for (int i = 4; i < splitedS.Length; i += 4)
                {
                    int cnt = Int32.Parse(splitedS[i]);
                    var s2 = splitedS[i + 1] + " " + splitedS[i + 2];
                    if(!dictionary.ContainsKey(s1)) dictionary[s1] = new List<(string, int)>();
                    dictionary[s1].Add((s2, cnt));
                }
            }

            foreach (var line in File.ReadAllLines(@"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day7\day7\input.txt"))
            {
                addRule(line);
            }

            var result = dfs("shiny gold") - 1;

            int dfs(string color)
            {
                int bags = 1;
                if (dictionary.ContainsKey(color))
                {
                    foreach (var toColor in dictionary[color])
                    {
                        bags += toColor.Item2 * dfs(toColor.Item1);
                    }
                }

                return bags;
            }
            
            Console.WriteLine(result);
        }
        
        static void Main(string[] args)
        {
            basicPart();
            advancedPart();
        }
    }
}