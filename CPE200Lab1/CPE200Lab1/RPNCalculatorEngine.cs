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
            Stack<string> number_stack = new Stack<string>();
            string[] numbers = str.Split(' ');
            int count_oper = 0, count_num = 0;
            foreach (string number in numbers)
            {
                if (isOperator(number))
                {
                    count_oper += 1;
                    if (count_num <= count_oper || count_num == 1)
                    {
                        return "E";
                    }
                    string secondOperand = number_stack.Pop();
                    string firstOperand = number_stack.Pop();
                    string result = calculate(number, firstOperand, secondOperand);
                    number_stack.Push(result);
               }
               else if (number == "√" || number == "1/x")
                {
                    count_oper += 1;
                    string Operand = number_stack.Pop();
                    string result = unaryCalculate(number, Operand);
                    number_stack.Push(result);
                }
                else
                {
                    count_num += 1;
                    number_stack.Push(number);
                }
            }
           if((count_num == 1 || count_oper > count_num - 1)&&count_oper == 0)
            {
                return number_stack.Count.ToString();
            }
            return number_stack.Pop();
        }
    }
}
