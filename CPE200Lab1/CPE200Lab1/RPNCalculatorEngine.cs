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
            if(str[str.Length-1] == ' ') str = str.Substring(0,str.Length-1);
            Stack<string> number_stack = new Stack<string>();
            string[] numbers = str.Split(' ');
            int count_oper=0,count_num=0;
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
                else
                {
                    count_num += 1;
                    number_stack.Push(number);
                }
            }
            if (count_num == 1 || count_oper < count_num - 1)
            {
                return "E";
            }
            return number_stack.Pop();
        }
    }
}
