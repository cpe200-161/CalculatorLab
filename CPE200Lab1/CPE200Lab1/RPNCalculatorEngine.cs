using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        protected override string Process(string str)
        {
            //if (isSpaceAllowed || str is null) return str;
            string[] parts = str.Split(' ');
            Stack<string> operands = new Stack<string>();
            string result;
            for (int i = 0; i < parts.Length; i++)
            {
                if (isOperator(parts[i]))
                {
                    string pop1;
                    string pop2;
                    if (operands.Count() > 1)
                    {
                        pop1 = operands.Pop();
                        pop2 = operands.Pop();
                    }
                    else
                    {
                        return "E";
                    }
                    result = calculate(parts[i], pop2, pop1);
                    operands.Push(result);
                }
                else if (isNumber(parts[i]))
                {
                    operands.Push(parts[i]);
                }
            }
            result = operands.Pop();
            if (operands.Count() != 0) return "E";//operands.Count().ToString();

            return result;
        }
    }
}
