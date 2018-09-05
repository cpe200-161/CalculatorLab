using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
        public string calculate(string operate, string firstOperand, string secondOperand= "0", string operator_prev  = "0", int maxOutputSize = 8)
        {
            string R;
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
                    switch (operator_prev)
                    {
                        case "+" :
                            return (Convert.ToDouble(firstOperand) + (Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100)).ToString();
                            break;
                        case "-":
                            return (Convert.ToDouble(firstOperand) - (Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100)).ToString();
                            break;
                        case "X":
                            return (Convert.ToDouble(firstOperand) * (Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100)).ToString();
                            break;
                        case "÷":
                            if(Convert.ToDouble(secondOperand) != 0)
                            {
                                return (Convert.ToDouble(firstOperand) / (Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100)).ToString();
                            }
                            else
                            {
                                return "E";
                            }
                    }
                    break;
                case "1/X": 
                    if(firstOperand is "0")
                    {
                        return "E";
                    }
                    else
                    {
                        R = (1 / Double.Parse(firstOperand)).ToString();
                        if(R.Length > 8)
                        {
                            R = R.Remove(8, R.Length - 8);
                        }
                        return R;
                    }
             
                case "√":
                    R = (Math.Sqrt(Double.Parse(firstOperand))).ToString();
                    if(R.Length > 8)
                    {
                        R = R.Remove(8, R.Length - 8);
                    }
                    firstOperand = R;
                    return R;
                   
            }
            return "E";
        }

    }
}