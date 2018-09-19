using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
      
        public string calculate(int check,string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
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
                    if (firstOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100); //Finding the percent value
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        secondOperand = result.ToString("N" + remainLength); //secondOperand store new value after finding the percent value
                    }
                    else
                        return "0";
                    
                    //Check case and recursive then return value
                    if (check == 0)
                        return calculate(0, "+", firstOperand, secondOperand, maxOutputSize = 8);
                    else if (check == 1)
                        return calculate(1, "-", firstOperand, secondOperand, maxOutputSize = 8);
                    else if (check == 2)
                        return calculate(2, "X", firstOperand, secondOperand, maxOutputSize = 8);
                    else if (check == 3)
                        return calculate(3, "÷", firstOperand, secondOperand, maxOutputSize = 8);
                    else
                          return "0"; 
                   
            }
            return "E";
        }
    }
}
