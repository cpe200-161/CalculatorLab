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
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "M+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "M-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    if (secondOperand == "0")
                    {
                        return "E";
                    }
                    else
                    {
                        ans = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)).ToString();
                        if (ans.Length > maxOutputSize)
                        {
                            return ans.Substring(0, 8);
                        }
                        else
                        {
                            return ans.ToString();
                        }
                    }
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
                        if (ans.Length > maxOutputSize)
                        {
                            return ans.Substring(0, 8);
                        }
                        else
                        {
                            return ans.ToString();
                        }
                    }
                case "√":
                    if (Convert.ToDouble(secondOperand) < -1)
                    {
                        return "E";
                    }
                    else
                    {
                        ans = (Math.Sqrt(Convert.ToDouble(secondOperand))).ToString();
                        if (ans.Length > maxOutputSize)
                        {
                            return ans.Substring(0, 8);
                        }
                        else
                        {
                            return ans.ToString();
                        }
                    }
            }
            return "E";
        }
    }
}
