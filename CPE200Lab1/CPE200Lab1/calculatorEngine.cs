using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {

        public string calculate(int per ,string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
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
                        result = (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100);
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        secondOperand = result.ToString("N" + remainLength);
                        if (per ==0)
                        {
                            return calculate(per, "+", firstOperand, secondOperand, maxOutputSize = 8);
                        }
                        else if (per == 1)
                        {
                            return calculate(per, "-", firstOperand, secondOperand, maxOutputSize = 8);
                        }
                        else if (per == 2)
                        {
                            return calculate(per, "X", firstOperand, secondOperand, maxOutputSize = 8);
                        }
                        else if (per == 3)
                        {
                            return calculate(per , "÷", firstOperand, secondOperand, maxOutputSize = 8);
                        }
                    }

                    break;



                /*     case "1/x":

                             double result2;
                             string[] parts2;
                             int remainLength2;
                             result2 = (1 / Convert.ToDouble(firstOperand));
                             parts2 = result2.ToString().Split('.');
                             if (parts2[0].Length > maxOutputSize)
                             {
                                 return "E";
                             }
                             remainLength2 = maxOutputSize - parts2[0].Length - 1;

                             return result2.ToString("N" + remainLength2);
                         */

                case "√":
                    if (firstOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;
                        result = (Math.Sqrt(Convert.ToDouble(firstOperand)));
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        firstOperand = result.ToString("N" + remainLength);
                        return result.ToString("N" + remainLength);
                    }
                    break;
            }
                return "E";
            }

        }
    }
