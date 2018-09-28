using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : BasicCalculatorEngine
    {
        protected Stack<string> myStack;

        public string calculate(string str)
        {
            string[] parts = str.Split(' ');
            double number;
            myStack = new Stack<string>();
            try
            {
                foreach (string part in parts)
                {
                    if (double.TryParse(part, out number))
                    {
                        myStack.Push(number.ToString());
                    }
                    else
                    {
                        switch (part)
                        {
                            case "+":
                            case "-":
                            case "X":
                            case "÷":
                            case "%":
                                string first, second;
                                second = myStack.Pop();
                                first = myStack.Pop();
                                myStack.Push(calculate(part, first, second));
                                break;
                            case "1/x":
                            case "√":
                                string n;
                                n = myStack.Pop();
                                myStack.Push(calculate(part, n));
                                break;
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                return "E";
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