using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class Calculator
    {
        string keep_operate;
        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            keep_operate = operate;
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
                    return (((Convert.ToDouble(secondOperand)) / 100) * Convert.ToDouble(firstOperand)).ToString();

                case "√":
                    double result2;
                    string[] parts2;
                    int remainLength2;

                    result2 = (Math.Sqrt(Convert.ToDouble(firstOperand)));
                    parts2 = result2.ToString().Split('.');
                    if (parts2[0].Length > maxOutputSize)
                    {
                        return "E";
                    }
                    remainLength2 = maxOutputSize - parts2[0].Length - 1;
                    return result2.ToString("N" + remainLength2);

                case "1/X":
                    double result3;
                    string[] parts3;
                    int remainLength3;

                    result3 = (1 / Convert.ToDouble(firstOperand));
                    parts3 = result3.ToString().Split('.');
                    if (parts3[0].Length > maxOutputSize)
                    {
                        return "E";
                    }
                    remainLength3 = maxOutputSize - parts3[0].Length - 1;
                    return result3.ToString("N" + remainLength3);
            }
            return "E";
        }
    }
}
