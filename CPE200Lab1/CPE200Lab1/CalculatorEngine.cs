﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public string calculate(string operate, string firstOperand, string secondOperand, string operatorX, int maxOutputSize = 8)
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
                    {
                        double result;
                        // Not allow devide be zero
                        if (secondOperand != "0")
                        {
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
                    }
                    break;
                case "%":
                    {
                        if (operatorX == "+")
                        {
                            return (Convert.ToDouble(firstOperand) + (Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100)).ToString();
                        }
                        if (operatorX == "-")
                        {
                            return (Convert.ToDouble(firstOperand) - (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100)).ToString();
                        }
                        if (operatorX == "X")
                        {
                            return (Convert.ToDouble(firstOperand) * Convert.ToDouble(firstOperand) / 100).ToString();
                        }
                        if (operatorX == "÷")
                        {
                            return (Convert.ToDouble(firstOperand) / (Convert.ToDouble(secondOperand) / 100)).ToString();
                        }
                    }
                    break;
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(firstOperand));
                        parts = result.ToString().Split('.');

                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }

                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return firstOperand = result.ToString("N" + remainLength);
                    }
                case "1/x":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1 / Convert.ToDouble(firstOperand));

                        parts = result.ToString().Split('.');

                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }

                        remainLength = maxOutputSize - parts[0].Length - 1;

                        return firstOperand = result.ToString("N" + remainLength);
                    }
            }
            return "E";
        }
    }
}
