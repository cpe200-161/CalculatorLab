using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        private bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        private bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }
        public string Process(string str)
        {
            Stack<string> RPNstack = new Stack<string>();
            string[] parts = str.Split(' ');
            string[] Number = { };
            if (!(isNumber(parts[0]) && isNumber(parts[1]) && isOperator(parts[2])))
            {
                return "E";
            }
            else
            {
                foreach(string element in parts)
                {
                    if (isNumber(element))
                    {
                        RPNstack.Push(element);
                    }
                    else
                    {
                        for(int i = 0; i < 2;i++)
                        {
                            Number[i] = RPNstack.Pop();
                        }
                        return calculate(element, Number[0], Number[1]);
                    }
                }
            }
            return "E";
        }
    }
}
