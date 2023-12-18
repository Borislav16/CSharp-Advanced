using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            while(true)
            {
                string guest = Console.ReadLine();
                
                if (guest == "PARTY")
                {
                    while(guest != "END")
                    {
                        guest = Console.ReadLine();
                        set.Remove(guest);
                    }
                    
                    Console.WriteLine(set.Count);
                    foreach (var item in set)
                    {
                        char[] ch = item.ToCharArray();
                        if (char.IsDigit(ch[0]))
                        {
                            Console.WriteLine(item);
                        }
                    }
                    foreach (var item in set)
                    {
                        char[] ch = item.ToCharArray();
                        if (char.IsLetter(ch[0]))
                        {
                            Console.WriteLine(item);
                        }
                    }
                    return;
                }
                set.Add(guest);
            }
        }
    }
}
