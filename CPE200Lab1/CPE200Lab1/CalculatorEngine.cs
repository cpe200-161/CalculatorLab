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
        /// calculate if use only one Number 
        /// </summary>
        /// <param name="oper">operator for calculate</param>
        /// <param name="fistOperand">Number for calculate</param>
        /// <param name="maxOutputSize">Length of number</param>
        /// <returns>result</returns>
        public string calculate(string oper, string firstOperand, int maxOutputSize = 8)
        {
            string[] parts;
            int remainLength;
            double result;
            switch (oper)
            {
                case "√":
                    result = Math.Sqrt(Convert.ToDouble(firstOperand));
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
                case "1/X":
                    if (Convert.ToDouble(oper) != 0)
                    {
                        result = (1.0 / Convert.ToDouble(firstOperand));
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
                    break;
            }
            return "E";
        }

        /// <summary>
        /// calculate
        /// </summary>
        /// <param name="oper">operator for calculate</param>
        /// <param name="fistOperand">first number for calculate</param>
        /// <param name="secondOperand">second number for calculate</param>
        /// <param name="maxOutputSize">Length of number</param>
        /// <returns>result</returns>
        public string calculate(string oper, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {

            switch (oper)
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
                        string[] parts;
                        int remainLength;
                        double result;
                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
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
                    break;
                case "%":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
            }
            return "E";
        }

        /// <summary>
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
            switch (str)
            {
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
    }
}
