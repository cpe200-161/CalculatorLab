using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : basicCalculatorEngine
    {
        protected Stack<string> stack;
        private bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }
        private bool isUnaryOperator(string str)
        {
            switch (str)
            {
                case "1/x":
                case "√":

                    return true;
            }
            return false;
        }

        private bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "%":

                    return true;
            }
            return false;
        }

        public new string Process(string str)
        {
            stack = new Stack<string>();
            string[] parts = str.Split(' ');
            if (parts.Length == 1)
            {
                return "E";
            }
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    stack.Push(parts[i]);
                }
                else if (isUnaryOperator(parts[i]))
                {
                    string first;
                    first = stack.Peek();
                    stack.Pop();
                    stack.Push(calculate(parts[i], first, 8));
                }
                else if (parts[i] == "%")
                {
                    string first, second;
                    if (stack.Count < 2)
                    {
                        return "E";
                    }
                    second = stack.Peek();
                    stack.Pop();
                    first = stack.Peek();
                    stack.Pop();
                    stack.Push(calculate(parts[i], first, second, 8));
                }
                else if (isOperator(parts[i]))
                {
                    if (stack.Count < 2)
                    {
                        return "E";
                    }
                    string first, second;
                    second = stack.Peek();
                    stack.Pop();
                    first = stack.Peek();
                    stack.Pop();
                    stack.Push(calculate(parts[i], first, second, 8));
                }

            }
            if (stack.Count == 1)
            {
                return stack.Peek();
            }
            else
            {
                return "E";
            }

        }
    }
}