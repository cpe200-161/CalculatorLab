using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class BasicCalculatorEngine
    {
        /// <summary>
        /// Check if the string is number.
        /// </summary>
        /// <param name="str"> The string will be checked. </param>
        /// <returns> True if the string is number, otherwise false.</returns>
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        /// <summary>
        /// Check if the string is an operator.
        /// </summary>
        /// <param name="str"> The string will be checked. </param>
        /// <returns> True if the string is an operator, otherwise false.</returns>
        public bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Calculate square root and 1 over x operations.
        /// </summary>
        /// <param name="operate"> String of operators.</param>
        /// <param name="operand"> String of operands.</param>
        /// <param name="maxOutputSize"> Limited at 8-digit output number.</param>
        /// <returns> </returns>
        public string calculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        try
                        {
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
                        catch (Exception)
                        {
                            return "E";
                        }
                    }
                case "1/x":
                    if (operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        try
                        {
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
                        catch (Exception)
                        {
                            return "E";
                        }
                    }
                    break;
            }
            return "E";
        }

        /// <summary>
        /// Calculate plus, minus, multiply and divide operations.
        /// </summary>
        /// <param name="operate"> String of operators.</param>
        /// <param name="firstOperand"> String of first operand.</param>
        /// <param name="secondOperand"> String of second operand.</param>
        /// <param name="maxOutputSize"> Limited at 8-digit output number.</param>
        /// <returns> </returns>
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
                    return (Convert.ToDouble(secondOperand) / 100 * Convert.ToDouble(firstOperand)).ToString();
            }
            return "E";
        }
    }
}