using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CPE200Lab1
{
    public class RPNCalculatorEngine : BasicCalculatorEngine
    {
        /// <summary>
        /// Calculating using RPN calculator 
        /// </summary>
        /// <param name="str"> The string of RPN style calculation </param>
        /// <returns> Resulf of string </returns>

        public string calculate(string str)
        {
            Stack<string> numbers = new Stack<string>();
            string[] part = str.Split(' ');
            string secondOperand;
            string firstOperand;
            string ansWer;
            foreach (string text in part)
            {
                if (isOperator(text))
                {
                    if (numbers.Count >= 2)
                    {
                        secondOperand = numbers.Pop();
                        firstOperand = numbers.Pop();
                        ansWer = calculate(text, firstOperand, secondOperand);
                        numbers.Push(ansWer);
                    }
                    else
                    {
                        return "E";
                    }
                }
                else if (isNumber(text))
                {

                    numbers.Push(text);

                }
                else if (text == "√" || text == "1/x")
                {
                    ansWer = calculate(text, numbers.Pop());
                    numbers.Push(ansWer);
                }
                else
                {
                    return "E";
                }
            }
            if (numbers.Count == 1)
            {
                return numbers.Peek();
            }
            else
            {
                return "E";
            }
        }
    }
}