using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        protected Stack<string> rpnStack = new Stack<string>();
        public new string calculate(string str)
        {
            rpnStack.Clear();
            List<string> parts;
            try
            {
                if (str == null) ;
                parts = str.Split(' ').ToList<string>();
            }
            catch(Exception)
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
                        try
                        {
                            secondOperand = rpnStack.Pop();
                            firstOperand = rpnStack.Pop();
                            result = calculate(token, firstOperand, secondOperand, 6);
                        }
                        catch(Exception)
                        {
                            result = "E";
                        }
                        if (result is "E")
                        {
                            return result;
                        }
                        rpnStack.Push(result);
                    }
                        else if(token == "")
                        {
                        }
                    else
                    {
                         return "E";
                    }
            } 
            if(rpnStack.Count == 1)
            {
                if ((Double.Parse(rpnStack.Peek())).ToString() != rpnStack.Peek())
                {
                    return "E";
                }
                result = rpnStack.Pop();
                return result;
            }else
            {
                return "E";
            }
        }
    }
}
