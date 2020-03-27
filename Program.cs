using System;
using System.Linq;
using System.Collections.Generic;

namespace programowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            ONP test = new ONP(args[0]);
            test.Zmienna = double.Parse(args[1]);
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
            Console.Write("\n{0}", test.ObliczaniePostfixa(postfix));
            test.ObliczaniePrzedzialow(postfix,double.Parse(args[2]),double.Parse(args[3]),Convert.ToInt32(args[4]));
        }
    }
}