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


        public void btnClear_Click2()
        {
            display = "0";
            isContainDot = false;
            isNumberPart = false;
            isSpaceAllowed = false;
        }

        private bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        public bool isOperator2(string str) //OK
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

        public void btnNumber_Click2(String Buttt) //OK
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
            display += Buttt;
            isSpaceAllowed = true;
            
        }

        public void btnBinaryOperator_Click2(String Butt2) //OK
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
                display += " " + Butt2 + " ";
                isSpaceAllowed = false;
            }
        }

        private bool isOperator(char v) //IDK
        {
            throw new NotImplementedException();
        }

        public void btnEqual_Click2(string result2) //OK
        {         
            if (result2 is "E")
            {
                display = "Error";
            }
            else
            {
                display = result2;
            }
        }

        public void btnSign_Click2() //OK
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

        public void btnDot_Click2() //OK
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

        public void btnSpace_Click2() //OK
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

        public void btnBack_Click2() //OK
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

        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            if(!(isNumber(parts[0]) && isOperator2(parts[1]) && isNumber(parts[2])))
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
