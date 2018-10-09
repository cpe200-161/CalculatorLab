using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : TheCalculatorEngine
    {
        public string Process(string str)
        {
            if(str[str.Length-1] == ' ') str = str.Substring(0,str.Length-1);
            Stack<string> myStack = new Stack<string>();
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
                    string secondOperand = myStack.Pop();
                    string firstOperand = myStack.Pop();
                    string result = calculate(number, firstOperand, secondOperand);
                    myStack.Push(result);
                }
                else
                {
                    count_num += 1;
                    myStack.Push(number);
                }
            }
            if (count_num == 1 || count_oper < count_num - 1)
            {
                return "E";
            }
            return myStack.Pop();
        }
    }
}
