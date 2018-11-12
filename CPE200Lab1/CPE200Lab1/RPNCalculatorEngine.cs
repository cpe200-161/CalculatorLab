using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : NewCalculatorEngine
    {

       // private CalculatorEngine en = new CalculatorEngine();
        public new string calculate(string str)
        {
            
            Stack<string> rpnStack = new Stack<string>();

            List<string> parts;
            try
            {
                parts = str.Split(' ').ToList<string>();
                if (parts.Count <= 2 && str != "0")
                {
                    return "E";
                }
            }catch(NullReferenceException e)
            {
                Console.WriteLine("555");
                return "E";
            }
            
            string result;
            string firstOperand, secondOperand;

            foreach (string token in parts)
            {
                if (IsNumber(token))
                {
                    Console.WriteLine(token);
                    rpnStack.Push(token);
                }
                 else if (isOperator(token))
                {
                    Console.WriteLine("1");
                    //FIXME, what if there is only one left in stack?
                    try
                    {
                        Console.WriteLine(token);
                        if (rpnStack.Count() == 0)
                        {
                            Console.WriteLine("3");
                            return "E";
                        }
                        else
                        {
                            Console.WriteLine("4");
                            secondOperand = rpnStack.Pop();
                            firstOperand = rpnStack.Pop();
                        }                                               
                    }
                    catch(Exception e)
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
                else if (!isOperator(token) && token!="")
                {
                    return "E";
                }
            }


            //FIXME, what if there is more than one, or zero, items in the stack?

            try
            {
                result = rpnStack.Pop();
            }
            catch(Exception e)
            {
                return "E";
            }
            if (rpnStack.Count == 0)
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
