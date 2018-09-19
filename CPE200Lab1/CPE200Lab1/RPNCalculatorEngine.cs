using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            Console.WriteLine("i am here");
            string firstOp, secondOp;
            string[] strArray = str.Split(' ');
            if (strArray.Length < 3)
            {
                return "E";
            }
            Stack rpnStack = new Stack();

            foreach (string s in strArray)
            {
                Console.WriteLine(s);
                if (isNumber(s))
                {
                    rpnStack.Push(s);
                }
                else if (isOperator(s))
                {
                    if (rpnStack.Count >= 2)
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
       /*     if (rpnStack.Count == 1)
            {
                return string.Format("{0:G29}",decimal.Parse(rpnStack.Peek().ToString()));
            }
            else
            {
                return "E";
            }*/
            if (rpnStack.Count == 1)
            {
                if (strArray[1] == "√" || strArray[1] == "1/x")
                {
                    string firstnumber;
                    firstnumber = rpnStack.Peek().ToString();
                    rpnStack.Pop();
                    rpnStack.Push(unaryCalculate(strArray[1], firstnumber));
                }
                return rpnStack.Peek().ToString();
            }
            else
            {
                return "E";
            }
        }
    }
}