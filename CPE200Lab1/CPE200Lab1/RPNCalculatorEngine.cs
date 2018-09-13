using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            // your code here
            Stack<string> number = new Stack<string>();

            string secondOperand = null;
            string firstOperand = null;
            string answer = null;
            string[] parts = str.Split(' ');

            if (!(isNumber(parts[0]) && isNumber(parts[1])))
            {
                return "E";
            }

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
                    if (number.Count < 2)
                    {
                        return "E";
                    }
                    if (parts[i] == "1/x" || parts[i] == "√")
                    {
                        secondOperand = number.Pop();
                        number.Push(unaryCalculate(parts[i], secondOperand));
                        continue;
                    }
                    if (parts[i] == "%")
                    {
                        secondOperand = number.Pop();
                        firstOperand = number.Peek();
                        number.Push(calculate(parts[i], firstOperand, secondOperand));
                        continue;
                    }
                        secondOperand = number.Pop();
                        firstOperand = number.Pop();
                        answer = calculate(parts[i], firstOperand, secondOperand);
                        number.Push(answer);
                    
                }
                else
                {
                    return "E";
                }
            }

            if (number.Count != 1)
            {
                return "E";
            }

            return answer;
        }
    }
}
