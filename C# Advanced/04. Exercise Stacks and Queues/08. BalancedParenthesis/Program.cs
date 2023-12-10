using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            foreach (char item in sequence)
            {
                switch (item)
                {
                    case '(':
                    case '[':
                    case '{': stack.Push(item);
                        break;
                    case ')':
                        if(stack.Count == 0 || stack.Pop() != '(')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                }
            }
            if(stack.Count > 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
