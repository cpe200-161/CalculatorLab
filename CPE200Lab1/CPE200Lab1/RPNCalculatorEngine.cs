using System;
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
            Stack<string> rpnStack = new Stack<string>();
            string[] parts = str.ToString().Split(' ');
            string firstOperand, secondOperand;
            string result;
            int numCount = 0, operCount = 0;
            foreach (string part in parts)
            {
                if (isOperator(part))
                {
                    if (rpnStack.Count != 0)
                    {
                        secondOperand = rpnStack.Pop();
                    }
                    else
                    {
                        return "E";
                    }
                    if (rpnStack.Count != 0)
                    {
                        firstOperand = rpnStack.Pop();
                    }
                    else
                    {
                        return "E";
                    }
                    result = calculate(part, firstOperand, secondOperand);
                    rpnStack.Push(result);
                    operCount++;
                }
                else if (isNumber(part))
                {
                    numCount++;
                    rpnStack.Push(part);
                }
            }
            if((rpnStack.Count == 1) && (operCount!=0) && (operCount == numCount-1) )
            {
                return rpnStack.Pop();
            }
            else
            {
                return "E";
            }
        }
    }
}
