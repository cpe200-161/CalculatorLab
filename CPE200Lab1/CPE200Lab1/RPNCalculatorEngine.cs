using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : BasicCalculatorEngine
    {
        /// <summary>
        /// Process to Calculate regular operator and unary operator using Reverse Polish notation.
        /// </summary>
        /// <param name="str"> String from display </param>
        /// <returns> Element in stack if only one element left in stack; Otherwise, return "E"; </returns>
 
        public string calculate(string str)
        {
            Stack myStack = new Stack();

            string first, second, result;
            string[] parts = str.Split(' ');           

            List<string> partsWithoutSpace = parts.ToList();
            partsWithoutSpace.RemoveAll(p => string.IsNullOrEmpty(p));
            parts = partsWithoutSpace.ToArray();


                foreach (string element in parts)
                {
                    if (isNumber(element))
                    {
                        myStack.Push(element);
                    }
                    else if (isUnaryOperator(element) || isOperator(element))
                    {
                    try
                    {
                        if (element == "%")
                        {
                            second = myStack.Pop().ToString();
                            first = myStack.Peek().ToString();
                            result = calculate(element, first, second);
                            myStack.Push(result);
                        }
                        else if (element == "√" || element == "1/x")
                        {
                            second = myStack.Pop().ToString();
                            result = calculate(element, second);
                            myStack.Push(result);
                        }
                        else
                        {
                            second = myStack.Pop().ToString();
                            first = myStack.Pop().ToString();
                            result = calculate(element, first, second);
                            myStack.Push(result);
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("An error occurred : " + ex.ToString());
                        return "E";
                    }
                    }                 
                }
            if (myStack.Count == 1)
            {
                return myStack.Pop().ToString();
            }
            else
            {
                return "E";
            }

        }
    }
}
