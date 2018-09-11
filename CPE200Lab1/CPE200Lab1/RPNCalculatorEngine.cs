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
            Stack<string> stack = new Stack<string>();
            string[] data = str.Split(' ');

            foreach (string number in data)
            {
                if (isNumber(number))
                {
                    stack.Push(number);
                }
                else if (isOperator(number) && stack.Count > 1) //
                {
                    string secondOperand = stack.Pop();
                    string firstOperand = stack.Pop();
                    string result = calculate(number, firstOperand, secondOperand);
                    stack.Push(result);
                }
                else if (isOperator1(number) && stack.Count >= 1)
                {
                    string Operand = stack.Pop();
                    string result2 = unaryCalculate(number, Operand);
                    stack.Push(result2);
                }
                else if (stack.Count == 1)
                {
                    return stack.Peek();
                }      
            }
            return "E";
        }
    }
}
