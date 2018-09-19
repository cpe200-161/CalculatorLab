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
            string result;
            string firstOperand, secondOperand;

            try
            {
                if (str == null) ;
                parts = str.Split(' ').ToList<string>();
            }
            catch (Exception)
            {
                return "E";
            }

            if (parts.Count == 1&& parts[0]!="0")
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
                    //FIXME, what if there is only one left in stack?
                    try
                    {
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                        result = calculate(token, firstOperand, secondOperand, 6);
                        //rpnStack.Push(result);
                    }
                    catch (Exception)
                    {
                        result = "E";
                    }
                    if (result is "E")
                    {
                        return result;
                    }
                   rpnStack.Push(result);
                }else if(token == "")
                {
                
                }
                else
                {
                    return "E";
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            if (rpnStack.Count == 1) 
              {
                result = rpnStack.Pop();
             return result;
            }
            else
            {
                return "E";
                
            }
        }
    }
}
