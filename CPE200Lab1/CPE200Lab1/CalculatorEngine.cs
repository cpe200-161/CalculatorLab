using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public string calculate(string operate, string firstOperand, string secondOperand, string SecondOperate, int maxOutputSize = 8)
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
                    if (SecondOperate == "+")
                    {
                        return (Convert.ToDouble(firstOperand) + (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                    }
                    if (SecondOperate == "-")
                    {
                        return (Convert.ToDouble(firstOperand) - (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                    }
                    if (SecondOperate == "X")
                    {
                        return (Convert.ToDouble(firstOperand) * (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                    }
                    if (SecondOperate == "÷")
                    {
                        return (Convert.ToDouble(firstOperand) / (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                    }
                    else
                    {
                        return (0.01 * Convert.ToDouble(secondOperand)).ToString();
                    }
                case "1/x":
                    double result2;
                    string[] parts2;
                    int afterdot1;
                      if (Convert.ToDouble(firstOperand) != 0)
                    {
                        result2 = 1 / Convert.ToDouble(firstOperand);
                        parts2 = result2.ToString().Split('.');
                        if (parts2[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        afterdot1 = maxOutputSize - parts2[0].Length - 1;
                        return result2.ToString("N" + afterdot1);
                   }
                    break;
                case "√":
                    double result3;
                    string[] parts3;
                    int afterdot2;
                    if(Convert.ToDouble(firstOperand) != 0)
                    {
                        result3 = Math.Sqrt(Convert.ToDouble(firstOperand));
                        parts3 = result3.ToString().Split('.');
                        if( parts3[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        afterdot2 = maxOutputSize - parts3[0].Length - 1;
                        return result3.ToString("N" + afterdot2);
                    }
                    break;
            }
            return "E";
        }

    }
}
