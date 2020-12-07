using System;
using System.Linq;

namespace day2
{
    class Program
    {
        static void basicPart()
        {
            int result = 0;
            for (int i = 0; i < 1000; ++i)
            {
                string s = Console.ReadLine();
                int l = Int32.Parse(s.Split(' ')[0].Split('-')[0]) - 1;
                int r = Int32.Parse(s.Split(' ')[0].Split('-')[1]) - 1;
                char c = s.Split(' ')[1].First();
                string inputString = s.Split(' ')[2];
                var cntC = inputString.Select(c1 => c1 == c ? 1 : 0).Sum();
                result += cntC >= l && cntC <= r ? 1 : 0;
            }
            
            Console.WriteLine(result);
        }
        
        static void advancedPart()
        {
            int result = 0;
            for (int i = 0; i < 1000; ++i)
            {
                string s = Console.ReadLine();
                int l = Int32.Parse(s.Split(' ')[0].Split('-')[0]) - 1;
                int r = Int32.Parse(s.Split(' ')[0].Split('-')[1]) - 1;
                char c = s.Split(' ')[1].First();
                string inputString = s.Split(' ')[2];
                result += inputString[l] == c ^ inputString[r] == c ? 1 : 0;
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