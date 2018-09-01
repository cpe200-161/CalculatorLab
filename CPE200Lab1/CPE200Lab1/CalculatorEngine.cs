using System;
using System.IO;
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
            string ans;
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
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        

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
                    if(firstOperand == "")
                    {
                        return (Convert.ToDouble(secondOperand)/100).ToString();
                    }
                    else
                    {
                        return (Convert.ToDouble(firstOperand) * (Convert.ToDouble(secondOperand)/100)).ToString();
                    }
                case "1/X":
                    if (secondOperand == "0")
                    {
                        return "E";
                    }
                    else
                    {
                        ans = (1 / Convert.ToDouble(secondOperand)).ToString();

                        if (ans.Length > 8)
                        {
                            ans[8] = "";
                        }
                    }
                case "√":
                    result = Math.Sqrt(Convert.ToDouble(secondOperand));
            }
            return "E";
        }
    }
}
