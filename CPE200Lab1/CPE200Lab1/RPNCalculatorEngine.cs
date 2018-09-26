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
           try 
            {       
                str = null;   //if str is null.
                str = "";     //if str is gap.    
            }

            catch(Exception e)
            {               
                return "E";  //if find in try return "E".
            }
            
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            string firstOperand, secondOperand;
            if (isOperator(parts[0])) return "E";
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
                    secondOperand = rpnStack.Pop();
                    firstOperand = rpnStack.Pop();
                    result = calculate(token, firstOperand, secondOperand);
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
                if (Convert.ToDecimal(rpnStack.Peek()).ToString() != rpnStack.Peek()) return "E";
                //FIXME, what if there is more than one, or zero, items in the stack?
                result = rpnStack.Pop();
                return Convert.ToDecimal(result).ToString("0.####"); //fix return
            }
            else return "E";
        }
    }
}
