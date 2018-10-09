using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        Stack<string> myStack = new Stack<string>();
        public string calculate(string oper)
        {
            myStack = new Stack<string>();
            string[] numSet = oper.Split(' ');
            string firstOperand, secondOperand;
            foreach (string numOP in numSet)
            {
                if (isNumber(numOP))
                {
                    myStack.Push(numOP);
                }

                else
                {
                    if (numOP == "-" || numOP == "+" || numOP == "X" || numOP == "÷" || numOP == "%")
                    {
                        if (myStack.Count >= 2)
                        {
                            secondOperand = myStack.Peek();
                            myStack.Pop();
                            firstOperand = myStack.Peek();
                            myStack.Pop();
                            if (numOP == "%")
                            {
                                myStack.Push(firstOperand);
                            }
                            myStack.Push(calculate(numOP, firstOperand, secondOperand));
                        }
                        else
                        {
                            return "E";
                        }
                    }

                    else if (numOP == "√" || numOP == "1/x")
                    {
                        if (myStack.Count >= 1)
                        {
                            string num = myStack.Pop();
                            myStack.Push(calculate(numOP, num));
                        }
                        else
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

            if (myStack.Count > 1)
            {
                return "E";
            }

            return myStack.Peek();
        }
    }
}