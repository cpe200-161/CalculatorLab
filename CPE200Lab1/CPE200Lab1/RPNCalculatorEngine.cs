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
        /// Processing the RPN style calculation.
        /// </summary>
        /// <param name="str"> String of RPN style expression.</param>
        /// <returns> The string of result</returns>
        public string calculate(string str)
        {
            string firstOperand;
            string secondOperand;
            Stack<string> number = new Stack<string>();
            string[] parts = str.Split(' ');

            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    number.Push(parts[i]);
                }

                else if (isOperator(parts[i]))
                {
                    if(number.Count < 2)
                    {
                        return "E";
                    }
                    secondOperand = number.Pop();
                    firstOperand = number.Pop();
                    number.Push(calculate(parts[i], firstOperand, secondOperand));
                }

                else if (parts[i] == "%")
                {
                    try
                    {
                        secondOperand = number.Pop();
                        firstOperand = number.Pop();
                        number.Push(firstOperand);
                        number.Push(calculate(parts[i], firstOperand, secondOperand));
                    }
                    catch (Exception)
                    {
                        return "E";
                    }
                }

                else if (parts[i] == "1/x" || parts[i] == "√")
                {
                    firstOperand = number.Pop();
                    number.Push(calculate(parts[i], firstOperand));
                }
            }

            if (number.Count == 1)
            {
                return number.Pop();
            }
            return "E";
        }
    }
}
