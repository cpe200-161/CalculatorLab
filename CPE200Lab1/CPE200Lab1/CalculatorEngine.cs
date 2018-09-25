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
                        double result;
                        //string[] parts;                        
                        try
                        {
                            if(Convert.ToDouble(operand) < 0){
                                throw new Exception();
                            }
                            result = Math.Sqrt(Convert.ToDouble(operand));
                            return result.ToString();
                        }
                        catch (Exception)
                        {
                            return "E";
                        }
                        // split between integer part and fractional part
                        //parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        //if (parts[0].Length > maxOutputSize)
                        //{
                        //    return "E";
                        //}
                        // calculate remaining space for fractional part.
                        //remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                    
                case "1/x":                                            
                        //string[] parts;                        
                        try
                        {
                            if (operand == "0")
                            {
                                throw new Exception();
                            }
                            result = (1.0 / Convert.ToDouble(operand));
                            return result.ToString();
                        }
                        catch (Exception)
                        {
                            return "E";
                        }

                        // split between integer part and fractional part
                        //parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        //if (parts[0].Length > maxOutputSize)
                        //{
                        //    return "E";
                        //}
                        // calculate remaining space for fractional part.
                        //remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =                       
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
                    // Not allow devide be zero                    
                    double result;
                    //string[] parts;
                    try
                    {
                        if (secondOperand == "0")
                        {
                            throw new Exception();
                        }
                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        return result.ToString();
                        // split between integer part and fractional part
                        //parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        //if (parts[0].Length > maxOutputSize)
                        //{
                        //    return "E";
                        //}
                        // calculate remaining space for fractional part.
                        //remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =                 
                    }
                    catch (Exception)
                    {
                        return "E";
                    }
                case "%":

                    if (secondOperand == null || secondOperand == "" && firstOperand != null && firstOperand != "")
                    {
                        return (Convert.ToDouble(firstOperand) / 100).ToString();
                    }
                    else if (secondOperand != null && secondOperand != "" && secondOperand != "0")
                    {
                        return ((Convert.ToDouble(secondOperand) / 100 * Convert.ToDouble(firstOperand)).ToString());
                    }
                    return "E";
            }
            return "E";
        }
    }
}
