﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CPE200Lab1
{
    public class BasicCalculatorEngine
    {
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        /// <summary>
        /// Check this string is operator.
        /// </summary>
        /// <param name="str">string will be check</param>
        /// <returns>If sting is operator,return true.Otherwise,return flase</returns>
        public bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "1/x":
                case "%":
                case "√":
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Calculated by normal style calculation.
        /// </summary>
        /// <param name="str">Normal string </param>
        /// <returns>The result of string.</returns>
        public string calculate(string str)
        {
            string[] parts = str.Split(' ');

            if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            }
            else
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }

        }

        /// <summary>
        /// Calculate (square root) and (1 over x) with one string.
        /// </summary>
        /// <param name="operate">Operator for calculation.</param>
        /// <param name="operand">String is operanded. </param>
        /// <param name="maxOutputSize">Define maximum number of digit that is the result</param>
        /// <returns>The result of string.</returns>
        public string calculate(string operate, string operand, int maxOutputSize = 8)
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
                        return result.ToString("G" + remainLength);
                    }
                case "1/x":
                    if (operand != "0")
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
                        return result.ToString("G" + remainLength);
                    }
                    break;
            }
            return "E";
        }

        /// <summary>
        /// Calculate plus,minus,multiply,divide with two strings.
        /// </summary>
        /// <param name="operate">Operator for calculation</param>
        /// <param name="firstOperand">First string is operanded.</param>
        /// <param name="secondOperand">Second string is operanded.</param>
        /// <param name="maxOutputSize">Define maximum number of digit that is the result</param>
        /// <returns>The result of string.</returns>
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

                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;
                        try
                        {
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
                            return result.ToString("G" + remainLength);
                        }
                        catch (Exception)
                        {
                            return "E";
                        }
                    }

                    break;
                case "%":
                    try
                    {
                        return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();//your code here
                    }
                    catch (Exception)
                    {
                        return "E";
                    }

            }
            return "E";
        }
    }
}
