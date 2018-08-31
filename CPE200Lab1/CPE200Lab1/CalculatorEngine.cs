using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
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
                        return FixDecimalPart(Convert.ToDouble(firstOperand)/Convert.ToDouble(secondOperand), maxOutputSize);
                    }
                    break;
                case "%":
                    //your code here
                    if (secondOperand == null)
                    {
                        return (Convert.ToDouble(firstOperand) / 100).ToString();
                    }
                    else
                    {
                        return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
                    }
                case "√":
                    return FixDecimalPart(Math.Sqrt(Convert.ToDouble(firstOperand)), maxOutputSize);
            }
            return "E";
        }

        private static string FixDecimalPart(double result, int maxOutputSize)
        {
            string[] parts;
            int remainLength;

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
            return result.ToString("N" + remainLength);
        }
    }
}
