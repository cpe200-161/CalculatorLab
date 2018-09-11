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
            Stack<string> Numbers = new Stack<string>();
            string[] part = str.Split(' ');
            foreach (string text in part)
            {
                if (isNumber(text))
                {
                    Numbers.Push(text);
                }
                else if(isOperator(text))
                {
                    if (Numbers.Count >= 2 && text == "+" || text == "-" || text == "X" || text == "÷" || text == "%")
                    {
                        string secondOperand = Numbers.Pop();
                        string firstOperand = Numbers.Pop();
                        Numbers.Push(calculate(text, firstOperand, secondOperand));
                    }
                    else if (Numbers.Count >= 1 && text == "√" || text == "1/x")
                    {
                        string operand = Numbers.Pop();
                        Numbers.Push(unaryCalculate(text, operand));
                    }
                    else
                    {
                        return "E";
                    }
                }
            }
            if (Numbers.Count != 1)
            {
                return "E";
            }
            else
            {
                return Numbers.Peek();
            }
            
        }
    }
}
