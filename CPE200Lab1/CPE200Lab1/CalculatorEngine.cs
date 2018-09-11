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
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        return FixDecimalPart(Math.Sqrt(Convert.ToDouble(operand)), maxOutputSize);
                    }
                case "1/x":
                    if(operand != "0")
                    {
                        return FixDecimalPart(1 / Convert.ToDouble(operand), maxOutputSize);
                    }
                    break;
            }
            return "E";
        }

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
