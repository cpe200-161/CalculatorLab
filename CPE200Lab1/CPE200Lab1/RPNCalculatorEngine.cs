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
            string[] tmp = str.Split(' ');
            if (tmp.Length < 3)
            {
                return "E";
            }
            Stack stack = new Stack();
            foreach(string s in tmp)
            {
                if (isNumber(s))
                {
                    stack.Push(Double.Parse(s));
                }
                else if (isOperator(s))
                {

                    if (stack.Count < 2)
                    {
                        return "E";
                    }
                   
                    if (s == "%")
                    {
                        if (tmp.Length == 3)
                        {
                            string secondOp = stack.Pop().ToString();
                            string firstOP = stack.Pop().ToString();
                            stack.Push(calculate(s, firstOP, secondOp));
                        }
                        else
                        {
                            string secondOp = stack.Pop().ToString();
                            string firstOP = stack.Peek().ToString();
                            stack.Push(calculate(s, firstOP, secondOp));
                        }                       
                    }
                    else
                    {
                        string firstOP = stack.Pop().ToString();
                        string secondOp = stack.Pop().ToString();
                        stack.Push(calculate(s, secondOp, firstOP));
                    }                  
                }
            }
            // your code here
            if (stack.Count==1)
            {
                return decimal.Parse(stack.Peek().ToString()).ToString("G29");
            }
            else
            {
                return "E";
            }           
        }
    }
}
