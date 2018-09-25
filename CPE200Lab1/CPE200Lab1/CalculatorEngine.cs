using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        private bool isNumber(string str)
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
                    return true;
            }
            return false;
        }

        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            }
            else
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }

        }

        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
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
                    try
                    {
                        double result;
                        string[] parts;
                        int remainLength;
                        string Str_result;
                        result = (1.0 / Convert.ToDouble(operand));
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
                    catch (Exception)
                    {
                        return "E";
                    }
                    break;
            }
            return "E";
        }

        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            try
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
                            string Str_result;
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
                        catch (Exception)
                        {
                            return "E";
                        }
                        break;
                    case "%":
                        return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return "E";
        }
    }
}
