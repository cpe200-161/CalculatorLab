using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
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
                case "√":
                    result = ((float)Math.Sqrt(Convert.ToDouble(secondOperand)));
                    parts = result.ToString().Split('.');
                    if (parts[0].Length > maxOutputSize)
                    {
                        return "E";
                    }
                    remainLength = maxOutputSize - parts[0].Length - 1;
                    return result.ToString("N" + remainLength);
                case "1/x":
                    if (secondOperand != "0")
                    {
                        result = ((float)1 / Convert.ToDouble(secondOperand));
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1; Console.WriteLine(firstOperand);
                        return result.ToString("N" + remainLength);
                    }
                    return "E";
                case "÷":
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
                    return "E";
                case "%":
                    //your code here
                    if (firstOperand == null)
                    {
                        firstOperand = "1";
                    }
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
                case "M+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "M-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
            }
            return secondOperand;
        }
    }
}
