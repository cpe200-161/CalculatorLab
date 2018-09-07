using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{

    class CalculatorEngine
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string operate;
        private string display = "0";


        public void resetAll2()
        {
            display = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;         
        }

        public string Display()
        {
            return display;
        }

        public void btnNumber_Click2(String Butt)
        {
            if (display is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll2();
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
            display += Butt;
            isAfterOperater = false;
        }

        public void btnOperator_Click2(string operateArg)
        {
            

            if (display is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            operate = operateArg;
            switch (operateArg)
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
                    firstOperand = display;
                    isAfterOperater = true;
                    break;
            }
            isAllowBack = false;
        }

        public void btnEqual_Click2()
        {
            if(display is "0")
            {
                return;
            }
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

        public void btnDot_Click2()
        {
            if (display is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll2();
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

        public void btnSign_Click2()
        {
            if (display is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll2();
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

        public void btnBack_Click2()
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

                    return (Convert.ToDouble(firstOperand) % Convert.ToDouble(secondOperand)).ToString();

                    break;
            }
            return "E";
        }

      

    }

    
}
