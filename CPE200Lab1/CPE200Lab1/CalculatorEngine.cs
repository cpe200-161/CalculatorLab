using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        /// <summary>
        /// Check that string is number.
        /// </summary>
        /// <param name="str">str is string of input.</param>
        /// <returns>True if string is numer,otherwise false.</returns>
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        /// <summary>
        /// Check that string is operator.
        /// </summary>
        /// <param name="str">str is string of input.</param>
        /// <returns>True if string have operator.otherwise false.</returns>
        public bool isOperator(string str)
        {
            switch(str) {
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
        /// Calculate with normal Calculator.
        /// </summary>
        /// <param name="str">str is string of input.</param>
        /// <returns>The result from calculate.</returns>
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

        /// <summary>
        /// Calculate operator √ and 1/x of one number.
        /// </summary>
        /// <param name="operate">the string of operator.</param>
        /// <param name="operand">the string of number.</param>
        /// <param name="maxOutputSize">Maximum amount of information displayed.</param>
        /// <returns></returns>
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
                        return result.ToString("G" + remainLength);
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
                        return result.ToString("G" + remainLength);
                    }
                    break;
            }
            return "E";
        }

        /// <summary>
        /// Calculate operator +,-,X and ÷ of two number.
        /// </summary>
        /// <param name="operate">the string of operator.</param>
        /// <param name="firstOperand">the string of first number is input.</param>
        /// <param name="secondOperand">the string of second number is input.</param>
        /// <param name="maxOutputSize">Maximum amount of information displayed.</param>
        /// <returns>The result from calculate.</returns>
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
                            try
                            {
                                return result.ToString("G" + remainLength);
                            }
                            catch (Exception)
                            {
                                return "E";
                            }
                        }
                        catch (Exception)
                        {
                            return "E";
                        }
                    }
                    break;
                case "%":
                    //your code here
                    try
                    {
                        return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
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
