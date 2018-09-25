using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        /// <summary>
        /// fuction check string str is it number?
        /// </summary>
        /// <param name="str"> input is any string this come from parts of lbldisplay</param>
        /// <returns> function will return true when str is number and return false when it don't </returns>
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        /// <summary>
        /// function check string str is operator(+ - * ÷)
        /// </summary>
        /// <param name="str">input is any parts splited from lbldisplay</param>
        /// <returns>return true when str is any operater and return false when it don't</returns>
        public bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "%":
                case "√":
                case "1/x":
                    return true;
            }
            return false;
        }

        /// <summary>
        /// string input in this function it will splited to any parts and it was check more time
        /// first check order is infix if not return E
        /// second check operator is unaryCalculate to send into unaryCalculator function of calculate percent
        /// if not any one send part into calculate function for solve result
        /// </summary>
        /// <param name="str"> input is string has number operator and space for split it</param>
        /// <returns>return E if order is not infix and return result of calculate when is infix type</returns>
        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            try
            {
                if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
                {
                    return "E";
                }
                else if (parts.Length > 3)
                {
                    if (parts[3] == "%")
                    {
                        parts[2] = calculate(parts[3], parts[0], parts[2]);
                    }
                    else
                    {
                        parts[2] = unaryCalculate(parts[3], parts[2]);
                    }
                }
            }
            catch (Exception e)
            {
                return "E";
            }
            return calculate(parts[1], parts[0], parts[2], 4);
        }

        /// <summary>
        /// calculate for operator has one number for solve
        /// first check operate case then solve it and check result if more maxOutputSize we will cut them
        /// </summary>
        /// <param name="operate">string of sign</param>
        /// <param name="operand">string of number</param>
        /// <param name="maxOutputSize"> int of max size in output display</param>
        /// <returns>return result of solve in some case</returns>
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
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
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        double resultZero = Convert.ToDouble(result.ToString("N" + remainLength));
                        return resultZero.ToString();
                    }
                case "1/x":
                    if (operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

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
                        double resultZero = Convert.ToDouble(result.ToString("N" + remainLength));
                        return resultZero.ToString();
                    }
                    break;
            }
            return "E";
        }

        /// <summary>
        /// solve follow operate input each case
        /// </summary>
        /// <param name="operate">string of sign math (+ - x ÷)</param>
        /// <param name="firstOperand">first number of calculation</param>
        /// <param name="secondOperand">second number of calculation</param>
        /// <param name="maxOutputSize">max value of output</param>
        /// <returns>result of solve or return E when out of switch case</returns>
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
                        parts = result.ToString().Split('.');

                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        double resultZero = Convert.ToDouble(result.ToString("N" + remainLength));
                        return resultZero.ToString();
                    }
                    break;
                case "%":
                    //your code here
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
            }
            return "E";
        }
    }
}
