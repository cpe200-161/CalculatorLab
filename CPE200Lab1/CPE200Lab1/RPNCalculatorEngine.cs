using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : TheCalculatorEngine
    {
        protected Stack<string> mystack;
        public string calculate(string str)
        {
            mystack = new Stack<string>();
            string[] data = str.Split(' ');

            if (data.Length < 3 || data.Length % 2 == 0 || isOperator(data[0]) || isOperator(data[1]))
            {
                return "E";
            }
            else
            {
                foreach (string number in data)
                {
                    if (isNumber(number))
                    {
                        mystack.Push(number);
                    }
                    else if (isOperator(number) && mystack.Count > 1)
                    {                     
                            string secondOperand = mystack.Pop();
                            string firstOperand = mystack.Pop();
                            string result = calculate(number, firstOperand, secondOperand);
                            mystack.Push(result);
                    }
                    else if (isOperator1(number) && mystack.Count >= 1)
                    {
                            string Operand = mystack.Pop();
                            string result2 = calculate(number, Operand);
                            mystack.Push(result2);
                    }
                }
                if (mystack.Count == 1)
                {
                    return mystack.Peek();
                }
            }
            return "E";
        }
    }
}
