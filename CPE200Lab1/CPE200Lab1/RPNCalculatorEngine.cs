using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : BasicCalculatorEngine
    {
        protected Stack<string> myStack;
        /// <summary>
        /// Get string to process 
        /// </summary>
        /// <param calculate ="str"></param>
        /// <returns>string</returns>
        public string calculate(string str)
        {
            // your code here
            
            string fristOperand;
            string secondOperand;
            string[] parts = str.Split(' ');
            
                 myStack = new Stack<string>();
                for (int i = 0; i < parts.Length; i++)
                {
                try
                {
                    if (isNumber(parts[i]))
                    {
                        myStack.Push(parts[i]);
                    }
                    if (isOperator(parts[i]))
                    {
                        if (parts[i] == "1/x" || parts[i] == "√")
                        {

                            secondOperand = myStack.Pop();
                            myStack.Push(caculate(parts[i], secondOperand));
                        }

                        else
                        {

                            secondOperand = myStack.Pop();
                            fristOperand = myStack.Pop();
                            myStack.Push(calculate(parts[i], fristOperand, secondOperand));



                        }

                    }
                }
                catch(Exception)
                {
                    return "E";
                }
                    
                }
                if (myStack.Count == 1)
                {
                    return myStack.Pop(); 
                }
                else
                {
                    return "E";
                }
                
            }
    }
}

