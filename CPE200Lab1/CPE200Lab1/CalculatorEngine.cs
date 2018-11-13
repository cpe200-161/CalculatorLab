using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }
        /// <summary>
        /// Check if string is operator.
        /// </summary>
        /// <param name="str">string will be check</param>
        /// <returns>If sting is operator,return true.Otherwise,return flase</returns>
        private bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "%":
                    return true;
            }
            return false;
        }

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
        /// Calculate √ and 1/x with one string.
        /// </summary>
        /// <param name="operate">Operator for calculation.</param>
        /// <param name="operand">String is operanded. </param>
        /// <param name="maxOutputSize">Define maximum number of digit that is the result</param>
        /// <returns>The result of string.</returns>
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    try
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(operand));
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return result.ToString("N" + remainLength).Contains(".") ? result.ToString("N" + remainLength).TrimEnd('0').TrimEnd('.') : result.ToString("N" + remainLength);

                    }
                    catch (Exception ex)
                    {
                        return "E";
                    }
                case "1/x":
                    if(operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
                        parts = result.ToString().Split('.');
                        
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return result.ToString("N" + remainLength).Contains(".") ? result.ToString("N" + remainLength).TrimEnd('0').TrimEnd('.') : result.ToString("N" + remainLength);

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

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        parts = result.ToString().Split('.');               
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return result.ToString("N" + remainLength).Contains(".") ? result.ToString("N" + remainLength).TrimEnd('0').TrimEnd('.') : result.ToString("N" + remainLength);

                    }
                    break;
                case "%":
                    return (float.Parse(secondOperand) * float.Parse(firstOperand) / 100).ToString();
                    
            }
            return "E";
        }
    }
}
