﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
        String Result = "";
        public string calculate(string operate, string firstOperand, string secondOperand, string prev_operate, int maxOutputSize = 8)
        {
            string ans;
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
                    switch (prev_operate)
                    {
                        case "+":
                            return ((Convert.ToDouble(firstOperand)) + (Convert.ToDouble(secondOperand) )).ToString();
                            break;
                        case "-":
                            return ((Convert.ToDouble(firstOperand)) - (Convert.ToDouble(secondOperand) )).ToString();
                            break;
                        case "X":
                            return ((Convert.ToDouble(firstOperand)) * (Convert.ToDouble(secondOperand) )).ToString();
                            break;
                        case "÷":
                            if (Convert.ToDouble(secondOperand) != 0)
                            {
                                return ((Convert.ToDouble(firstOperand)) / (Convert.ToDouble(secondOperand) )).ToString();
                            }
                            else
                            {
                                return "Error";
                            }
                    }
                    break;
                case "1/X":
                    if (firstOperand is "0")
                    {
                        return "Error";
                    }
                    else
                    {
                        ans = (1 / Double.Parse(firstOperand)).ToString();
                        if (ans.Length > 8)
                        {
                            ans = ans.Remove(8, ans.Length - 8) + "E";
                        }
                        return ans;
                    }
                case "√":
                    ans = (Math.Sqrt(Double.Parse(firstOperand))).ToString();
                    if (ans.Length > 8)
                    {
                        ans = ans.Remove(8, ans.Length - 8) + "E";
                    }

                    return ans;
            }
            return "E";
        }
    }
}
