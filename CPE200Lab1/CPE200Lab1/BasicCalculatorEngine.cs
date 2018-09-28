using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class BasicCalculatorEngine
    {
        private bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        private bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }

        public string calculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(operand));
                        if (result % 1 == 0)
                        {
                            return result.ToString();
                        }
                        else
                        {
                            // split between integer part and fractional part
                            parts = result.ToString().Split('.');
                            string.Format(parts[1], "G29");
                            // if integer part length is already break max output, return error
                            if (parts[0].Length > maxOutputSize)
                            {
                                return "E";
                            }
                            else if (parts[1].Length + parts[0].Length > maxOutputSize)
                            {
                                remainLength = maxOutputSize - parts[0].Length - 1;
                                return result.ToString("N" + remainLength);
                            }
                            else
                            {
                                remainLength = maxOutputSize - parts[0].Length - 1;
                                string result2 = parts[0] + "." + parts[1];
                                return string.Format(result2, "N" + remainLength);
                            }
                        }
                    }
                case "1/x":
                    if (operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
                        if (result % 1 == 0)
                        {
                            return result.ToString();
                        }
                        else
                        {
                            // split between integer part and fractional part
                            parts = result.ToString().Split('.');
                            string.Format(parts[1], "G29");
                            // if integer part length is already break max output, return error
                            if (parts[0].Length > maxOutputSize)
                            {
                                return "E";
                            }
                            else if (parts[1].Length + parts[0].Length > maxOutputSize)
                            {
                                remainLength = maxOutputSize - parts[0].Length - 1;
                                return result.ToString("N" + remainLength);
                            }
                            else
                            {
                                remainLength = maxOutputSize - parts[0].Length - 1;
                                string result2 = parts[0] + "." + parts[1];
                                return string.Format(result2, "N" + remainLength);
                            }
                        }
                    }
                    break;
            }
            return "E";
        }

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
                    // Not allow devide be zero
                    try
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        if (result % 1 == 0)
                        {
                            return result.ToString();
                        }
                        else
                        {
                            // split between integer part and fractional part
                            parts = result.ToString().Split('.');
                            string.Format(parts[1], "G29");
                            // if integer part length is already break max output, return error
                            if (parts[0].Length > maxOutputSize)
                            {
                                return "E";
                            }
                            else if (parts[1].Length + parts[0].Length > maxOutputSize)
                            {
                                remainLength = maxOutputSize - parts[0].Length - 1;
                                return result.ToString("N" + remainLength);
                            }
                            else
                            {
                                remainLength = maxOutputSize - parts[0].Length - 1;
                                string result2 = parts[0] + "." + parts[1];
                                return string.Format(result2, "N" + remainLength);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return "E";
                    }
                case "%":
                    //your code here
                    return (Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100).ToString();
            }
            return "E";
        }
    }
}