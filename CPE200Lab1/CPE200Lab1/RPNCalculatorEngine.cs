using System;
using System.Collections;
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
            Stack RPNcalc = new Stack();

            string first, second, result;
            string[] parts = str.Split(' ');
            parts = parts.Take(parts.Length - 1).ToArray();

            foreach (string element in parts)
            {

                    if (isNumber(element))
                    {
                        RPNcalc.Push(element);
                    }
                    else if (isOperator(element) && RPNcalc.Count >= 2)
                    {
                        second = RPNcalc.Pop().ToString();
                        first = RPNcalc.Pop().ToString();
                        result = calculate(element, first, second);
                        RPNcalc.Push(result);
                    }
                    else
                    {
                        return "E";
                    }
            }

            if (RPNcalc.Count == 1)
            {
                return RPNcalc.Pop().ToString();
            }
            else 
            {
                return "E";
            }

        }
    }
}
