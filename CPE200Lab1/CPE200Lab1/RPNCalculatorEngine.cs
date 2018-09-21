using System;
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
            if (str is null)
            {
                return "E";
            }

            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            string firstOperand, secondOperand;

            foreach (string token in parts)
            {
                if (isNumber(token))
                {
                    //if (token.Contains("+-X÷") && token.Contains("1234567890"))
                    //{
                    //    return "E";
                    //}
                    //else
                    rpnStack.Push(token);
                    
                }
                else if (isOperator(token))
                {
                    if (rpnStack.Count() <= 1)
                    {
                        return "E";
                    }
                    else
                    //FIXME, what if there is only one left in stack?
                    {
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                        result = calculate(token, firstOperand, secondOperand, 8);
                        if (result is "E")
                        {
                            return result;
                        }
                        rpnStack.Push(result);
                    }
                }
                else if (token != "")
                {
                    return "E";
                }
            }
            if (rpnStack.Count > 1 || rpnStack.Count == 0)
            {
                return "E";
            }
            else
            {
                if(Convert.ToDecimal(rpnStack.Peek()).ToString() != rpnStack.Peek())
                {
                    return "E";
                }
                result = rpnStack.Pop();
                return Convert.ToDecimal(result).ToString("0.####");
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
        }
    }
}
