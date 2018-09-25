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
            Stack<string> oper = new Stack<string>();
            for(int i=0;i<part.Length;i++)
            {
                if (isNumber(part[i]))
                {
                    oper.Push(part[i]);
                }
                if (isOperator(part[i]))
                {
                    string firstOperand;
                    string secondOperand;

                    try
                    {
                        secondOperand = oper.Pop();
                        firstOperand = oper.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {
                        return "E";
                    }
                    oper.Push(calculate(part[i], firstOperand, secondOperand, 4));
                }
            }
            if (oper.Count > 1) return "E";
            return oper.Pop();
        }
    }
}
