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
            Stack<string> stack = new Stack<string>();

            string[] numSet = str.Split(' ');
            string firstOperand, secondOperand;
            foreach (string numOP in numSet)
            {
                if (isNumber(numOP))
                {
                    stack.Push(numOP);
                }

                else
                {
                    if (numOP == "-" || numOP == "+" || numOP == "X" || numOP == "÷" || numOP == "%")
                    {
                        try
                        {
                            secondOperand = stack.Peek();
                            stack.Pop();
                            firstOperand = stack.Peek();
                            stack.Pop();
                            if (numOP == "%")
                            {
                                stack.Push(firstOperand);
                            }
                            stack.Push(calculate(numOP, firstOperand, secondOperand));
                        }
                        catch(Exception ex)
                        {
                            return "E";
                        }
                    }

                    else if (numOP == "√" || numOP == "1/x")
                    {
                        try
                        {
                            string num = stack.Pop();
                            stack.Push(unaryCalculate(numOP, num));
                        }
                       catch(Exception ex)
                        {
                            return "E";
                        }
                    }

                    else
                    {
                        return "E";
                    }
                }
            }

            if (stack.Count > 1)
            {
                return "E";
            }
            return stack.Peek();
        }
    }
}
