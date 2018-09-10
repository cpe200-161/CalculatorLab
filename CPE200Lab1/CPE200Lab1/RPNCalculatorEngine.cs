using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine :CalculatorEngine
    {
        public string Process(string str)
        {
            string firstOperand;
            string secondOperand;
            string result;
            string[] parts = str.Split(' ');
            Stack<string> Operands = new Stack<string>();

            foreach(string list in parts)
            {
                if (isNumber(list))
                {
                    Operands.Push(list);
                }
                else if(isOperator(list))
                {
                    if (Operands.Count < 2)
                    {
                        return "E";
                    }
                    secondOperand = Operands.Pop();
                    firstOperand = Operands.Pop();
                    result = calculate(list, firstOperand, secondOperand);
                    Operands.Push(result);
                }
            }
            if (Operands.Count == 1 && parts.Length>1)
            {
                return Operands.Peek();
            }
            else
            {
                return "E";
            }
            
        }
    }
}
