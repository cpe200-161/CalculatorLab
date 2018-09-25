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
        public string Process(string str)
        {
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
                    if (text == "+" || text == "-" || text == "X" || text == "÷" || text == "%")
                    {
                        string first = null, second = null;

                        try
                        {
                            second = numStack.Pop();
                            first = numStack.Pop();
                        }
                        catch (Exception ex)
                        {
                            return "E";
                        }

                        if (text == "%")
                        {
                            numStack.Push(first);
                        }
                        numStack.Push(calculate(text, first, second));
                    }

                    else if (text == "√" || text == "1/x")
                    {
                        string num = null;

                        try
                        {
                            num = numStack.Pop();
                        }
                        catch (Exception ex)
                        {
                            return "E";
                        }
                        numStack.Push(unaryCalculate(text, num));
                    }

                    else
                    {
                        return "E";
                    }
                }
            }

            if (numStack.Count == 1)
            {
                try
                {
                    return numStack.Peek();
                }
                catch (Exception ex)
                {
                    return "E";
                }
            }

            return "E";
            
        }
    }
}
