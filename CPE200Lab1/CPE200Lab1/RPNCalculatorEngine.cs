using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{

    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            if (str == "1") return "E";
            Stack<string>rpnStack = new Stack<string>(); ;
            List<string> parts;
            try
            {
                parts = str.Split(' ').ToList<string>();
            }
            catch (NullReferenceException)
            {
                return "E";
            }
            string result;
            string firstOperand, secondOperand;

            foreach (string token in parts)
            {
                if (isNumber(token) && token[0] != '+')
                {
                    rpnStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?
                    try
                    {
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                        result = calculate(token, firstOperand, secondOperand, 4);
                        if (result is "E")
                        {
                            return result;
                        }
                        rpnStack.Push(result);
                    }
                    catch (InvalidOperationException)
                    {
                        return "E";
                    }
                }
                else if(token != "")
                {
                    return "E";
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            if (rpnStack.Count() != 1) return "E";
            result = rpnStack.Pop();
            return result;
        }
    }
    /*
    public class RPNCalculatorEngine
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
    */
}
