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
                case "1/x":
                    return true;
            }
            return false;
        }

        public  string  Process(string str)
        {
            Stack<string> numbers = new Stack<string>();
            string[] parts = str.Split(' ');
            if (parts.Length == 1)
            {
                return "E";
            }
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    numbers.Push(parts[i]);
                }
                else if (OnlyOneOperand(parts[i]))
                {
                    string st;
                    st = numbers.Peek();
                    numbers.Pop();
                    numbers.Push(unaryCalculate(parts[i], st, 8));
                }
                else if (parts[i] == "%")
                {
                    string st, nd;
                    if (numbers.Count < 2)
                    {
                        return "E";
                    }
                    nd = numbers.Peek();
                    numbers.Pop();
                    st = numbers.Peek();
                    numbers.Pop();
                    numbers.Push(PercentResult(st, nd, 8));
                }
                else if (isOperator(parts[i]))
                {
                    if (numbers.Count < 2)
                    {
                        return "E";
                    }
                    string st, nd;
                    nd = numbers.Peek();
                    numbers.Pop();
                    st = numbers.Peek();
                    numbers.Pop();
                    numbers.Push(calculate(parts[i], st, nd, 8));
                }

            }
            if (numbers.Count == 1)
            {
                return numbers.Peek();
            }
            else
            {
                return "E";
            }
            // your code here
            /* string[] one_ope = str.Split(' ');
             if (one_ope.Length < 2) return "E";
             Stack<string> operand = new Stack<string>();
             int i = 0;
             while (i < one_ope.Length) {
                 if (isNumber(one_ope[i])) {
                     operand.Push(one_ope[i]);
                 }
                 if (isOperator(one_ope[i]))
                 {if (i == 0) return "E";
                     string firstoperand;
                     string secondoperand;
                     if (operand.Count >= 2)
                     {
                         secondoperand = operand.Pop();
                         firstoperand = operand.Pop();
                         operand.Push(calculate(one_ope[i], firstoperand, secondoperand));
                     }
                     else return "E";
                 }
                 i++;
             }
             if (operand.Count > 1)
                 return "E";
             return operand.Pop();*/
        }
    }
}