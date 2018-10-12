using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class TheCalculatorEngine
    {
        protected bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }
        
        protected bool isOperator(string str)
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
        protected bool isUnary(string str)
        {
            switch (str)
            {
                case "1/x":
                case "√":
                    return true;
            }
            return false;
        }
        public string calculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        return fixFractionalParts(Math.Sqrt(Convert.ToDouble(operand)), maxOutputSize);
                    }
                case "1/x":
                    if (operand != "0")
                    {
                        return fixFractionalParts(1 / Convert.ToDouble(operand), maxOutputSize);
                    }
                    break;
            }
            return "E";
        }
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
                    if (secondOperand == null)
                    {
                        return (Convert.ToDouble(firstOperand) / 100).ToString();
                    }
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
            }
            return "E";
        }
        private string fixFractionalParts(double result, int maxOutputSize)
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