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
            // your code here
            string Num1, Num2, result;
            Stack<string> myStack = new Stack<string>();
            string[] parts = str.Split(' ');

            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    myStack.Push(parts[i]);
                }

                if (isOperator(parts[i]))
                {
                    if (myStack.Count < 2)
                    {
                        return "E";
                    }
                    Num2 = myStack.Pop();
                    Num1 = myStack.Pop();
                    myStack.Push(calculate(parts[i], Num1, Num2));
                }
                if(isOperatorUnary(parts[i]))
                {
                    if (myStack.Count < 1)
                    {
                        return "E";
                    }
                    Num1 = myStack.Pop();
                    myStack.Push(unaryCalculate(parts[i], Num1));
                }
            }
            result = myStack.Peek();
            if (myStack.Count != 1)
            {
                return "E";
            }
            return result;

        }
    }
}

