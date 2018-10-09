using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : TheCalculatorEngine
    {
        public string calculate(string str)
        {
            Stack<string> myStack = new Stack<string>();
            string[] parts = str.ToString().Split(' ');
            string firstOperand, secondOperand;
            string result;
            int numCount = 0, operCount = 0;
            foreach (string part in parts)
            {
                if (isOperator(part))
                {
                    if (myStack.Count != 0)
                    {
                        secondOperand = myStack.Pop();
                    }
                    else
                    {
                        return "E";
                    }
                    if (myStack.Count != 0)
                    {
                        firstOperand = myStack.Pop();
                    }
                    else
                    {
                        return "E";
                    }
                    result = calculate(part, firstOperand, secondOperand);
                    myStack.Push(result);
                    operCount++;
                }
                else if (isNumber(part))
                {
                    numCount++;
                    myStack.Push(part);
                }
            }
            if((myStack.Count == 1) && (operCount!=0) && (operCount == numCount-1) )
            {
                return myStack.Pop();
            }
            else
            {
                return "E";
            }
        }
    }
}
