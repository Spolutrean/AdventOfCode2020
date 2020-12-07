using System;
using System.Collections.Generic;
using System.IO;

namespace day6
{
    class Program
    {
        
        public static void advancedPart()
        {
            int result = 0;
            HashSet<char> st = null;
            foreach (var s in File.ReadLines(@"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day6\day6\input.txt"))
            {
                var sSt = new HashSet<char>();
                if(s.Length == 0) {
                    result += st.Count;
                    st = null;
                } else {
                    foreach(char c in s) {
                        sSt.Add(c);
                    }

                    if (st == null) st = sSt;
                    else st.IntersectWith(sSt);
                }
            }

            Console.WriteLine(result);
        }
        public static void basicPart()
        {
            int result = 0;
            var st = new HashSet<char>();
            foreach (var s in File.ReadLines(@"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day6\day6\input.txt"))
            {
                if(s.Length == 0) {
                    result += st.Count;
                    st.Clear();
                } else {
                    foreach(char c in s) {
                        st.Add(c);
                    }
                }
            }
            
            if(st.Count != 0) {
                result += st.Count;
            }

            Console.WriteLine(result);
        }
        
        static void Main(string[] args)
        {
            advancedPart();
        }
    }
}