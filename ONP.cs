using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace programowanie
{
    class ONP
    {
        private string _wejscie;
        public string Wejscie
        {
            get { return _wejscie; }
            set { _wejscie = value; }
        }
        public ONP(string wejscie)
        {
            Wejscie = wejscie;
        }

        public string[] Tokeny(string wejscie)
        {
            string Buforowanie = wejscie.ToLower();
            Buforowanie = Regex.Replace(Buforowanie, @"(?<number>\d+(\.\d+)?)", " ${number} ");
            Buforowanie = Regex.Replace(Buforowanie, @"(?<ops>[+\-*/^()])", " ${ops} ");
            Buforowanie = Regex.Replace(Buforowanie, @"(?<alpha>(abs|exp|sqrt|log|asin|sinh|sin|cosh|acos|cos|atan|tanh|tan))", " ${alpha} ");
            Buforowanie = Regex.Replace(Buforowanie, @"\s+", " ").Trim();

            //List<char> listaTokenow = new List<char>();
            string[] listaTokenow = Buforowanie.Split(" ".ToCharArray());

            return listaTokenow;
        }


        // public List<string> Zamiana(List<string> tokeny)
        // {
        //     return 0;
        // }

        /*static double KalkulatorProsty(double a, double b, string c)
        {
            if(c == "+")
            {
                return a+b;
            }
            else if(c == "-")
            {
                return a-b;
            }
            else if(c == "*")
            {
                return a*b;
            }
            else if(c == "/")
            {
                return a/b;
            }
            else if(c == "^")
            {
                return Math.Pow(b, a);
            }
        }

        static double KalklatorZaawansowany(string a, double temp)
        {
            if (a == "abs")
            {
                return Math.Abs(temp);
            }
            if (a == "exp")
            {
                return Math.Exp(temp);
            }
            if (a == "log")
            {
                return Math.Log(temp);
            }
            if (a == "sqrt")
            {
                return Math.Sqrt(temp);
            }
            if (a == "sin")
            {
                return Math.Sin(temp);
            }
            if (a == "cos")
            {
                return Math.Cos(temp);
            }
            if (a == "tan")
            {
                return Math.Tan(temp);
            }
            if (a == "sinh")
            {
                return Math.Sinh(temp);
            }
            if (a == "cosh")
            {
                return Math.Cosh(temp);
            }
            if (a == "tanh")
            {
                return Math.Tanh(temp);
            }
            if (a == "asin")
            {
                return Math.Asin(temp);
            }
            if (a == "acos")
            {
                return Math.Acos(temp);
            }
            if (a == "atan")
            {
                return Math.Atan(temp);
            }


            if (a == "-abs")
            {
                return -Math.Abs(temp);
            }
            if (a == "-exp")
            {
                return -Math.Exp(temp);
            }
            if (a == "-log")
            {
                return -Math.Log(temp);
            }
            if (a == "-sqrt")
            {
                return -Math.Sqrt(temp);
            }
            if (a == "-sin")
            {
                return -Math.Sin(temp);
            }
            if (a == "-cos")
            {
                return -Math.Cos(temp);
            }
            if (a == "-tan")
            {
                return -Math.Tan(temp);
            }
            if (a == "-sinh")
            {
                return -Math.Sinh(temp);
            }
            if (a == "-cosh")
            {
                return -Math.Cosh(temp);
            }
            if (a == "-tanh")
            {
                return -Math.Tanh(temp);
            }
            if (a == "-asin")
            {
                return -Math.Asin(temp);
            }
            if (a == "-acos")
            {
                return -Math.Acos(temp);
            }
            if (a == "-atan")
            {
                return -Math.Atan(temp);
            }
        }*/
    }
}