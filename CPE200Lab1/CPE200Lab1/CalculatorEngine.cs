using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public string calculate(string operate, string firstOperand, string secondOperand, string oldOperator, int maxOutputSize = 8)
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

                    if (oldOperator == "+") return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                    else if (oldOperator == "-") return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                    else if (oldOperator == "X") return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                    else if (oldOperator == "÷") return (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)).ToString();
                    //your code here

                    break;
            }
            return "E";
        }

        public string percent(string first, string second)
        {
            float ans = float.Parse(first) * float.Parse(second) / 100;

            return ans.ToString();
        }

        public string sqrtRoot(string num)
        {
            float ans = (float)Math.Sqrt(float.Parse(num));

            return ans.ToString();
        }

        public string oneOverX(string num)
        {
            float ans = 1 / (float.Parse(num));

            return ans.ToString();
        }
    }
}