using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class TheCalculatoreEngine
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
                case "1/x":
                case "√":
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

        public string calculate(string oper, string firstOperand, int maxOutputSize = 8)
        {
            switch (oper)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(firstOperand));
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        if ((Convert.ToDouble(result) * 10) % 2 == 0)
                        {
                            return result.ToString();
                        }
                        return result.ToString("N" + remainLength);
                    }
                case "1/x":
                    if (firstOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(firstOperand));
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        if (parts.Length <= 1)
                        {
                            return result.ToString();
                        }
                        else if (parts[1].Length < maxOutputSize)
                        {
                            return result.ToString();
                        }
                        return result.ToString("N" + remainLength);
                    }
                    break;
            }
            return "E";
        }

        public string calculate(string oper, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (oper)
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
                        if (parts.Length < 2 || parts[1].Length < maxOutputSize)
                        {
                            return result.ToString();
                        }
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
            }
            return "E";
        }
    }
}
