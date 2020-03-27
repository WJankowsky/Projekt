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
            Buforowanie = Regex.Replace(Buforowanie, @"(?<numer>\d+(\.\d+)?)", " ${numer} ");
            Buforowanie = Regex.Replace(Buforowanie, @"(?<operator>[+\-*/^()])", " ${operator} ");
            Buforowanie = Regex.Replace(Buforowanie, @"(?<funkcja>(abs|exp|sqrt|log|asin|sinh|sin|cosh|acos|cos|atan|tanh|tan))", " ${funkcja} ");
            Buforowanie = Regex.Replace(Buforowanie, @"\s+", " ").Trim();

            string[] listaTokenow = Buforowanie.Split(" ".ToCharArray());
            return listaTokenow;
        }

        public List<string> Zamiana(string[] listaTokenow) // konwersja infix na postfix
        {
            Stack<string> stos = new Stack<string>();
            Queue<string> kolejka = new Queue<string>();
            foreach (string a in listaTokenow)
            {
                if (a == "(")
                {
                    stos.Push(a);
                }
                else if (a == ")")
                {
                    while (stos.Peek() != "(")
                    {
                        kolejka.Enqueue(stos.Pop());
                    }
                    stos.Pop();
                }
                else if (CzyJestOperator(a) || CzyJestFunkcja(a))
                {
                    while (stos.Count > 0 && SlownikPriorytetow(a) <= SlownikPriorytetow(stos.Peek()))
                    {
                         kolejka.Enqueue(stos.Pop());
                    }
                    stos.Push(a);
                }
                if (CzyJestLiczba(a))
                {
                    kolejka.Enqueue(a);
                }
            }
            while (stos.Count > 0)
            {
                kolejka.Enqueue(stos.Pop());
            }
            var list = kolejka.ToList();
            return list;
        }

        static int SlownikPriorytetow(string a)  // Priorytety
        {
            if (CzyJestFunkcja(a))
            {
                return 4;
            }
            else if (a == "^")
            {
                return 3;
            }
            else if (a == "*" || a == "/")
            {
                return 2;
            }
            else if (a == "+" || a == "-")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static bool CzyJestLiczba(string a)
        {
            if(Regex.IsMatch(a, @"\d+|[x]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool CzyJestOperator(string a)
        {
            if(a == "+" || a == "-" || a == "/" || a == "*")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool CzyJestFunkcja(string a)
        {
            if ((a == "abs" || a == "exp" || a == "log" || a == "sqrt" || a == "sin" || a == "sinh" || a == "asin" || a == "cos" || a == "cosh" || a == "acos" || a == "tan" || a == "tanh" || a == "atan") || (a == "-abs" || a == "-exp" || a == "-log" || a == "-sqrt" || a == "-sin" || a == "-sinh" || a == "-asin" || a == "-cos" || a == "-cosh" || a == "-acos" || a == "-tan" || a == "-tanh" || a == "-atan"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static double KalkulatorProsty(double a, double b, string c)
        {
            if(c == "+")
            {
                return a+b;
            }
            if(c == "-")
            {
                return a-b;
            }
            if(c == "*")
            {
                return a*b;
            }
            if(c == "/")
            {
                return a/b;
            }
            if(c == "^")
            {
                return Math.Pow(b, a);
            }
            throw new Exception();
        }

        static double KalkulatorZaawansowany(string a, double temp)
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
            throw new Exception();
        }
    }
}