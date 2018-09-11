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
            string[] part = str.Split(' ');
            if (part.Length < 2) return "E";
            Stack<string> oper = new Stack<string>();
            for(int i=0;i<part.Length;i++)
            {
                if (isNumber(part[i]))
                {
                    oper.Push(part[i]);
                }
                if (isOperator(part[i]))
                {
                    if (i == 0) return "E";
                    string firstOperand;
                    string secondOperand;
                    if (oper.Count >= 2)
                    {
                        secondOperand = oper.Pop();
                        firstOperand = oper.Pop();
                        oper.Push(calculate(part[i], firstOperand, secondOperand, 4));
                    }
                    else return "E";
                }
            }
            if (oper.Count > 1) return "E";
            return oper.Pop();
        }
    }
}
