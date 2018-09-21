using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            string firstOperand;
            string secondOperand;
            string[] parts = str.Split(' ');
            Stack<string> number = new Stack<string>();

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
                    if(parts[i+1] == "+" || parts[i+1] == "-")
                    {
                        secondOperand = number.Peek();
                        firstOperand = number.Pop();
                        number.Push(calculate(parts[i], firstOperand, secondOperand));
                    }
                    else
                    {
                        firstOperand = number.Pop();
                        number.Push(calculate(parts[i], firstOperand, null));
                    }
                }

                else if (parts[i] == "1/x" || parts[i] == "√")
                {
                    firstOperand = number.Pop();
                    number.Push(unaryCalculate(parts[i], firstOperand));
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
