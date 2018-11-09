using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : SimpleCalculatorEngine
    {
        public string calculate(string str)
        {
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts ;
            string result;
            string firstOperand, secondOperand;

            if(str == null || str == " ")
            {
                return "E";
            }
            else
            {
                parts = str.Split(' ').ToList<string>();
                if(parts.Count < 3 && str != "0")
                {
                    return "E";
                }
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
                    catch (Exception e)
                    {
                        return "E";
                    }

                    result = NewMethod(firstOperand, secondOperand, token);
                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);

                }
                else if (!isOperator(token) && token != "" )
                {
                    return "E";
                }
               // return decimal.Parse(result.ToString()).ToString("0.####");
            }
            
            //FIXME, what if there is more than one, or zero, items in the stack?
            if(rpnStack.Count != 1)
            {
                return "E";
            }
           try
            {
                result = rpnStack.Pop();

            }
            catch(Exception e)
            {
                return "E";
            }

            return decimal.Parse(result.ToString()).ToString("0.####");
        }

        private string NewMethod(string firstOperand, string secondOperand, string token)
        {
            return calculate(token, firstOperand, secondOperand, 4);
        }
    }
}
