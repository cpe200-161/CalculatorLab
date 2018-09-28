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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">this boolean check str is operator</param>
        /// <returns></returns>

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
        /// <summary>
        /// process to calculate 2 numbers which one is input
        /// </summary>
        /// <param name="str">str is string input to process</param>
        /// <returns></returns>

        public string calculate(string str)
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
        /// <summary>
        /// this is function to calculate 1/x and root
        /// </summary>
        /// <param name="operate">is string to save a operator</param>
        /// <param name="operand">is string of number to calculate</param>
        /// <param name="maxOutputSize">max number of return string</param>
        /// <returns></returns>

        public string calculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":

                    double result;
                    string[] parts;
                    int remainLength;

                    result = Math.Sqrt(Convert.ToDouble(operand));
                    // split between integer part and fractional part
                    parts = result.ToString().Split('.');
                    // if integer part length is already break max output, return error
                    if (parts[0].Length > maxOutputSize)
                    {
                        return "E";
                    }
                    // calculate remaining space for fractional part.
                    remainLength = maxOutputSize - parts[0].Length - 5;
                    // trim the fractional part gracefully. =
                    return result.ToString();
                    break;

                case "1/x":
                    if (operand != "0")
                    {

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
                        return result.ToString("G" + remainLength);

                    }
                    else
                    {
                        return "E";
                    }

                    /*catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }*/
                    break;
            }
            return "E";
        }
        /// <summary>
        /// this is function to calculate + - * / %
        /// </summary>
        /// <param name="operate">is string to save a operator</param>
        /// <param name="firstOperand">is first number</param>
        /// <param name="secondOperand">is second number</param>
        /// <param name="maxOutputSize">max number of return string</param>
        /// <returns></returns>

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
                        // split between integer part and fractional part
                        parts = (result).ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                    }
                    break;
                case "%":
                    return (double.Parse(secondOperand) * double.Parse(firstOperand) / 100).ToString();

            }
            return "E";
        }
    }
}