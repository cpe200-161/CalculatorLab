using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public override string Process(string str)
        {
            string[] parts = str.Split(' ');
            if (parts.Length == 1) return "E";
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
            if (operands.Count() != 0) return "E";

            return result;
        }
    }
}
