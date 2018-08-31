using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
        private bool isNumberPart = false;
        private bool isContainDot = false;
        private bool isSpaceAllowed = false;

        private string display = "0";

        public string Display()
        {
            return display;
        }

        public void handleNumber(string n)
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
            display += n;
            isSpaceAllowed = true;
        }

        public void handleBinary(string n)
        {

            isNumberPart = false;
            isContainDot = false;
            string current = display;

            if (current[current.Length - 1] != ' ' || isOperator(current[current.Length - 2].ToString()))
            {
                display += " " + n + " ";
                isSpaceAllowed = false;
            }
        }

        public void handleBack()
        {
            // check if the last one is operator
            string current = display;
            if (current[current.Length - 1] is ' ' && current.Length > 2 && isOperator(current[current.Length - 2].ToString()))
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

        public void handleClear()
        {
            display = "0";
            isContainDot = false;
            isNumberPart = false;
            isSpaceAllowed = false;
        }

        public void handleEqual()
        {
            string result =Process(display);
            if (result is "E")
            {
                display = "Error";
            }
            else
            {
               display = result;
            }
        }

        public void handleSign()
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

        public void handleDot()
        {
            if (!isContainDot)
            {
                isContainDot = true;
                display += ".";
                isSpaceAllowed = false;
            }
        }

        public void handleSpace()
        {
            if (isSpaceAllowed)
            {
               display += " ";
                isSpaceAllowed = false;
            }
        }

        private bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        
        public bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }

        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            if(!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            } else
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }

        }
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                case "1/x":
                    if(operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                    break;
            }
            return "E";
        }

        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    //your code here
                    break;
            }
            return "E";
        }
    }
}
