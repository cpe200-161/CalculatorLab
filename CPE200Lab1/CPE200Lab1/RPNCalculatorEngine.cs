using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine:CalculatorEngine
    {
        public string Process(string str)
        {
            if (str.Length == 1)
            {
                return "E";
            }
            string firstOP, secondOP;
            string[] strArray = str.Split(' ');
            Stack rpnStack = new Stack();
            foreach(string rpnstring in strArray)
            {
                Console.WriteLine(rpnstring);
                if (isNumber(rpnstring))
                {
                    rpnStack.Push(rpnstring);
                }
                else if (isOperator(rpnstring))
                {
                    if (rpnStack.Count > 1)
                    {
                        secondOP = rpnStack.Pop().ToString();
                        firstOP = rpnStack.Pop().ToString();
                        rpnStack.Push(calculate(rpnstring, firstOP, secondOP));
                    }
                    else
                    {
                        return "E";
                    }
                }
            }
            if (rpnStack.Count == 1)
            {
                return decimal.Parse(rpnStack.Peek().ToString()).ToString("G29");
                //return rpnStack.Peek().ToString();
            }
            return "E";
        }
    }
}
