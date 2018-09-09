using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        double result;
        string[] parts;
        int remainLength;
        public string calculate(string operate, string firstOperand, string secondOperand, string operateForPercent, int maxOutputSize = 8)
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
                        if (setprecision(firstOperand, secondOperand) == 0)
                        {
                            return "E";
                        }

                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    if (operateForPercent == "+")
                    {
                        return (Convert.ToDouble(firstOperand) + ((Convert.ToDouble(firstOperand) / 100) * Convert.ToDouble(secondOperand))).ToString();
                    }
                    else if (operateForPercent == "-")
                    {
                        return (Convert.ToDouble(firstOperand) - ((Convert.ToDouble(firstOperand) / 100) * Convert.ToDouble(secondOperand))).ToString();
                    }
                    else if (operateForPercent == "X")
                    {
                        return (Convert.ToDouble(firstOperand) * ((Convert.ToDouble(firstOperand) / 100) * Convert.ToDouble(secondOperand))).ToString();
                    }
                    else if (operateForPercent == "÷")
                    {
                        return (Convert.ToDouble(firstOperand) / ((Convert.ToDouble(firstOperand) / 100) * Convert.ToDouble(secondOperand))).ToString();
                    }
                    else
                    {
                        return ((Convert.ToDouble(firstOperand) / 100) * Convert.ToDouble(secondOperand)).ToString();
                    }

                case "√":
                    if (setprecision(firstOperand, secondOperand) == 0)
                    {
                        return "E";
                    }
                    return (Math.Sqrt(Convert.ToDouble(firstOperand))).ToString("N" + remainLength);
                case "1/X":
                    if (setprecision(firstOperand, secondOperand) == 0)
                    {
                        return "E";
                    }
                    return (1 / Convert.ToDouble(firstOperand)).ToString("N" + remainLength);
                case "MC":
                    return "0";
                case "MS":
                    return firstOperand;
                case "M+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "M-":
                    return (Convert.ToDouble(secondOperand) - Convert.ToDouble(firstOperand)).ToString();
            }
            return "E";
        }

        public int setprecision(string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
            // split between integer part and fractional part
            parts = result.ToString().Split('.');
            // if integer part length is already break max output, return error
            if (parts[0].Length > maxOutputSize)
            {
                return 0;
            }
            // calculate remaining space for fractional part.
            remainLength = maxOutputSize - parts[0].Length - 1;
            // trim the fractional part gracefully. =
            return remainLength;
        }
    }
}
