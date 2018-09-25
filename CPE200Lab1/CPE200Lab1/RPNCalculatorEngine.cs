using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        /// <summary>
        /// calculate postfix type 
        /// use stack push number then pop it when input is operator use 2 number and 1 operator 
        /// put it to function calculate in CalculateEngine class for solve a result then return it to output in Extendform
        /// </summary>
        /// <param name="str">str had input form lbldisplay.text then split it to parts </param>
        /// <returns>return answer of calculate but if wrong this function will return E then out put to user "ERROR"</returns>
        public string Process(string str)
        {
            // your code here
            Stack<string> number = new Stack<string>();

            string secondOperand = null;
            string firstOperand = null;
            string[] parts = str.Split(' ');

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "")
                {
                    continue;
                }
                
                if (isNumber(parts[i]))
                {
                    number.Push(parts[i]);
                }
                else if(isOperator(parts[i]))
                {
                    if (parts[i] == "1/x" || parts[i] == "√")
                    {
                        secondOperand = number.Pop();
                        number.Push(unaryCalculate(parts[i], secondOperand));
                        continue;
                    }
                    
                    if (parts[i] == "%")
                    {
                        try
                        {
                            secondOperand = number.Pop();
                            firstOperand = number.Peek();
                            number.Push(calculate(parts[i], firstOperand, secondOperand));
                        }
                        catch
                        {
                            number.Push(calculate(parts[i],"1", secondOperand));
                        }
                        
                        continue;
                    }
                    try
                    {
                        secondOperand = number.Pop();
                        firstOperand = number.Pop();
                        number.Push(calculate(parts[i], firstOperand, secondOperand));
                    }
                    catch(Exception e)
                    {
                        return "E";
                    }
                }
            }

            if (number.Count != 1)
            {
                return "E";
            }

            return number.Peek();
        }
    }
}
