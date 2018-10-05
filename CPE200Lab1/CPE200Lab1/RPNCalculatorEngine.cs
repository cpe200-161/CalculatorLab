using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : BasicCalculatorEngine
    {
        /// <summary>
        /// Calculating using RPN calculator 
        /// </summary>
        /// <param name="oper"> The string of RPN style calculation </param>
        /// <returns> Resulf of string </returns>
        public new string calculate(string oper)
        {
            string one, two, sum;
            Stack<string> myStack = new Stack<string>();
            string[] parts = oper.Split(' ');

            List<string> partsWithoutSpace = parts.ToList<string>();
            partsWithoutSpace.RemoveAll(p => string.IsNullOrEmpty(p));
            parts = partsWithoutSpace.ToArray();

            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    myStack.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    if ((parts[i] == "+" || parts[i] == "-" || parts[i] == "X" || parts[i] == "÷") && myStack.Count >= 2)
                    {
                        two = myStack.Pop();
                        one = myStack.Pop();
                        sum = calculate(parts[i], one, two);
                        myStack.Push(sum);
                    }
                    else if (parts[i] == "√" || parts[i] == "1/x" && myStack.Count == 1)
                    {
                        one = myStack.Pop();
                        myStack.Push(calculate(parts[i], one));
                    }
                    else if (parts[i] == "%")
                    {
                        two = myStack.Pop();
                        one = myStack.Pop();
                        myStack.Push(one);
                        myStack.Push(calculate(parts[i], one, two));

                    }
                    else return "E";
                }
                else
                {
                    return "E";
                }
            }
            if (myStack.Count == 1)
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
