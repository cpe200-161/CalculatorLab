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
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts;
            try
            {
                parts = str.Split(' ').ToList<string>();
                if(parts.Count<=2 && str != "0")
                {
                    return "E";
                }
            }
            catch(NullReferenceException e)
            {
                return "E";
            }
            
            string result;
            string firstOperand, secondOperand;

            foreach (string token in parts)
            {
                if (isNumber(token))
                {
                    rpnStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?
                    try
                    {
                        if(rpnStack.Count() == 0)
                        {
                            return "E";
                        }
                        else
                        {
                            secondOperand = rpnStack.Pop();
                            firstOperand = rpnStack.Pop();
                        }
                    }
                    catch(Exception E)
                    {
                        return "E";
                    }

                    result = calculate(token, firstOperand, secondOperand, 4);
                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);
                }
                else if(!isOperator(token) && token!="")
                {
                    return "E";
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            try
            {
                result = rpnStack.Pop();
            }
            catch(Exception E)
            {
                return "E";
            }
            if(rpnStack.Count == 0)
            {
                return Decimal.Parse(result).ToString("0.####");
            }
            else
            {
                return "E";
            }
         }
    }
}
