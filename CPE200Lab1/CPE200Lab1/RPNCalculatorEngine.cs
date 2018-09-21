using System;
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
            string first = null;
            string second = null;
            string[] parts = str.Split(' ');
            Stack<string> cal = new Stack<string>();
            for(int i = 0; i < parts.Length; i++)
            {
                if(isOperator(parts[i]))
                {
                    if (cal.Count < 2)
                    {
                        if (parts[i] == "√" || parts[i] == "1/x")
                        {
                            first = cal.Pop();
                            cal.Push(unaryCalculate(parts[i], first));
                        }
                        else return "E";
                    }
                    else if (parts[i] == "%")
                    {
                        second = cal.Pop();
                        first = cal.Pop();
                        cal.Push(first);
                        cal.Push(calculate(parts[i], first, second));
                    }
                    else if (parts[i] == "√" || parts[i] == "1/x")
                    {
                        first = cal.Pop();
                        cal.Push(unaryCalculate(parts[i], first));
                    }
                    else
                    {
                        second = cal.Pop();
                        first = cal.Pop();
                        cal.Push(calculate(parts[i], first, second));
                    }
                }
                else if(isNumber(parts[i])) cal.Push(parts[i]);
            }
            if(cal.Count == 1) return cal.Pop();
            else return "E";
        }
    }
}
