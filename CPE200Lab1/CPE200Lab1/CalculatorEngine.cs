using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    /// <summary>
    /// Provide method for calculate string of number.
    /// </summary>
    public class CalculatorEngine
    {
        /// <summary>
        /// Check that is a number.
        /// </summary>
        /// <param name="str">
        /// The string of number.
        /// </param>
        /// <returns>
        /// Return true if stirng is number, otherwise return false. 
        /// </returns>
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        /// <summary>
        /// Check that is an operator.
        /// </summary>
        /// <param name="str">
        /// The string of operator
        /// </param>
        /// <returns>
        /// Return true if the string is operator, otherwise return false.
        /// </returns>
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
        /// Calculate with normal style.
        /// </summary>
        /// <param name="str">
        /// The string of normal style.
        /// </param>
        /// <returns>
        /// The string of result.
        /// </returns>
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
        /// Calculate single operand for square root and one over X.
        /// </summary>
        /// <param name="operate">
        /// The operator for calculate.
        /// </param>
        /// <param name="operand">
        /// The operand going to calculate.
        /// </param>
        /// <param name="maxOutputSize">
        /// Defind maximum number of digits for result.
        /// </param>
        /// <returns>
        /// The string of result.
        /// </returns>
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    // Cannot use try-catch function in this case
                    // because double can store NaN value
                    if (Convert.ToDouble(operand) >= 0)
                    {
                        return FixDecimalPart(Math.Sqrt(Convert.ToDouble(operand)), maxOutputSize);
                    }
                    break;
                case "1/x":
                    // cannot use try-catch function in thid case
                    // because double can store infinity value
                    if(operand != "0")
                    {
                        return FixDecimalPart(1 / Convert.ToDouble(operand), maxOutputSize);
                    }
                    break;
            }
            return "E";
        }

        /// <summary>
        /// Fix the number of input is not more than maximum output size.
        /// </summary>
        /// <param name="result">
        /// The input going to fix.
        /// </param>
        /// <param name="maxOutputSize">
        /// Defind maximum of digits for input.
        /// </param>
        /// <returns>
        /// The string of result that is not more than maximum output size.
        /// </returns>
        private static string FixDecimalPart(double result, int maxOutputSize)
        {
            string[] parts;
            int remainLength;

            // split between integer part and fractional part
            parts = result.ToString().Split('.');
            if (parts.Length == 1)
            {
                return result.ToString();
            }
            // if integer part length is already break max output, return error
            if (parts[0].Length > maxOutputSize)
            {
                return "E";
            }
            // calculate remaining space for fractional part.
            remainLength = maxOutputSize - parts[0].Length - 1;
            // trim the fractional part gracefully. =
            if (parts[1].Length > remainLength)
            {
                return result.ToString("N" + remainLength);
            }
            else
            {
                return result.ToString();
            }
        }

        /// <summary>
        /// Calculate two number of string and return result. 
        /// </summary>
        /// <param name="operate">
        /// The operator for calculate.
        /// </param>
        /// <param name="firstOperand">
        /// The first operand going to calculate.
        /// </param>
        /// <param name="secondOperand">
        /// The second operand going to calculate.
        /// </param>
        /// <param name="maxOutputSize">
        /// Defind maximum number of digits for result.
        /// </param>
        /// <returns>
        /// The string of result.
        /// </returns>
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
                    // Cannot use try catch for catch this case
                    // because Double can store infinity value 
                    if (secondOperand != "0")
                    {
                        return FixDecimalPart(Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand), maxOutputSize);
                    }
                    break;
                case "%":
                    //your code here
                    if (secondOperand == null)
                    {
                        return (Convert.ToDouble(firstOperand) / 100).ToString();
                    }
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
                    break;
            }
            return "E";
        }
    }
}
