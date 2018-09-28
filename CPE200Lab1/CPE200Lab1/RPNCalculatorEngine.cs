using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public readonly object result;
        public override string Process(string str)
        {

            if (str == null || str == "")
            {
                return "E";
            }
            string[] parts = str.Split(' ');
            Stack<string> operands = new Stack<string>();
            if (!isOperator(parts[3])
            {

            }
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    operands.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    if (operands.Count < 2)
                    {
                        return "E";
                    }
                    String op2 = operands.Pop();
                    String op1 = operands.Pop();
                    string result = calculate(parts[i], op1, op2, 4);
                    if (result is "E")
                    {
                        return result;
                    }
                    operands.Push(result);
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            if (operands.Count > 1)
            {
                return "E";
            }
            try
            {
                return operands.Pop();
            }
            catch
            {
                return "E";
            }
             return Convert.ToDouble(result).ToString("0.####");
            }
           

        /*public override void handleSpace()
        {
            base.handleSpace();
            isNumberPart = false;


        }*/
    }
    
}

