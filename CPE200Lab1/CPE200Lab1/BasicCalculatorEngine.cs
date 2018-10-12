using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class BasicCalculatorEngine
    {
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        public bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "%":
                    return true;
            }
            return false;
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
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        string Str_Result = result.ToString();
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        if (Str_Result.Contains("."))
                        {
                            Str_Result = Str_Result.TrimEnd('0');
                            if (Str_Result.EndsWith("."))
                            {
                                Str_Result = Str_Result.TrimEnd('.');
                            }
                        }
                        return Str_Result;
                    }
                    break;
                case "%":
                    return (Convert.ToDouble(firstOperand) * (Convert.ToDouble(secondOperand) / 100)).ToString();
            }
            return "E";
        }

        public string calculator(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;
                        string Str_result;

                        result = Math.Sqrt(Convert.ToDouble(operand));
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        Str_result = result.ToString();
                        if (Str_result.Contains("."))
                        {
                            Str_result = Str_result.TrimEnd('0');
                            if (Str_result.EndsWith("."))
                            {
                                Str_result = Str_result.TrimEnd('.');
                            }
                        }
                        return Str_result;
                    }
                case "1/x":
                    if (operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
                        string Str_Result = result.ToString();
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        if (Str_Result.Contains("."))
                        {
                            Str_Result = Str_Result.TrimEnd('0');
                            if (Str_Result.EndsWith("."))
                            {
                                Str_Result = Str_Result.TrimEnd('.');
                            }
                        }
                        return Str_Result;
                    }
                    break;
            }
            return "E";
        }
    }
}
