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
            Stack<string> numbers = new Stack<string>();
            string[] part = str.Split(' ');
            string secondOperand;
            string firstOperand;
            int countbase = 0;
            foreach (string text in part)
            {
                if (isOperator(text) && numbers.Count != 0)
                {
                    string ansWer;
                    secondOperand = numbers.Pop();
                    if (numbers.Count != 0)
                    {
                        firstOperand = numbers.Pop();
                        ansWer = calculate(text, firstOperand, secondOperand);
                        numbers.Push(ansWer);
                    }
                    else
                    {
                        return "E";
                    }
                }
                else if (isNumber(text))
                {

                    numbers.Push(text);
                    countbase++;
                }
            }
            if (numbers.Count == 1 && countbase > 1)
            {
                return numbers.Peek();
            }
            else
            {
                return "E";
            }







        }
    }
}
