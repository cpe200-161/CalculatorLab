using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class BasicCalculatorEngine
    {
        public string calculate(string oper,string firstOperand)
        {
            int maxOutputSize = 8;
            switch (oper)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(firstOperand));
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
                        return result.ToString("G" + remainLength);
                    }
                case "1/x":
                    if (oper != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(firstOperand));
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
                        return result.ToString("G" + remainLength);
                    }
                    break;
            }
            return "E";
        }
        public string calculate(string oper,string firstOperand,string secondOperand)
        {
            switch (oper)
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
                        if (parts[0].Length > 8)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = 8 - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("G" + remainLength);
                    }
                    break;
                case "%":
                    if (firstOperand == null)
                    {
                        return (Convert.ToDouble(firstOperand) / 100).ToString();
                    }
                    else
                    {
                        return ((Convert.ToDouble(secondOperand) / 100) * Convert.ToDouble(firstOperand)).ToString();
                    }
                    
            }
            return "E";
        }


    }
}