﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine 
    {
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        public bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "√":
                case "%":
                case "1/X":
                    return true;
            }
            return false;
        }

        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            if(!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            } else
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
                        return NotOver8(Math.Sqrt(Convert.ToDouble(operand)), maxOutputSize);
                    }
                case "1/X":
                    if(operand != "0")
                    {
                        return NotOver8((1.0 / Convert.ToDouble(operand)), maxOutputSize);
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
                    if (secondOperand != "0")
                    {
                        return NotOver8((Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)), maxOutputSize);
                    }
                    break;
                case "%":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)/100).ToString();
            }
            return "E";
        }

        private static string NotOver8(double result, int maxOutputSize)
        {
            string[] parts;
            int remainLength;
            // split between integer part and fractional part
            parts = result.ToString().Split('.');
            // if integer part length is already break max output, return error
            if (parts[0].Length > maxOutputSize)
            {
                return "E";
            }
            // calculate remaining space for fractional part
            if (parts.Length <= 1)
            {
                return result.ToString();
            }
            else if (parts[1].Length < maxOutputSize)
            {
                return result.ToString();
            } 
            //return result.ToString();
            remainLength = maxOutputSize - parts[0].Length - 1;
            // trim the fractional part gracefully. =
            return result.ToString("N" + remainLength);
        }
    }
}
