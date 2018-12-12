﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : NewCalculatorEngine
    {
        public string calculate(string str)
        {
            if (str == "" || str == null)
            {
                return "E";
            }
        

            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            string firstOperand, secondOperand;

            if (str[0] == '+')
            {
                return "E";
            }

            if (isOperator(parts[0]))
            {
                return "E";
            }
            foreach (string token in parts)
            {


                if (isNumber(token))
                {
                    rpnStack.Push(token);
                }

                else if (isOperator(token))
                {
                    if (rpnStack.Count <= 1)
                    {
                        return "E";
                    }
                    //FIXME, what if there is only one left in stack?                   
                   
                    if (rpnStack.Count == 1)
                    {
                        return "E";
                    }
                    try
                    {
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                        result = calculate(token, firstOperand, secondOperand);
                    }
                    catch
                    {
                        return "E";
                    }
                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);

                }

                else if (token == "")
                {
                    continue;
                }
                else
                {
                    return "E";
                }
           

            }
            if (rpnStack.Count > 1)
            {
                return "E";
            }
            try
            {
                result = rpnStack.Pop();
            }
            catch
            {
                return "E";
            }
             return Convert.ToDouble(result).ToString("0.####");

           
        }
    }
}

