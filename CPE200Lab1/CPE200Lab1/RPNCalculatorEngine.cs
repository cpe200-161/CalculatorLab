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
                case "%":
                case "√":
                case "1/X":
                    return true;
            }
            return false;
        }

        public string Process(string str)
        {
            string firstOperand;
            string secondOperand;
            string[] parts = str.Split(' ');
            Stack<string> number = new Stack<string>();
            if(parts.Length < 3)
            {
                return "E";
            }
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    number.Push(parts[i]);
                }

                else if (isOperator(parts[i]))
                {
                    if (number.Count < 2)
                    {
                        return "E";
                    }
                    secondOperand = number.Pop();
                    firstOperand = number.Pop();
                    number.Push(calculate(parts[i], firstOperand, secondOperand));
                }

                else if (parts[i] == "%")
                {
                    secondOperand = number.Pop();
                    firstOperand = number.Pop();
                    number.Push(firstOperand);
                    number.Push(calculate(parts[i], firstOperand, secondOperand));
                }

                else if (parts[i] == "1/x" || parts[i] == "√")
                {
                    firstOperand = number.Pop();
                    number.Push(unaryCalculate(parts[i], firstOperand));
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
