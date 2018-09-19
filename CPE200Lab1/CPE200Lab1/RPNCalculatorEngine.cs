using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            Stack rpnStack = new Stack();
            string firstOp, secondOp;
            string[] strArray = str.Split(' ');
            if (strArray.Length < 3)
            {
                return "E";
            }
            else if (isOperator(strArray[1]) || isOperator(strArray[0]))
            {
                return "E";
            }
            else
            {
                foreach (string s in strArray)
                {


                    if (isNumber(s))
                    {
                        rpnStack.Push(s);
                    }
                    else if (rpnStack.Count > 1)
                    {
                        if (isOperator(s))
                        {
                            secondOp = rpnStack.Pop().ToString();
                            firstOp = rpnStack.Pop().ToString();
                            if (firstOp == null || secondOp == null)
                            {
                                return "E";
                            }
                            else
                            {
                                rpnStack.Push(calculate(s, firstOp, secondOp));
                            }
                        }
                    }
                    else
                    {
                        return "E";
                    }
                }
                if (rpnStack.Count == 1)
                {
                    return decimal.Parse(rpnStack.Peek().ToString()).ToString("G29");
                }
                else
                {
                    return "E";
                }
            }
        }
    }
}