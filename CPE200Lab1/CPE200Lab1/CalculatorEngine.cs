﻿using System;
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

        public string Display()
        {
            return display;
        }



        public string Calculator(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
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
        public void resetAll()
        {

            display = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
        }

        public void Number(string h)
        {


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
            string digit = h;
            if (display is "0")
            {
                display = ""; 
            }
            display += digit;
            isAfterOperater = false;


        }

        public void handleOperater()
        {
            if (isAfterEqual)
            {
                resetAll();
            }
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
        public void sum(string y)
        {
            if (display is "0")
            {
                display = "";
            }
            if (!isAfterOperater)
            {
                isAfterOperater = true;
                isAfterEqual = false;
            }
            display += y;
            isAllowBack = true;
        }


        public void Dot()
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

        public void Sign()
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

        public void Back()
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


    }

}