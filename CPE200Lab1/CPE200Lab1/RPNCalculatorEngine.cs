using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        private bool isNotOrdinary(string str)
        {
            switch (str)
            {
                case "√":
                case "1/x":
                    return true;
            }
            return false;
        } 

        public new string Process(string str)
        {
            Stack<string> number = new Stack<string>();
            string[] parts = str.Split(' ');

            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    number.Push(parts[i]);
                }

                else if (isOperator(parts[i]))
                {
                    if(number.Count < 2)
                    {
                        return "E";
                    }
                    string secondOperand = number.Pop();
                    number.Push(calculate(parts[i], number.Pop(), secondOperand));
                }

                else if (parts[i] == "%")
                {
                    if(parts[i+1] == "+" || parts[i+1] == "-")
                    {
                        number.Push(calculate(parts[i], number.Pop(), number.Peek()));
                    }
                    else
                    {
                        number.Push(calculate(parts[i], number.Pop(), null));
                    }
                }

                else if (isNotOrdinary(parts[i]))
                {
                    number.Push(unaryCalculate(parts[i], number.Pop()));
                }
            }

            if (number.Count == 1)
            {
                return number.Pop();
            }

            return "E";
        }
    }
}
