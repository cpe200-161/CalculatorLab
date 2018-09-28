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

                    return true;
            }
            return false;
        }
        private static string notOver8(double ans, int maxOutputSize)
        {
            string[] parts;
            int remainLength;
            parts = ans.ToString().Split('.');
            if (parts[0].Length > maxOutputSize)
            {
                return "E";
            }
            if (parts.Length <= 1)
            {
                return ans.ToString();
            }
            else if (parts[1].Length < maxOutputSize)
            {
                return ans.ToString();
            }
            remainLength = maxOutputSize - parts[0].Length - 1;
            return ans.ToString("N" + remainLength);
        }
        public string calculator(string oper, string firstOperand, int maxOutputSize = 8)
        {
            switch (oper)
            {
                case "√":
                    {
                        return notOver8(Math.Sqrt(Convert.ToDouble(firstOperand)), maxOutputSize);
                    }
                case "1/x":
                    if (firstOperand != "0")
                    {
                        return notOver8(1 / Convert.ToDouble(firstOperand), maxOutputSize);
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
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {

                        return notOver8(Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand), maxOutputSize);
                    }
                    break;
                case "%":
                    //your code here
                    if (secondOperand == null)
                    {
                        return (Convert.ToDouble(firstOperand) / 100).ToString();
                    }
                    return ((Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)) / 100).ToString();

            }
            return "E";
        }
    }

}