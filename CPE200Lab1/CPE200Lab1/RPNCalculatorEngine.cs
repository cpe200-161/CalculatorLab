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
            // your code here
            Console.WriteLine("I am here");
            string firstOp, secondOp;
            string[] strArray = str.Split(' ');
            if(str.Length < 3)
            {
                return "E";
            }
            Stack rpnStack = new Stack();
            foreach(string s in strArray)
            {
                //Console.WriteLine(s);
                if (isNumber(s))
                {
                    rpnStack.Push(s);
                }
                else if (isOperator(s))
                {
                    if (rpnStack.Count > 1)
                    {
                        secondOp = rpnStack.Pop().ToString();
                        firstOp = rpnStack.Pop().ToString();
                        rpnStack.Push(calculate(s, firstOp, secondOp));
                    }
                    else
                    {
                        return "E";
                    }
                }
            }
            if(rpnStack.Count == 1)
            {
                return decimal.Parse(rpnStack.Peek().ToString()).ToString("G29");
            }
            return "E";
        }
    }
}
