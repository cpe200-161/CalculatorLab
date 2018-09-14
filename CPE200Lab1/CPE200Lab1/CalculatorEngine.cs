using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        double memStore;
        double fResult;
        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    fResult = Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand);
                    return fResult.ToString();
                case "-":
                    fResult = Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand);
                    return fResult.ToString();
                case "X":
                    fResult = Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand);
                    return fResult.ToString();
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
                    double pResult = (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)) / 100;
                    return (Convert.ToDouble(firstOperand) + pResult).ToString();
                case "sqrt":
                    secondOperand = firstOperand;
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(secondOperand));
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "1/x":
                    secondOperand = firstOperand;
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1 / Convert.ToDouble(secondOperand));
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "MC":
                    memStore = 0;
                    break;
                case "MR":
                    return memStore.ToString();
                case "MS":
                    if(fResult == 0)
                    {
                        memStore = Convert.ToDouble(firstOperand);
                    }
                    else
                    {
                        memStore = fResult;
                        fResult = 0;
                    }
                    break;
                case "M+":
                    if (fResult == 0)
                    {
                        memStore += Convert.ToDouble(firstOperand);
                    }
                    else
                    {
                        memStore += fResult;
                        fResult = 0;
                    }
                    break;
                case "M-":
                    if (fResult == 0)
                    {
                        memStore -= Convert.ToDouble(firstOperand);
                    }
                    else
                    {
                        memStore -= fResult;
                        fResult = 0;
                    }
                    break;
            }
            return "E";
        }
    }
}
