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
            if(str.Length == 1)
            {
                return "E";
            }
            string firstOp, secondOp;
            string[] strArray = str.Split(' ');
            Stack rpnStack = new Stack();
            foreach (string s in strArray)
            {
                //Console.WriteLine(s);
                if (isNumber(s))
                {
                    rpnStack.Push(s);
                }else if(isOperator(s))
                {
                    if (rpnStack.Count > 1)
                    {
                        firstOp = rpnStack.Pop().ToString();
                        secondOp = rpnStack.Pop().ToString();
                        rpnStack.Push(calculate(s, secondOp, firstOp));
                    }
                    else
                    {
                        return "E";
                    }
                }
            }
            // your code here
            if (rpnStack.Count == 1)
            {
                return decimal.Parse(rpnStack.Peek().ToString()).ToString("G29");
            }
                return "E";
        }
    }
}
