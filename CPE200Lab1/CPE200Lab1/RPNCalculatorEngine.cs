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
            //your code here
            Stack<string> number = new Stack<string>();
            string[] parts = str.Split(' ');
            for(int i=0; i<parts.Length; i++)
            {
                if (isNumber(parts[i]) == true)
                {
                    number.Push(parts[i]);
                }
                else if (isOperator(parts[i]) == true)
                {
                    if (number.Count < 2)
                    {
                        return "E";
                    }
                    else
                    {
                        string secondOperand = number.Pop();
                        string firstOperand = number.Pop();
                        string result = calculate(parts[i], firstOperand, secondOperand);
                        number.Push(result);
                    }
                }
            }
            if(number.Count == 1)
            {
                return number.Pop();
            }
            else
            {
                return "E";
            }
            
        }
    }
}
