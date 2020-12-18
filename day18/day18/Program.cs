using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day18
{
    class Program
    {
        static long Parse(string s)
        {
            var st = new Stack<long>(); //-1 for (, -2 for *, -3 for +
            int it = 0;
            s = new string(s.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());

            while (it < s.Length)
            {
                char c = s[it];
                switch (c)
                {
                    case '(':
                        st.Push(-1);
                        ++it;
                        break;
                    case '*':
                        st.Push(-2);
                        ++it;
                        break;
                    case '+':
                        st.Push(-3);
                        ++it;
                        break;
                    case ')':
                    {
                        var x = st.Pop();
                        st.Pop(); // remove (
                        if (st.TryPeek(out var p))
                        {
                            switch (p)
                            {
                                case -1:
                                    st.Push(x);
                                    break;
                                case -2:
                                {
                                    st.Pop(); // remove *
                                    var x1 = st.Pop();
                                    st.Push(x1 * x);
                                    break;
                                }
                                case -3:
                                {
                                    st.Pop(); // remove +
                                    var x1 = st.Pop();
                                    st.Push(x1 + x);
                                    break;
                                }
                                default:
                                    throw new Exception("Something went wrong");
                            }
                        }
                        else
                        {
                            st.Push(x);
                        }

                        ++it;
                        break;
                    }
                    case >= '0' and <= '9':
                    {
                        var x = ReadNumber();
                        if (st.TryPeek(out var op))
                        {
                            switch (op)
                            {
                                case -1:
                                {
                                    st.Push(x);
                                    break;
                                }
                                case -2:
                                {
                                    st.Pop(); //remove *
                                    var x1 = st.Pop();
                                    st.Push(x1 * x);
                                    break;
                                }
                                case -3:
                                {
                                    st.Pop(); //remove +
                                    var x1 = st.Pop();
                                    st.Push(x1 + x);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            st.Push(x);
                        }

                        break;
                    }
                }
            }

            int ReadNumber()
            {
                int num = 0;
                while (it < s.Length && s[it] >= '0' && s[it] <= '9')
                {
                    num *= 10;
                    num += s[it] - '0';
                    it++;
                }

                return num;
            }

            return st.Peek();
        }

        static long AdvancedParse(string s)
        {
            s = "(" + s + ")";
            var st = new Stack<long>(); //-1 for (, -2 for *, -3 for +
            int it = 0;
            s = new string(s.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());

            while (it < s.Length)
            {
                char c = s[it];
                switch (c)
                {
                    case '(':
                        st.Push(-1);
                        ++it;
                        break;
                    case '*':
                        st.Push(-2);
                        ++it;
                        break;
                    case '+':
                        st.Push(-3);
                        ++it;
                        break;
                    case ')':
                    {
                        var x = st.Pop();
                        while (st.Peek() > 0)
                        {
                            x *= st.Pop();
                        }

                        st.Pop(); // remove (
                        if (st.TryPeek(out var p))
                        {
                            switch (p)
                            {
                                case -1:
                                    st.Push(x);
                                    break;
                                case -2:
                                    st.Pop(); // remove *
                                    st.Push(x);
                                    break;
                                case -3:
                                    st.Pop(); // remove +
                                    var x1 = st.Pop();
                                    st.Push(x1 + x);
                                    break;
                                default:
                                    throw new Exception("Something went wrong");
                            }
                        }
                        else
                        {
                            st.Push(x);
                        }

                        ++it;
                        break;
                    }
                    case >= '0' and <= '9':
                    {
                        var x = ReadNumber();
                        if (st.TryPeek(out var op))
                        {
                            switch (op)
                            {
                                case -1:
                                    st.Push(x);
                                    break;
                                case -2:
                                    st.Pop(); //remove *
                                    st.Push(x);
                                    break;
                                case -3:
                                    st.Pop(); //remove +
                                    var x1 = st.Pop();
                                    st.Push(x1 + x);
                                    break;
                            }
                        }
                        else
                        {
                            st.Push(x);
                        }

                        break;
                    }
                }
            }

            int ReadNumber()
            {
                int num = 0;
                while (it < s.Length && s[it] >= '0' && s[it] <= '9')
                {
                    num *= 10;
                    num += s[it] - '0';
                    it++;
                }

                return num;
            }

            return st.Peek();
        }

        static void BasicPart()
        {
            long result = 0;
            foreach (var line in File.ReadLines(
                @"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day18\day18\input.txt"))
            {
                result += Parse(line);
            }

            Console.WriteLine(result);
        }

        static void AdvancedPart()
        {
            long result = 0;
            foreach (var line in File.ReadLines(
                @"C:\Users\Yaroslav.Sviridov\Desktop\AdventOfCode2020\day18\day18\input.txt"))
            {
                result += AdvancedParse(line);
            }

            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(AdvancedParse("1+3*3+4"));
            //BasicPart();
            AdvancedPart();
        }
    }
}