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
            Stack<string> stack = new Stack<string>();
            string[] parts = str.Split(' ');
            int number;
            foreach(string part in parts)
            {
                if (int.TryParse(part,out number))
                {
                    stack.Push(number.ToString());
                }
                else
                {
                    switch (part)
                    {
                        case "+":
                        case "-":
                        case "X":
                        case "÷":
                            string first,second;
                            if(stack.Count != 0)
                            {
                                second = stack.Pop();
                            }
                            else
                            {
                                return "E";
                            }
                            if (stack.Count != 0)
                            {
                                first = stack.Pop();
                            }
                            else
                            {
                                return "E";
                            }
                            stack.Push(calculate(part,first,second));
                            break;
                        default:
                            return "E";
                    }
                }
            }
            if(stack.Count == 1)
            {
                return stack.Pop();
            }
            else
            {
                return "E";
            }
        }
    }
}
