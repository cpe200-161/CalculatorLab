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
        private bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }
        private bool OnlyOneOperand(string str)
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

        public string calculate(string oper)
        {
            myStack = new Stack<string>();
            string[] parts = oper.Split(' ');
            try
            {
                for (int i = 0; i < parts.Length; i++)
                {
                    if (isNumber(parts[i]))
                    {
                        myStack.Push(parts[i]);
                    }
                    else if (OnlyOneOperand(parts[i]))
                    {
                        string first;
                        first = myStack.Peek();
                        myStack.Pop();
                        myStack.Push(calculate(parts[i], first, 8));
                    }
                    else if (parts[i] == "%")
                    {
                        try
                        {
                            string first, second;
                            second = myStack.Peek();
                            myStack.Pop();
                            first = myStack.Peek();
                            myStack.Pop();
                            myStack.Push(calculate(parts[i], first, second, 8));
                        }
                        catch (Exception)
                        {
                            return "E";
                        }

                    }
                    else if (isOperator(parts[i]))
                    {

                        try
                        {
                            string first, second;
                            second = myStack.Peek();
                            myStack.Pop();
                            first = myStack.Peek();
                            myStack.Pop();
                            myStack.Push(calculate(parts[i], first, second, 8));
                        }
                        catch (Exception)
                        {
                            return "E";
                        }

                    }

                }
                if (myStack.Count == 1)
                {
                    return myStack.Peek();
                }
                else
                {
                    return "E";
                }
            }
            catch (Exception)
            {
                return "E";
            }



        }
    }
}