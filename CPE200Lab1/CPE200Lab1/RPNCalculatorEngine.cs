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
            //string testString = "4 8 -";
            string[] strArray = str.Split(' ');
            Stack rpnStack = new Stack();
            string firstOperator, secondOperator;
            //Stack rpnStackOperator = new Stack();
            String temp;
            if (strArray.Length == 1) { return "E"; }
            foreach (string s in strArray)
            {
                if (isNumber(s))
                {
                    rpnStack.Push(s);
                }
                else if (isOperator(s))
                {
                    if (s == "1/x" || s == "√")
                    {
                        firstOperator = (rpnStack.Pop()).ToString();
                        rpnStack.Push(unaryCalculate(s, firstOperator.ToString()));
                    }
                    else
                    {
                        if (rpnStack.Count >= 2)
                        {
                            firstOperator = (rpnStack.Pop()).ToString();
                            secondOperator = (rpnStack.Pop()).ToString();
                        }
                        else
                        {
                            return "E";
                        }



                        if (s == "-" || s == "÷")
                        {
                            temp = firstOperator;
                            firstOperator = secondOperator;
                            secondOperator = temp;
                        }

                        rpnStack.Push(calculate(s, firstOperator, secondOperator));

                    }

                }
                /*
                else
                {
                    Console.WriteLine("ERROR");
                    return "E";
                }
                */
                //Console.WriteLine(s);

                //rpnStack.Push(s);
            }


            // your code here
            //return "E";
            if (rpnStack.Count == 1)
            {
                //return (string)rpnStack.Peek();
                return Convert.ToDouble(rpnStack.Peek()).ToString("G29");
            }
            else
            {
                return "E";
            }
        }
    }
}
