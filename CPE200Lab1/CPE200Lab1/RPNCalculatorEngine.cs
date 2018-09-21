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
            Stack<string> numberandoperands = new Stack<string>();
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    numberandoperands.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    if (numberandoperands.Count < 2)
                    {
                        return "E";
                    }
                    string operands2 = numberandoperands.Pop();
                    string operands1 = numberandoperands.Pop();
                    string result = calculate(parts[i], operands1, operands2, 4);
                    if (result is "E")
                    {
                        return result;
                    }
                    numberandoperands.Push(result);
                }
            }
            if (numberandoperands.Count > 1)
            {
                return "E";
            }
            return numberandoperands.Pop();
        }

        public override void handleSpace()
        {
            base.handleSpace();
            isNumberPart = false;
        }
    }
}