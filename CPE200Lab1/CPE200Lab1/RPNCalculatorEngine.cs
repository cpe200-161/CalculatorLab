using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine :CalculatorEngine 
    {
        public string Process(string str)
        {
            // your code here
            /// <summary>
            /// receive numbers split to firstOperand secondOperand  to calculate
            /// in RPN term
            /// </summary>
            /// <returns>
            /// return Answer
            /// </returns>
            Stack<string> strsum = new Stack<string>();
            string[] parts;
            parts = str.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i])) 
                {
                    strsum.Push(parts[i]);
                }
                else if (isOperator(parts[i])) 
                {
                    if(strsum.Count < 2) 
                    {
                        return "E";
                    }                    
                    else
                    {
                        string secondOperand = strsum.Pop();
                        string firstOperand = strsum.Pop();
                        strsum.Push(calculate(parts[i], firstOperand, secondOperand));
                    }                    
                }
            }
            if (strsum.Count == 1)
            {
                return strsum.Pop(); 
            }
            return "E";
        }
    }
}
