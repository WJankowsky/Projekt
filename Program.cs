using System;
using System.Linq;
using System.Collections.Generic;

namespace programowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            ONP test = new ONP("sinh2x+sin1");
            string[] infix = test.Tokeny(test.Wejscie);
            foreach(string i in infix)
            {
                System.Console.Write("{0} ", i);
            }
        }
    }
}