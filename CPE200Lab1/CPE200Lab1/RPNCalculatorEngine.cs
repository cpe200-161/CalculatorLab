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
        public string calculate(string oper)
        {
            return oper;
        }

        public string Process(string str)
        {
            protected Stack<string> numStack = new Stack<string>();

            string[] numSet = str.Split(' ');

            foreach(string text in numSet)
            {
                if (isNumber(text))
                {
                    numStack.Push(text);
                }

                else
                {
                    if ((text == "+" || text == "-" || text == "X" || text == "÷" || text == "%") && numStack.Count >= 2)
                    {
                        string second = numStack.Pop();
                        string first = numStack.Pop();
                        if (text == "%")
                        {
                            numStack.Push(first);
                        }
                        numStack.Push(calculate(text, first, second));
                    }

                    else if ((text == "√" || text == "1/x") && numStack.Count >= 1)
                    {
                        string num = numStack.Pop();
                        numStack.Push(unaryCalculate(text, num));
                    }

                    else
                    {
                        return "E";
                    }
                }
            }

            if (numStack.Count != 1)
            {
                return "E";
            }

            return numStack.Peek();
        }
    }
}
