using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace CPE200Lab1
{
    class CalculatorEngine
    {
 
 
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

                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;
 
                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                      
                        parts = result.ToString().Split('.');
                  
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
               
                        remainLength = maxOutputSize - parts[0].Length - 1;
                      
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    //your code here
                    break;
                case "1/X":
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1/Convert.ToDouble(firstOperand));

                        parts = result.ToString().Split('.');

                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }

                        remainLength = maxOutputSize - parts[0].Length - 1;

                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "√":
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Math.Sqrt( Convert.ToDouble(firstOperand)));

                        parts = result.ToString().Split('.');

                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }

                        remainLength = maxOutputSize - parts[0].Length - 1;

                        return result.ToString("N" + remainLength);
                    }
                    break;
            }
            return "E";
        }
 
    }
}