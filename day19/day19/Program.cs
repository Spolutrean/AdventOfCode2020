using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day19
{
    class Program
    {
        static void BasicPart()
        {
            var rules = new Dictionary<string, string>();
            var strings = new List<string>();
            var state = 0;
            string input = @"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day19\day19\input.txt";
            string test = @"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day19\day19\test.txt";
            foreach (var line in File.ReadAllLines(input))
            {
                if (line.Length == 0)
                {
                    state++;
                    continue;
                }

                if (state == 0)
                {
                    var key = line.Split(':')[0];
                    var val = line.Split(':')[1].Trim();
                    rules[key] = val;
                }
                else
                {
                    strings.Add(line);
                }
            }

            var definiteSize = GetDefiniteSize("0");
            var ans = 0;

            foreach (var needToCheck in strings)
            {
                if (needToCheck.Length != definiteSize) continue;
                if (Check(needToCheck))
                {
                    ans++;
                }
            }

            Console.WriteLine(ans);

            bool Check(string needToCheck)
            {
                int ind = 0;
                return Dfs("0");

                bool Dfs(string key)
                {
                    var save = ind;
                    bool ok;

                    string s = rules[key];
                    if (s.First() == '"' && s.Last() == '"')
                    {
                        ok = s[1] == needToCheck[ind++];
                    }
                    else if (s.Contains('|'))
                    {
                        string l = s.Split('|')[0].Trim();
                        string r = s.Split('|')[1].Trim();
                        ok = HandlePair(l) || HandlePair(r);
                    }
                    else
                    {
                        ok = HandlePair(s);
                    }

                    if (!ok) ind = save;
                    return ok;


                    bool HandlePair(string ss)
                    {
                        bool pairOk;
                        var pairSave = ind;
                        if (!ss.Contains(' '))
                        {
                            pairOk = Dfs(ss);
                        }
                        else
                        {
                            pairOk = true;
                            foreach (var to in ss.Split(' '))
                            {
                                pairOk &= Dfs(to);
                                if (!pairOk) break;
                            }
                        }

                        if (!pairOk) ind = pairSave;
                        return pairOk;
                    }
                }
            }

            int GetDefiniteSize(string key)
            {
                string s = rules[key];
                if (s.First() == '"' && s.Last() == '"')
                {
                    return 1;
                }

                if (s.Contains('|'))
                {
                    string l = s.Split('|')[0].Trim();
                    string r = s.Split('|')[1].Trim();
                    int xL = GetSummaryLength(l);
                    int xR = GetSummaryLength(r);
                    if (xL != xR) throw new Exception("oopsie doopsie");
                    return xL;
                }

                return GetSummaryLength(s);

                int GetSummaryLength(string ss)
                {
                    if (!ss.Contains(' '))
                    {
                        return GetDefiniteSize(ss);
                    }

                    var sum = 0;
                    foreach (var to in ss.Split(' '))
                    {
                        sum += GetDefiniteSize(to);
                    }

                    return sum;
                }
            }
        }

        static void AdvancedPart()
        {
            var rules = new Dictionary<string, string>();
            var strings = new List<string>();
            var state = 0;
            string input = @"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day19\day19\input.txt";
            string test = @"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day19\day19\test.txt";
            foreach (var line in File.ReadAllLines(input))
            {
                if (line.Length == 0)
                {
                    state++;
                    continue;
                }

                if (state == 0)
                {
                    var key = line.Split(':')[0];
                    var val = line.Split(':')[1].Trim();
                    rules[key] = val;
                }
                else
                {
                    strings.Add(line);
                }
            }

            rules["8"] = "42 | 42 8";
            rules["11"] = "42 31 | 42 11 31";

            //var definiteSize = GetDefiniteSize("31");
            var ans = 0;
            var ind = 0;

            foreach (var needToCheck in strings)
            {
                int k = needToCheck.Length / 8;
                if (k * 8 != needToCheck.Length || k < 3) continue;
                bool any = false;
                for (int lSize = 8, rSize = needToCheck.Length - lSize;
                    lSize + rSize == needToCheck.Length && lSize >= 8 && rSize >= 16;
                    lSize += 8, rSize -= 8)
                {
                    ind = 0;
                    bool divisionOk = true;
                    for (int j = 0; j < lSize; j += 8)
                    {
                        divisionOk &= Dfs("42");
                    }

                    for (int j = 0; j < rSize / 2; j += 8)
                    {
                        divisionOk &= Dfs("42");
                    }

                    for (int j = 0; j < rSize / 2; j += 8)
                    {
                        divisionOk &= Dfs("31");
                    }

                    any |= divisionOk;
                    if (any) break;
                }

                if (any) ans++;

                bool Dfs(string key)
                {
                    var save = ind;
                    bool ok;

                    string s = rules[key];
                    if (s.First() == '"' && s.Last() == '"')
                    {
                        if (ind < needToCheck.Length)
                        {
                            ok = s[1] == needToCheck[ind++];
                        }
                        else
                        {
                            ok = false;
                        }
                    }
                    else if (s.Contains('|'))
                    {
                        string l = s.Split('|')[0].Trim();
                        string r = s.Split('|')[1].Trim();
                        ok = HandlePair(l) || HandlePair(r);
                    }
                    else
                    {
                        ok = HandlePair(s);
                    }

                    if (!ok) ind = save;
                    return ok;


                    bool HandlePair(string ss)
                    {
                        bool pairOk;
                        var pairSave = ind;
                        if (!ss.Contains(' '))
                        {
                            pairOk = Dfs(ss);
                        }
                        else
                        {
                            pairOk = true;
                            foreach (var to in ss.Split(' '))
                            {
                                pairOk &= Dfs(to);
                                if (!pairOk) break;
                            }
                        }

                        if (!pairOk) ind = pairSave;
                        return pairOk;
                    }
                }
            }

            Console.WriteLine(ans);

            int GetDefiniteSize(string key)
            {
                if (key == "8" || key == "11") throw new Exception(key);
                string s = rules[key];
                if (s.First() == '"' && s.Last() == '"')
                {
                    return 1;
                }

                if (s.Contains('|'))
                {
                    string l = s.Split('|')[0].Trim();
                    string r = s.Split('|')[1].Trim();
                    int xL = GetSummaryLength(l);
                    int xR = GetSummaryLength(r);
                    if (xL != xR) throw new Exception("oopsie doopsie");
                    return xL;
                }

                return GetSummaryLength(s);

                int GetSummaryLength(string ss)
                {
                    if (!ss.Contains(' '))
                    {
                        return GetDefiniteSize(ss);
                    }

                    var sum = 0;
                    foreach (var to in ss.Split(' '))
                    {
                        sum += GetDefiniteSize(to);
                    }

                    return sum;
                }
            }
        }

        static void Main(string[] args)
        {
            AdvancedPart();
        }
    }
}