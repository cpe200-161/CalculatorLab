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
            Stack<string> numStack = new Stack<string>();

            string[] numSet = str.Split(' ');

            foreach(string text in numSet)
            {
                if (isNumber(text))
                {
                    numStack.Push(text);
                }

                else
                {
                    if ((text == "+" || text == "-" || text == "X" || text == "÷") && numStack.Count >= 2)
                    {
                        string second = numStack.Pop();
                        string first = numStack.Pop();
                        numStack.Push(calculate(text, first, second));
                    }

                    else if ((text == "√" || text == "1/x") && numStack.Count >= 1)
                    {
                        string num = numStack.Pop();
                        numStack.Push(unaryCalculate(text, num));
                    }

                    else if (text == "")
                    {
                        break;
                    }

                    else
                    {
                        return "E";
                    }
                }

            }

            if (numStack.Count != 1) return "E";

            return numStack.Peek();
        }
    }
}
