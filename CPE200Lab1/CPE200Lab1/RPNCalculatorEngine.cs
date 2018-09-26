using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string calculate(string str)
        {
            if (str == null)
            {
                return "E";
            }
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            string firstOperand, secondOperand;
            if (parts.Count() <= 2 && str != "0")
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
                    }
                    catch(InvalidOperationException e)
                    {
                        return "E";
                    }
                    result = calculate(token, firstOperand, secondOperand, 8);
                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);
                }
                else if (!isOperator(token) && token != "")
                {
                    return "E";
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            if (rpnStack.Count() != 1)
            {
                return "E";
            }

            result = rpnStack.Pop();
            return Convert.ToDecimal(result).ToString("0.####");
        }
    }
}
