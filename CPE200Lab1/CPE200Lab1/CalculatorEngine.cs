using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public string calculate(string operate1, string firstOperand, string secondOperand, string operate2,int maxOutputSize = 8)
        {
            if(operate1 == "%")
            {
                secondOperand = ((Convert.ToDouble(secondOperand) / 100) * Convert.ToDouble(firstOperand)).ToString();
            }
            switch (operate2)
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
                
            }
            return "E";
        }

        public string calculateSqrt(string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            if (secondOperand == null)
            {
                return Math.Round((Math.Sqrt(Convert.ToDouble(firstOperand))), 4, MidpointRounding.AwayFromZero).ToString();
            }
            else
            {
                return Math.Round((Math.Sqrt(Convert.ToDouble(secondOperand))), 4, MidpointRounding.AwayFromZero).ToString();
            }
            
        }
    }
}
