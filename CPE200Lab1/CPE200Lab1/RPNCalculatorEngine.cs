using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
/// <summary>
/// 
/// </summary>
namespace CPE200Lab1
{

    public class RPNCalculatorEngine: BasicCalculatorEngine
    {
        /// <summary>
        /// Calculate engine
        /// </summary>
        /// <param name="oper">input str is string</param>
        /// <returns></returns>
        public new string calculate(string oper)         
        {
            string[] parts;
            Stack myStack = new Stack();
            parts = oper.Split(' '); 
            for (int i = 0;i< parts.Length; i++){  
                if (isNumber(parts[i])) 
                {
                    myStack.Push(parts[i]); 
                    
                }
                else if(isOperator(parts[i]))
                {
                    try 
                    {
                         if (myStack.Count == 1) 
                        {
                            string firstOperand = myStack.Pop().ToString();
                            myStack.Push(calculate(parts[i], firstOperand, 4));

                        }
                        else if (parts[i] != "√" && parts[i] != "1/x" && parts[i] != "%") 
                        {
                            string firstOperand = myStack.Pop().ToString();
                            string secondOperand = myStack.Pop().ToString();
                            myStack.Push(calculate(parts[i], secondOperand, firstOperand, 4));
                        }
                        else if (parts[i] == "%") 
                        {
                            string firstOperand = myStack.Pop().ToString();
                            string secondOperand = myStack.Peek().ToString();
                            myStack.Push(calculate(parts[i], secondOperand, firstOperand, 4));
                        }
                    }
                    catch
                    {
                        return "E";
                    }
                 
                }
                
            }
            if (myStack.Count == 1)
            {
                return myStack.Pop().ToString();
            }
                
            
            return "E";
        }
        /// <summary>
        /// check is Operator
        /// </summary>
        /// <param name="str">input str is string</param>
        /// <returns></returns>
        private bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "√":
                case "1/x":
                case "%":

                    return true;
            }
            return false;
        }
    }
}

