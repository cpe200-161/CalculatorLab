using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : BasicCalculatorEngine
    {
        /// <summary>
        /// All relate RPNCalculator code belong here
        /// </summary>
        /// <param name="oper"></param>
        /// <returns></returns>

        public string calculate(string oper)
        {
            string[] parts = oper.Split(' ');
            Stack myStack = new Stack();

            try
            {
                //check every string in parts
                foreach (string p in parts)
                {
                    if (isOperator(p))
                    {

                        if (p == "%")
                        {
                            String percentage = (String)myStack.Pop();
                            String takePeek = (String)myStack.Peek();
                            myStack.Push(calculate(p, takePeek, percentage));
                        }
                        else
                        {
                            String num2 = (String)myStack.Pop();
                            String num1 = (String)myStack.Pop();

                            myStack.Push(calculate(p, num1, num2));
                        }

                    }
                    else if (isNumber(p))
                    {
                        //if p is a number push it in stack
                        myStack.Push(p);
                    }
                    else if (isUnary(p))
                    {
                        //when doing unaryOperator stack must have at least 1 item
                        String num = (String)myStack.Pop();

                        myStack.Push(calculate(p, num));
                    }

                }

                if (myStack.Count == 1)
                {
                    return (String)myStack.Pop();
                }

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("No Item in Stack: " + e);
            }


            return "E";
        }
    }
}
