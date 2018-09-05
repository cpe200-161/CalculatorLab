using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine

    {
        public string calculate(string operate, string firstOperand, string secondOperand = "0", string operater_previous = "0", int maxOutputSize = 8)
        {
            string show;
            switch (operate)//method == 1
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "?":
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
                    switch (operater_previous)
                    {
                        case "+":
                            return Convert.ToDouble(firstOperand) + (Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100).ToString();
                        case "-":
                            return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100).ToString();
                        case "X":
                            return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100).ToString();
                        case "?":
                            if (Convert.ToDouble(secondOperand) != 0)
                            {
                                return (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100).ToString();
                            }
                            else
                            {
                                return "ERROR";
                            }
                    }
                    break;
                case "1/X":
                    if (firstOperand is "0")
                    {
                        return "ERROR";
                    }
                    else
                    {
                        show = (1 / Convert.ToDouble(firstOperand)).ToString();
                        if (show.Length > 8)
                        {
                            show = show.Remove(8, show.Length - 8);
                        }
                        return show;
                    }
                case "√":
                    show = (Math.Sqrt(Convert.ToDouble(firstOperand))).ToString();
                    if (show.Length > 8)
                    {
                        show = show.Remove(8, show.Length - 8);
                    }
                    return show;
             
            }
            return "E";
        }

    }
}