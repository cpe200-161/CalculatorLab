using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : basicCalculatorEngine
    {
        // RPN Calculation
        public string calculate(string str)
        {
            string[] parts = str.Split(' ');
            Stack RPNCal = new Stack();
            for (int i = 0 ; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    RPNCal.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    if (RPNCal.Count < 2)
                    {
                        return "E";
                    }else
                    {
                        string firstOpt = RPNCal.Pop().ToString();
                        string secondOpt = RPNCal.Pop().ToString();
                        RPNCal.Push(calculate(parts[i], secondOpt, firstOpt, 4));
                    }
                }
            }
            if (RPNCal.Count == 1)
            {
                return RPNCal.Pop().ToString();
            }
            return "E";
        }
    }
}
