﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{

    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            if (str == "" || str == null)
            {
                return "E";
            }


            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            string firstOperand, secondOperand;
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
                    secondOperand = rpnStack.Pop();
                    firstOperand = rpnStack.Pop();
                    result = calculate(token, firstOperand, secondOperand, 6);
                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);

                }
                else if (token != "")
                {
                    return "E";
                }

            }
            if (rpnStack.Count == 1)
            {
                if (Convert.ToDecimal(rpnStack.Peek()).ToString() != rpnStack.Peek())
                {
                    return "E";
                }
                result = rpnStack.Pop();
                return Convert.ToDecimal(result).ToString("0.####");

            }
            else
            {
                return "E";
            }
        }
    }
    /*
    public class RPNCalculatorEngine
    {
        public string Process(string str)
        {
            // your code here
            return "E";
        }
    }
    */
}

