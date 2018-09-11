using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public string calculate(string operate, string firstOperand, string secondOperand, string operatePercent, int maxOutputSize = 8)
        {
            double result;
            string[] parts;
            int remainLength;
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
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    if (operatePercent == "+")
                    {
                        return (Convert.ToDouble(firstOperand) + (0.01 * Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand))).ToString();
                    }
                    else if (operatePercent == "-")
                    {
                        return (Convert.ToDouble(firstOperand) - (0.01 * Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand))).ToString();
                    }
                    else if (operatePercent == "X")
                    {
                        return (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand))).ToString();
                    }
                    else if (operatePercent == "÷")
                    {
                        return (Convert.ToDouble(firstOperand) / (0.01 * Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand))).ToString();
                    }
                    break;
                case "√":
                    return ((float)Math.Sqrt(Convert.ToDouble(firstOperand))).ToString();

                case "1/X":
                    result = (1 / Convert.ToDouble(firstOperand));
                    parts = result.ToString().Split('.');
                    if (parts[0].Length > maxOutputSize)
                    {
                        return "E";
                    }
                    remainLength = maxOutputSize - parts[0].Length - 1;
                    return result.ToString("N" + remainLength);
                case "M+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "M-":
                    return (Convert.ToDouble(secondOperand) - Convert.ToDouble(firstOperand)).ToString();
                case "MC":
                    return "0";
                case "MS":
                    return firstOperand;

            }
            return "E";
        }
    }
}
