using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            string firstOperand, secondOperand;

            foreach (string token in parts)
            {

                if (parts.Count == 1 && parts.Count == 0)
                {
                    return "E";
                }
                
                if (isNumber(token))
                {
                    rpnStack.Push(token);
                }
               
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?

                    secondOperand = rpnStack.Pop();
                    firstOperand = rpnStack.Pop();
                    result = calculate(token, firstOperand, secondOperand, 6);
                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            result = rpnStack.Pop();
            return result;
        }
    }
}

