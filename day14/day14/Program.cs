using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day14
{
    class Program
    {
        public static void BasicPart()
        {
            string mask = "";
            Dictionary<long, ulong> dictionary = new Dictionary<long, ulong>();
            foreach (var line in File.ReadLines(
                @"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day14\day14\input.txt"))
            {
                if (line.StartsWith("mask ="))
                {
                    mask = line;
                }
                else
                {
                    var index = long.Parse(line.Split(']')[0].Split('[')[1]);
                    var value = ulong.Parse(line.Split('=')[1].Trim());
                    for (int i = 0; i < mask.Length; ++i)
                    {
                        if (mask[mask.Length - i - 1] == 'X') continue;
                        ulong st = 1ul << i;
                        if (mask[mask.Length - i - 1] == '1')
                        {
                            value |= st;
                        }
                        else
                        {
                            value &= ulong.MaxValue - st;
                        }
                    }

                    dictionary[index] = value;
                }
            }

            ulong result = 0;
            foreach (KeyValuePair<long, ulong> keyValuePair in dictionary)
            {
                result += keyValuePair.Value;
            }

            Console.WriteLine(result);
        }

        public static void AdvancedPart()
        {
            string mask = "";
            var dictionary = new Dictionary<string, ulong>();
            foreach (var line in File.ReadLines(
                @"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day14\day14\input.txt"))
            {
                if (line.StartsWith("mask ="))
                {
                    mask = line.Split(' ')[2];
                }
                else
                {
                    var index = Int32.Parse(line.Split(']')[0].Split('[')[1]);
                    var value = ulong.Parse(line.Split('=')[1].Trim());

                    string bitIndex = "";
                    while (index != 0)
                    {
                        bitIndex += (char) ((index % 2) + '0');
                        index /= 2;
                    }

                    bitIndex = new string(bitIndex.Reverse().ToArray());

                    bitIndex = bitIndex.PadLeft(mask.Length, '0');

                    string convertedIndex = "";
                    for (int i = 0; i < mask.Length; ++i)
                    {
                        if (mask[i] == '0')
                        {
                            convertedIndex += bitIndex[i];
                        }
                        else if (mask[i] == '1')
                        {
                            convertedIndex += '1';
                        }
                        else
                        {
                            convertedIndex += 'X';
                        }
                    }

                    var st = new HashSet<string>();
                    rec(convertedIndex, st);
                    foreach (var s in st)
                    {
                        dictionary[s] = value;
                    }
                }
            }

            ulong result = 0;
            foreach (var keyValuePair in dictionary)
            {
                result += keyValuePair.Value;
            }

            Console.WriteLine(result);

            void rec(string s, HashSet<string> st)
            {
                int i = s.IndexOf('X');
                if (i == -1)
                {
                    st.Add(s);
                }
                else
                {
                    string ss = s.Remove(i, 1);
                    string s0 = new string(ss), s1 = new string(ss);
                    s0 = s0.Insert(i, "0");
                    s1 = s1.Insert(i, "1");

                    rec(s0, st);
                    rec(s1, st);
                }
            }
        }

        static void Main(string[] args)
        {
            //BasicPart();
            AdvancedPart();
        }
    }
}