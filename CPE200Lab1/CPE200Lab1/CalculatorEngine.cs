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
        /// Check that is string of number.
        /// </summary>
        /// <param name="str">String will be check.</param>
        /// <returns>True if string is number, otherwise false.</returns>
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        /// <summary>
        /// Check that is string of operator.
        /// </summary>
        /// <param name="str">String will be check.</param>
        /// <returns>True if string is operator</returns>
        public bool isOperator(string str)
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

        /// <summary>
        /// Caculate with normal style calculation.
        /// </summary>
        /// <param name="str">The string of normal style.</param>
        /// <returns>The result of string.</returns>
        public string Process(string str)
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
        /// Calculate(squre root, one over x) single string of number.
        /// </summary>
        /// <param name="operate">The stirng of operator for calculation</param>
        /// <param name="operand">The string of operand.</param>
        /// <param name="maxOutputSize">Define maximum number of digit that is result.</param>
        /// <returns>The result of string.</returns>
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        return fixFractionalParts(Math.Sqrt(Convert.ToDouble(operand)) , maxOutputSize);
                    }
                case "1/x":
                    if(operand != "0")
                    {
                        return fixFractionalParts(1 / Convert.ToDouble(operand), maxOutputSize);
                    }
                    break;
            }
            return "E";
        }

        /// <summary>
        /// Calculate(plus, minus, mutiply, divide) two string of number.
        /// </summary>
        /// <param name="operate">The string of operator.</param>
        /// <param name="firstOperand">The string of first operand.</param>
        /// <param name="secondOperand">The string of second operand.</param>
        /// <param name="maxOutputSize">Define maximum number of digit that is result.</param>
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
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        return fixFractionalParts(Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand), maxOutputSize);
                    }
                    break;
                case "%":
                    //your code here
                    if(secondOperand == null)
                    {
                        return (Convert.ToDouble(firstOperand) / 100).ToString();
                    }
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
            }
            return "E";
        }

        /// <summary>
        /// Fix result is less than maximum output size.
        /// </summary>
        /// <param name="result">The result will be fix.</param>
        /// <param name="maxOutputSize">Define maximum munber of digits</param>
        /// <returns>The stirng of result is fixed.</returns>
        private static string fixFractionalParts(double result, int maxOutputSize)
        {
            // split between integer part and fractional part
            string[] parts = result.ToString().Split('.');
            // if integer part length is already break max output, return error
            if (parts[0].Length > maxOutputSize)
            {
                return "E";
            }
            if (parts.Length == 1)
            {
                return result.ToString();
            }
            // calculate remaining space for fractional part.
            int remainLength = maxOutputSize - parts[0].Length - 1;
            // trim the fractional part gracefully. =
            if (parts[1].Length < remainLength)
            {
                return result.ToString();
            }
            else
            {
                return result.ToString("N" + remainLength);
            }
        }
    }
}
