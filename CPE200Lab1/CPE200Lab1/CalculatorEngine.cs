using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public  string calculate(string operate, string firstOperand, string secondOperand,string memory, int maxOutputSize = 8)
        {
            string temp;

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
                        return ((Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100)).ToString();
                    //your code here
                    case "√":
                        temp=(Math.Sqrt(Convert.ToDouble(secondOperand))).ToString();
                        if (temp.Length > 8) return temp.Substring(0, 8);
                        else return temp;
                    case "1/x":
                        temp = (1 / (Convert.ToDouble(secondOperand))).ToString();
                        if (temp.Length > 8) return temp.Substring(0, 8);
                        else return temp;
                case "MS":
                    return memory = secondOperand;
                case "M+":
                    return (Convert.ToDouble(memory) + Convert.ToDouble(secondOperand)).ToString();
                case "M-":
                    return (Convert.ToDouble(memory) - Convert.ToDouble(secondOperand)).ToString();
                case "MR":
                    return memory;
                case "MC":
                    return memory= (Convert.ToDouble(memory) *0).ToString();
                }
            
            return "E";
        }
    }
}
