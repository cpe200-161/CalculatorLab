﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//model
namespace CPE200Lab1
{
    public class BasicCalculatorEngine
    {


        /// <summary>
        /// return true if input is number 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }
        /// <summary>
        /// return true if input is operator
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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


        public string calculate(string operate, string firstOperand, string secondOperand,int maxOutputSize = 8)
        {
            string persentOperate = operate;
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
                        if (parts[0] == result.ToString())
                        {
                            return result.ToString();
                        }
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        else
                        {
                            remainLength = maxOutputSize - parts[0].Length - 1;
                            // trim the fractional part gracefully. =
                            return result.ToString("G" + remainLength);

                        }
                    }
                    break;
                case "%":
                    //your code here
                    switch (persentOperate)
                    {
                        case "+":
                            return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100).ToString();
                        case "-":

                            return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100).ToString();
                        case "X":

                            return (Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100).ToString();
                        case "/":

                            return (100 * Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)).ToString();
                    }
                    return (Convert.ToDouble(firstOperand) / 100).ToString();
            }
            return "E";
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
                        try
                        {
                            result = Math.Sqrt(Convert.ToDouble(operand));
                        }
                        catch (Exception ex)
                        {
                            return "E";
                        }
                        if (result.Equals(Math.Sqrt(-1)))
                        {
                            return "E";
                        }
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        if (parts[0] == result.ToString())
                        {
                            return result.ToString();
                        }
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
                case "1/x":
                    if (operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
                        // split between integer part and fractional part

                        parts = result.ToString().Split('.');
                        if (parts[0] == result.ToString())
                        {
                            return result.ToString();
                        }
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
                    break;
            }
            return "E";
        }
    }
}