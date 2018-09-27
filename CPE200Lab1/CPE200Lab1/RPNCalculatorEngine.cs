﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{

    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            //testing
            //str = "+1";
            if (str == null || str == "")
            {
                return "E";
            }
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            string firstOperand, secondOperand;
            //Console.WriteLine(Double.Parse(parts[0]));
            /*
            if (isOperator(parts[0]) && !isNumber(parts[0]))
            {
                return "E";
            }
            */
            foreach (string token in parts)
            {
                if (isNumber(token))
                {
                    rpnStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?
                    
                    //if (rpnStack.Count <= 1)
                    //{
                    //    return "E";
                    //}
                    try
                    {
                    secondOperand = rpnStack.Pop();
                    firstOperand = rpnStack.Pop();
                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                        return "E";
                    }


                    result = calculate(token, firstOperand, secondOperand, 8);
                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);
                }else if(token != "")
                {
                    return "E";
                }
                //Console.WriteLine(token);
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
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
