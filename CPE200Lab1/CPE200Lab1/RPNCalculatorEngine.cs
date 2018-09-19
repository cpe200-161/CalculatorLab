using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            // your code here
            Console.WriteLine("TEST");
            Stack RPNStack = new Stack();
            string firstOP, secondOP;
            string[] splitStr = str.Split(' ');

            foreach (string s in splitStr)
            {
                Console.WriteLine(s);
                if (isNumber(s))
                {
                    RPNStack.Push(s);
                }
                else if (isUnary(s))
                {
                    Console.WriteLine("unary");
                    if (RPNStack.Count < 1)
                    {
                        return "E";
                    }
                    else
                    {
                        Console.WriteLine("mmmmmm");
                        firstOP = RPNStack.Pop().ToString();
                        RPNStack.Push(unaryCalculate(s, firstOP));
                    }
                }
                else if (isOperator(s))
                {
                    if (RPNStack.Count <= 1)
                    {
                        Console.WriteLine("yy");
                        return "E";
                    }
                    else
                    {
                        Console.WriteLine("aaaaaa");
                        secondOP = RPNStack.Pop().ToString();
                        firstOP = RPNStack.Pop().ToString();
                        RPNStack.Push(calculate(s, firstOP, secondOP));
                    }
                }
            }
            if (RPNStack.Count == 1)
            {
                if (splitStr.Length == 1)
                {
                    return "E";
                }
                return (Convert.ToDecimal(RPNStack.Peek().ToString())).ToString("G29");
            }
            return "E";
        }
    }
}
