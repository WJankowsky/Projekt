using System;
using System.Linq;
using System.Collections.Generic;

namespace programowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            ONP test = new ONP("exp(2*x+1)/sin(2+x)");
            string[] infix = test.Tokeny(test.Wejscie);
            foreach(string i in infix)
            {
                System.Console.Write("{0} ", i);
            }
            System.Console.WriteLine();
            List<string> postfix = test.Zamiana(infix);
            foreach(string p in postfix)
            {
                System.Console.Write("{0} ", p);
            }
        }
    }
}