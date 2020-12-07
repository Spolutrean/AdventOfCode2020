using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day4
{
    class Program
    {
        public static void advancedPart()
        {
            int result = 0;
            var st = new Dictionary<string, string>();
            var neededFields = new List<string> {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
            var rules = new Dictionary<string, Func<string, bool>>
            {
                {"byr", s => s.Length == 4 && String.Compare(s, "1919") == 1 && String.Compare(s, "2003") == -1},
                {"iyr", s => s.Length == 4 && String.Compare(s, "2009") == 1 && String.Compare(s, "2021") == -1},
                {"eyr", s => s.Length == 4 && String.Compare(s, "2019") == 1 && String.Compare(s, "2031") == -1},
                {"hgt", s =>
                {
                    if (s.Contains("cm"))
                    {
                        string before = s.Split(new[] {"cm"}, StringSplitOptions.None)[0];
                        string after = s.Split(new[] {"cm"}, StringSplitOptions.None)[1];
                        if (after.Length != 0) return false;
                        int i = Int32.Parse(before);
                        return i >= 150 && i <= 193;
                    } 
                    if (s.Contains("in"))
                    {
                        string before = s.Split(new[] {"in"}, StringSplitOptions.None)[0];
                        string after = s.Split(new[] {"in"}, StringSplitOptions.None)[1];
                        if (after.Length != 0) return false;
                        int i = Int32.Parse(before);
                        return i >= 59 && i <= 76;
                    }

                    return false;
                }},
                {"hcl", s => s.Length == 7 && s[0] == '#' && s.Substring(1).All(c => c >= '0' && c <= '9' || c >= 'a' && c <= 'f')},
                {"ecl", s => s == "amb" || s == "blu" || s == "brn" || s == "gry" || s == "grn" || s == "hzl" || s == "oth"},
                {"pid", s => s.Length == 9 && s.All(c => c >= '0' && c <= '9')}
            };
            
            foreach (var line in File.ReadAllLines(@"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day4\day4\input.txt"))
            {
                if (line.Length == 0)
                {
                    bool ok = neededFields.All(s => st.ContainsKey(s));
                    foreach (var pair in st)
                    {
                        if (!rules.ContainsKey(pair.Key))
                        {
                            continue;
                        }
                        ok &= rules[pair.Key].Invoke(pair.Value);
                    }
                    result += ok ? 1 : 0;
                    st.Clear();
                }
                else
                {
                    foreach (var segment in line.Split(' '))
                    {
                        string key = segment.Split(':')[0];
                        string value = segment.Split(':')[1];
                        st[key] = value;
                    }
                }
            }
            
            Console.WriteLine(result);
        }
        
        static void Main(string[] args)
        {
            advancedPart();
        }
    }
}