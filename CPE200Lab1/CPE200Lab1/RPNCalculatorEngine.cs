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
            string[] parts = str.Split(' ');
            Stack<string> Operands = new Stack<string>();
            foreach(string list in parts)
            {
                if (isNumber(list))
                {
                    Operands.Push(list);
                }
                else if (isOperator(list))
                {
                    if (Operands.Count < 2)
                    {
                        return "E";
                    }
                    string secondOperand = Operands.Pop();
                    string firstOperand = Operands.Pop();
                    string result = calculate(list, firstOperand, secondOperand);
                    Operands.Push(result);
                }
            }
            return Operands.Pop();
        }
    }
}
