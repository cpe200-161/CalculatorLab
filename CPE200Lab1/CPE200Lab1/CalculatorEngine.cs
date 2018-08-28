using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public string calculate(string operate, string firstOperand, string secondOperand, string operateoperate, int maxOutputSize = 8)
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
                        double result;
                        string[] parts;
                        int remainLength;

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
                    //your code here
                    if (operateoperate == "+")
                    {
                        return (Convert.ToDouble(firstOperand) + (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                    }
                    if (operateoperate == "-")
                    {
                        return (Convert.ToDouble(firstOperand) - (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                    }
                    if (operateoperate == "X")
                    {
                        return (Convert.ToDouble(firstOperand) * (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                    }
                    if (operateoperate == "÷")
                    {
                        return (Convert.ToDouble(firstOperand) / (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                    }
                    break;
                case "1/x":
                    double result2;
                    string[] parts2;
                    int remainLength2;
                    if (Convert.ToDouble(firstOperand) != 0)
                    {
                        result2 = 1 / Convert.ToDouble(firstOperand);
                        parts2 = result2.ToString().Split('.');
                        if (parts2[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength2 = maxOutputSize - parts2[0].Length - 1;
                        return result2.ToString("N" + remainLength2);
                    }
                    break;
                case "√":
                    double result1;
                    string[] parts1;
                    int remainLength1;
                    if (Convert.ToDouble(firstOperand) >= 0)
                    {
                        result1 = Math.Sqrt(Convert.ToDouble(firstOperand));
                        parts1 = result1.ToString().Split('.');
                        if (parts1[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength1 = maxOutputSize - parts1[0].Length - 1;
                        return result1.ToString("N" + remainLength1);
                    }
                    break;
            }
            return "E";
        }
    }
}
