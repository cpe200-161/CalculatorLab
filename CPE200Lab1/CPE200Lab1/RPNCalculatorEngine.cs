using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RPNCalculatorEngine : CalculatorEngine 
    {
        public override string Process(string str)
        {
            string[] parts = str.Split(' ');
            Stack<string> operands = new Stack<string>();
            for (int i=0; i<parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    operands.Push(parts[i]);
                }else if (isOperator (parts [i]))
                {
                    if(operands.Count < 2)
                    {
                        return "E";
                    }
                    String op2 = operands.Pop();
                    String op1 = operands.Pop();
                    string result = calculate(parts[i], op1, op2, 4);
                    if(result is "E")
                    {
                        return result;
                    }
                    operands.Push(result);
                }
            }
            if(operands .Count > 1)
            {
                return "E";
            }
            return operands.Pop();
        }


        public override void handleSpace()
        {
                base.handleSpace();
                isNumberPart = false;
               
            
        }
    }
}
