using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : TheCalculatorEngine
    {
        /// <summary>
        /// Calculate with RPN style calculation.
        /// </summary>
        /// <param name="str">The string of RPN style calculation.</param>
        /// <returns>The string of result.</returns>
        public string calculate(string str)
        {
            string[] parts = str.Split(' ');
            Stack<string> myStack = new Stack<string>();
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    myStack.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    try
                    {
                        string secondOperands = myStack.Pop();
                        myStack.Push(calculate(parts[i], myStack.Pop(), secondOperands));
                    }
                    catch (Exception e)
                    {
                        return "E";
                    }
                }
                else if(parts[i] == "%")
                {
                    if(parts[i+1] == "+" || parts[i+1] == "-")
                    {
                        myStack.Push(calculate(parts[i], myStack.Pop(), myStack.Peek()));
                    }
                    else
                    {
                        myStack.Push(calculate(parts[i], myStack.Pop(), null));
                    }
                }
                else if (isUnary(parts[i]))
                {
                    myStack.Push(calculate(parts[i], myStack.Pop()));
                }
            }
            if(myStack.Count == 1)
            {
                return myStack.Pop();
            }
            return "E";
        }
    }
}