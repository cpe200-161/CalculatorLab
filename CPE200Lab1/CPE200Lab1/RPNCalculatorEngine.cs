using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            Stack RPNCal = new Stack();
            for (int i = 0 ; i < parts.Length - 1 ; i++)
            {
                if (isNumber(parts[i]))
                {
                    RPNCal.Push(parts[i]);
                }else if (isOperator(parts[i]))
                {
                    if (RPNCal.Count < 2)
                    {
                        return "E";
                    }else if(RPNCal.Count >= 2)
                    {
                        string firstOperand = RPNCal.Pop().ToString();
                        string secondOperand = RPNCal.Pop().ToString();
                        RPNCal.Push(calculate(parts[i], firstOperand, secondOperand, 4));
                    }
                }
            }
            if (RPNCal.Count == 1)
            {
                return RPNCal.Peek().ToString();
            }
            return "E";
        }
    }
}
