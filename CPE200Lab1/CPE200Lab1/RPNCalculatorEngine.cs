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
            Stack<string> stack = new Stack<string>();

            string []data = str.Split(' ');
            if ((data.Length>=3 && data.Length%2!=0 && !isOperator(data[0]) && !isOperator(data[1]))) //complete
            {
                foreach(string number in data)
                {
                    if(isNumber(number))
                    {
                        stack.Push(number);
                    }
                    if(isOperator(number))
                    {
                        string secondOperand = stack.Pop();
                        string firstOperand = stack.Pop();
                        string result = calculate(number, firstOperand, secondOperand,4);
                        stack.Push(result);
                    }
                }
                return stack.Pop();
            }
            return "E";
        }
    }
}
