using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
        double memorizedOperand = 0;
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
                    return (Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100).ToString();
                case "√":
                    return (Math.Sqrt(Convert.ToDouble(firstOperand))).ToString();
                case "1/x":
                    return (1 / Convert.ToDouble(firstOperand)).ToString();
                case "MS":
                    memorizedOperand = Convert.ToDouble(firstOperand);
                    return firstOperand;
                case "MR":
                    if (memorizedOperand != 0)
                    {
                        return Convert.ToString(memorizedOperand);
                    }
                    else
                    {
                        return "0";
                    }
                case "MC":
                    memorizedOperand = 0;
                    return "0";
                case "M+":
                    memorizedOperand += Convert.ToDouble(firstOperand);
                    return Convert.ToString(memorizedOperand);
                case "M-":
                    memorizedOperand -= Convert.ToDouble(firstOperand);
                    return Convert.ToString(memorizedOperand);
            }
            return "E";
        }
    }
}
