using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        protected Stack<string> myStack;

        public string calculate(string oper)
        {
            myStack = new Stack<string>();

            string[] numSet = oper.Split(' ');

            foreach(string text in numSet)
            {
                if (isNumber(text))
                {
                    myStack.Push(text);
                }

                else
                {
                    if ((text == "+" || text == "-" || text == "X" || text == "÷" || text == "%") && myStack.Count >= 2)
                    {
                        string second = myStack.Pop();
                        string first = myStack.Pop();
                        if (text == "%")
                        {
                            myStack.Push(first);
                        }
                        myStack.Push(calculate(text, first, second));
                    }

                    else if ((text == "√" || text == "1/x") && myStack.Count >= 1)
                    {
                        string num = myStack.Pop();
                        myStack.Push(calculate(text, num));
                    }

                    else
                    {
                        return "E";
                    }
                }
            }

            if (myStack.Count != 1)
            {
                return "E";
            }

            return myStack.Peek();
        }
    }
}
