using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : New_CalculatorEngine
    {
        private string display = "0";
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string operate;
        private double memory;

        public string Display()
        {
            return display;
        }

        public void resetAll()
        {
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            display = "0";
        }

        public string calculate(string str)
        {
            //Split input string to multiple parts by space
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            //As long as we have more than one part
            while (parts.Count > 1)
            {
                //Check if the first three is ready for calcuation
                if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
                {
                    return "E";
                }
                else
                {
                    //Calculate the first three
                    result = calculate(parts[1], parts[0], parts[2], 4);
                    //Remove the first three
                    parts.RemoveRange(0, 3);
                    // Put back the result
                    parts.Insert(0, result);
                }
            }
            return parts[0];
        }

        public void Number_Click(string digit)
        {
            if (display is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                display = "0";
            }
            if (display.Length is 8)
            {
                return;
            }
            isAllowBack = true;
            if (display is "0")
            {
                display = "";
            }
            display += digit;
            isAfterOperater = false;
        }

        public void Operator_Click(string op)
        {
            if (display is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            if (firstOperand != null)
            {
                string secondOperand = display;
                string result = calculate(operate, firstOperand, secondOperand);
                if (result is "E" || result.Length > 8)
                {
                    display = "Error";
                }
                else
                {
                    display = result;
                }
            }
            operate = op;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    firstOperand = display;
                    isAfterOperater = true;
                    break;
                case "%":
                    // your code here
                    break;
            }
            isAllowBack = false;
        }

        public void UnaryOperator_Click(string op)
        {
            if (display is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            operate = op;
            firstOperand = display;
            string result = calculate(operate, firstOperand);
            if (result is "E" || result.Length > 8)
            {
                display = "Error";
            }
            else
            {
                display = result;
            }
        }

        public void Equal_Click()
        {
            if (display is "Error")
            {
                return;
            }
            string secondOperand = display;
            string result = calculate(operate, firstOperand, secondOperand);
            if (result is "E" || result.Length > 8)
            {
                display = "Error";
            }
            else
            {
                display = result;
            }
            isAfterEqual = true;
        }

        public void Dot_Click()
        {
            if (display is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (display.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                display += ".";
                hasDot = true;
            }
        }

        public void Sign_Click()
        {
            if (display is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (display.Length is 8)
            {
                return;
            }
            if (display[0] is '-')
            {
                display = display.Substring(1, display.Length - 1);
            }
            else
            {
                display = "-" + display;
            }
        }

        public void Back_Click()
        {
            if (display is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if (display != "0")
            {
                string current = display;
                char rightMost = current[current.Length - 1];
                if (rightMost is '.')
                {
                    hasDot = false;
                }
                display = current.Substring(0, current.Length - 1);
                if (display is "" || display is "-")
                {
                    display = "0";
                }
            }
        }

        public void MP_Click()
        {
            if (display is "Error")
            {
                return;
            }
            memory += Convert.ToDouble(display);
            isAfterOperater = true;
        }

        public void MC_Click()
        {
            memory = 0;
        }

        public void MM_Click()
        {
            if (display is "Error")
            {
                return;
            }
            memory -= Convert.ToDouble(display);
            isAfterOperater = true;
        }

        public void MR_Click()
        {
            if (display is "error")
            {
                return;
            }
            display = memory.ToString();
        }
    }
}
