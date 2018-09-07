﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    //all calculation process belong here
    public class CalculatorEngine
    {
        double memoryNum;
        bool isMemorySet;

        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "*":
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
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    double num1 = Convert.ToDouble(firstOperand);
                    double num2 = Convert.ToDouble(secondOperand);
                    double percent = (num1 * num2) / 100;

                    return  percent.ToString();
                case "sqrt":
                    string resultText = Math.Sqrt(Convert.ToDouble(secondOperand)).ToString();
                    return resultText.Length > 8 ? resultText.Substring(0, 8) : resultText;
                case "1/x":
                    
                    if (secondOperand == "0")
                    {
                        return "E";
                    }
                    string text = (1 / Convert.ToDouble(secondOperand)).ToString();

                    return text.Length > 8 ? text.Substring(0, 8) : text;

            }
            return "E";
        }

        public string memoryCalculate(string operrand, string memoryOperator)
        {
            switch (memoryOperator)
            {
                case "MS":
                    memoryNum = Convert.ToDouble(operrand);
                    isMemorySet = true;
                    Console.WriteLine("memory number : " + memoryNum);
                    break;
                case "MC":
                    memoryNum = 0;
                    isMemorySet = false;
                    break;
                case "MR":
                    if (isMemorySet)
                    {
                        return memoryNum.ToString();   
                    }
                    break;
                case "M+":
                    if (isMemorySet)
                    {
                        memoryNum += Convert.ToDouble(operrand);
                    }
                    break;
                case "M-":
                    if (isMemorySet)
                    {
                        memoryNum -= Convert.ToDouble(operrand);
                    }
                    break;
            }

            return "";
        }

    }
}
