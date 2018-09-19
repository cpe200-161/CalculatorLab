using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RpnCalculatorEngine:CalculatorEngine
    {
        public string Process(string str)
        {
            string[] strArray = str.Split(' ');
            Stack rpnStack = new Stack();
             string firstOp, secOp;

            foreach (string s in strArray)
            {
                if (isNumber(s))
                {
                    rpnStack.Push(s);
                }

                else if (isOperator(s))
                {
                    if (rpnStack.Count > 1)
                    {
                        secOp = rpnStack.Pop().ToString();
                        firstOp = rpnStack.Pop().ToString();
                    }
                    else
                    {
                        return "E";
                    }
                   rpnStack.Push(calculate(s, firstOp, secOp));
                }
                
            }

            if (rpnStack.Count == 1)
            {
                if (strArray[1] == "1/x" || strArray[1] == "√")
                {
                    string cal;
                    cal = rpnStack.Peek().ToString();
                    rpnStack.Pop();
                    rpnStack.Push(unaryCalculate(cal,strArray[1]));

                }
                return rpnStack.Peek().ToString();
            }
            else
            {
                return "E";
            }

            if (rpnStack.Count == 1)
            {
                if (strArray.Length == 1) //use this if to check length of display if there was only one character it will return E to display
                {
                    return "E";
                }
                return decimal.Parse(rpnStack.Peek().ToString()).ToString("G29"); //this use to display a number to match test case 
            }
            else
            {
                return "E";
            }
            
        }
    }
}
