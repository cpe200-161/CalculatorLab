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
            if (str == "" || str == null)
            {
                return "E";
            }
            string first, second, four;
            Stack<string> rpn = new Stack<string>();

            string[] parts = str.Split(' ');
            if ((parts.Length == 1 || parts.Length == 2) && parts[0] != "0")
            {
                return "E";
            }
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    rpn.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    try
                    {
                        second = rpn.Pop();
                        first = rpn.Pop();
                        four = calculate(parts[i], first, second, 4);
                    }
                    catch (Exception)
                    {
                        return "E";
                    }
                    rpn.Push(four);
                }
                else if (parts[i] == "++")
                {
                    return "E";
                }
            }


            if (rpn.Count == 1)
            {
                four = rpn.Pop();
                return four;

            }
            else
            {
                return "E";
            }
        }
    }
}