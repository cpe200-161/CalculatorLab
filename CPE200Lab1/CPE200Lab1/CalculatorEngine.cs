using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine 
    {   /// <summary>
        /// Check string is number
        /// </summary>
        /// <param name="str">sting for check</param>
        /// <returns>true if str is number and false if str is not</returns>
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        /// <summary>
        /// check sting is operator
        /// </summary>
        /// <param name="str">string for check</param>
        /// <returns>true if str is operator and false if str is not</returns>
        public bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "√":
                case "%":
                case "1/X":
                    return true;
            }
            return false;
        }

        /// <summary>
        ///  input equation for calculate
        /// </summary>
        /// <param name="str">equation for calculate</param>
        /// <returns>result of equation</returns>
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
        /// calculate if use only one Number 
        /// </summary>
        /// <param name="operate">operator for calculate</param>
        /// <param name="operand">Number for calculate</param>
        /// <param name="maxOutputSize">Length of number</param>
        /// <returns>result</returns>
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                        return NotOver8(Math.Sqrt(Convert.ToDouble(operand)), maxOutputSize);
                case "1/X":
                    if (Convert.ToDouble(operand) != 0)
                    {
                        return NotOver8((1.0 / Convert.ToDouble(operand)), maxOutputSize);
                    }
                    break;   
            }
            return "E";
        }

        /// <summary>
        /// caculate for simple calculator
        /// </summary>
        /// <param name="operate"><operator for calculate</param>
        /// <param name="firstOperand">the first number for calculate</param>
        /// <param name="secondOperand">the second number for calculate</param>
        /// <param name="maxOutputSize">Length of number</param>
        /// <returns>result</returns>
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
                    if (Convert.ToDouble(secondOperand) != 0)
                    {
                        return NotOver8((Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)), maxOutputSize);
                    }
                    break;
                case "%":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)/100).ToString();
            }
            return "E";
        }

        /// <summary>
        /// change result if result's length over 8
        /// </summary>
        /// <param name="result">result's number for equation </param>
        /// <param name="maxOutputSize">length of number</param>
        /// <returns>result's length not over 8</returns>
        private static string NotOver8(double result, int maxOutputSize)
        {
            string[] parts;
            int remainLength;
            parts = result.ToString().Split('.');
            if (parts[0].Length > maxOutputSize)
            {
                return "E";
            }
            if (parts.Length <= 1)
            {
                return result.ToString();
            }
            else if (parts[1].Length < maxOutputSize)
            {
                return result.ToString();
            } 
            remainLength = maxOutputSize - parts[0].Length - 1;
            return result.ToString("N" + remainLength);
        }
    }
}
