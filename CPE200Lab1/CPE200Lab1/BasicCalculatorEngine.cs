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
        /// Check that is string of number 
        /// </summary>
        /// <param name="str"> str is input that will be check </param>
        /// <returns> True If string is number, otherwise false </returns>
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        /// <summary>
        /// Check that is string of operator
        /// </summary>
        /// <param name="str"> str is input that will be check </param>
        /// <returns>  True If string is operator, otherwise false </returns>
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
        /// Calculating using a regular calculator
        /// </summary>
        /// <param name="str"> The string of normal style calculation </param>
        /// <returns> Resulf of string </returns>
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
        /// Calculate(squre root, one over x) with one string of number
        /// </summary>
        /// <param name="operate"> The string of operator for calculation </param>
        /// <param name="operand"> The string of operate </param>
        /// <param name="maxOutputSize"> Define maximum number of that is result </param>
        /// <returns> Resulf of string </returns>
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
        /// Calculate(plus, minus, Multiply, Divide, percent) with two string of number
        /// </summary>
        /// <param name="operate"> The string of operator for calculation </param>
        /// <param name="firstOperand"> The string of first operand </param>
        /// <param name="secondOperand"> The string of second operand </param>
        /// <param name="maxOutputSize"> Define maximum number of that is result </param>
        /// <returns> Resulf of string </returns>
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
                    try
                    {
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
                            return result.ToString("G" + remainLength);
                        }
                    }
                    catch (Exception)
                    {
                        return "E";
                    }

                    break;
                case "%":
                    try
                    {
                        return (Convert.ToDouble(firstOperand) * (Convert.ToDouble(secondOperand) / 100)).ToString();
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
