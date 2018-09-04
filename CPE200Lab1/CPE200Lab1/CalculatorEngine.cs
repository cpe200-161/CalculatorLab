﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public string calculate(string operate, string firstOperand, string secondOperand, string pevOperator, int maxOutputSize = 8)
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
                    if (pevOperator == "+")
                    {
                        return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                    }
                    else if (pevOperator == "-")
                    {
                        return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                    }
                    else if (pevOperator == "X")
                    {
                        return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                    }
                    else if (pevOperator == "÷")
                    {
                        return (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)).ToString();
                    }
                    break;
              
            }
            return "E";
        }
        public string squareRoot(string number)
        {
            if (float.Parse(number) < 0)
            {
                return "Unindentified";
            }
            else
            {
                float ans = (float)Math.Sqrt(float.Parse(number));
                return ans.ToString();
            }
        }

        public string overX(string number)
        {
            if (float.Parse(number) == 0)
            {
                return "Unindentified";
            }
            else
            {
                float ans = (1 / (float.Parse(number)));
                return ans.ToString();
            }
        }

        public string percentage(string number1, string number2)
        {
            float ans = float.Parse(number1) * float.Parse(number2) / 100;
            return ans.ToString();
        }

    }
}
