using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public bool isUnaryCalculate(string str)
        {
            switch(str)
            {
                case "√":
                case "1/x":
                    return true;
            }
            return false;
        }

        public string Process(string str)
        {
            // your code here
            string[] parts = str.Split(' ');
            Stack<string> Operands = new Stack<string>();
            for (int i = 0;i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    Operands.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    if (Operands.Count < 2)
                    {
                        return "E";
                    }
                    string secondOperand = Operands.Pop();
                    string firstOperand = Operands.Pop();
                    string result = calculate(parts[i], firstOperand, secondOperand);
                    Operands.Push(result);
                }
                else if (isUnaryCalculate(parts[i]))
                {
                    Operands.Push(unaryCalculate(parts[i], Operands.Pop()));
                }
                else if (parts[i] == "%")
                {
                    if (parts[i+1] == "+" || parts[i+1] == "-")
                    {
                        string secondOperand = Operands.Pop();
                        string firstOperand = Operands.Peek();
                        Operands.Push(calculate(parts[i], firstOperand, secondOperand));
                    }
                    else
                    {
                        Operands.Push(calculate(parts[i], Operands.Pop(), null));
                    }
                }
            }
            if (Operands.Count == 1)
            {
                return Operands.Pop();
            }
            return "E";
        }
    }
}
