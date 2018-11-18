using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        private bool isNumberPart = false;
        private bool isContainDot = false;
        private bool isSpaceAllowed = false;
        private string display = "0";


        public new string calculate(string str)
        {
            if (str == null || str == "")
            {
                return "E";
            }
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            string firstOperand, secondOperand;
            if (str[0] == '+')
            {
                return "E";
            }
            foreach (string token in parts)
            {
                if (isNumber(token))
                {
                    rpnStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?
                    if (rpnStack.Count == 1)
                    {
                        return "E";
                    }
                    try
                    {
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                        result = calculate(token, firstOperand, secondOperand);
                    }
                    catch
                    {
                        return "E";
                    }

                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);
                }
                else if (token == "")
                {
                    continue;
                }
                else
                {
                    return "E";
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            if (rpnStack.Count > 1)
            {
                return "E";
            }
            try
            {
                result = rpnStack.Pop();
            }
            catch
            {
                return "E";
            }

            return Convert.ToDouble(result).ToString("0.####");
        }

        public string Display()
        {
            return display;
        }

        public bool isOperator(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                case 'X':
                case '÷':
                    return true;
            }
            return false;
        }

        public void Number_Click(string digit)
        {
            if (display is "Error")
            {
                return;
            }
            if (display is "0")
            {
                display = "";
            }
            if (!isNumberPart)
            {
                isNumberPart = true;
                isContainDot = false;
            }
            display += digit;
            isSpaceAllowed = true;
        }

        public void BinaryOperator_Click(string op)
        {
            if (display is "Error")
            {
                return;
            }
            isNumberPart = false;
            isContainDot = false;
            string current = display;
            if (current[current.Length - 1] != ' ' || isOperator(current[current.Length - 2]))
            {
                display += " " + op + " ";
                isSpaceAllowed = false;
            }
        }

        public void Back_Click()
        {
            if (display is "Error")
            {
                return;
            }
            // check if the last one is operator
            string current = display;
            if (current[current.Length - 1] is ' ' && current.Length > 2 && isOperator(current[current.Length - 2]))
            {
                display = current.Substring(0, current.Length - 3);
            }
            else
            {
                display = current.Substring(0, current.Length - 1);
            }
            if (display is "")
            {
                display = "0";
            }
        }

        public void Clear_Click()
        {
            display = "0";
            isContainDot = false;
            isNumberPart = false;
            isSpaceAllowed = false;
        }

        public void Equal_Click()
        {
            string result = calculate(display);
            if (result is "E")
            {
                display = "Error";
            }
            else
            {
                display = result;
                isSpaceAllowed = true;
                isContainDot = false;
                isNumberPart = true;
            }
        }

        public void Sign_Click()
        {
            if (display is "Error")
            {
                return;
            }
            if (isNumberPart)
            {
                return;
            }
            string current = display;
            if (current is "0")
            {
                display = "-";
            }
            else if (current[current.Length - 1] is '-')
            {
                display = current.Substring(0, current.Length - 1);
                if (display is "")
                {
                    display = "0";
                }
            }
            else
            {
                display = current + "-";
            }
            isSpaceAllowed = false;
        }

        public void Dot_Click()
        {
            if (display is "Error")
            {
                return;
            }
            if (!isContainDot)
            {
                isContainDot = true;
                display += ".";
                isSpaceAllowed = false;
            }
        }

        public void Space_Click()
        {
            if (display is "Error")
            {
                return;
            }
            if (isSpaceAllowed)
            {
                display += " ";
                isSpaceAllowed = false;
            }
        }
    }
}
