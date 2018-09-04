using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        int maxOutputSize = 8;
        string temp;

        public string calculate(string operate, string firstOperand, string secondOperand, string FristOperate)
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
                    temp = (Convert.ToDouble(firstOperand) * (Convert.ToDouble(secondOperand)/100)).ToString();
                    secondOperand = temp;
                    if (FristOperate == "+")
                    {
                        return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                    }else if (FristOperate == "-")
                    {
                        return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                    }
                    else if (FristOperate == "X")
                    {
                        return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                    }
                    else if (FristOperate == "÷")
                    {
                        return (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)).ToString();
                    }
                    break;
                case "√":
                        return (Math.Sqrt(Convert.ToDouble(secondOperand))).ToString();
                    break;
                case "1/x":
                        return (1 / Convert.ToDouble(secondOperand)).ToString();
                    break;
            }
            return "E";
        }
    }
}
