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
            // your code here
            string[] one_ope = str.Split(' ');
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
            
            
            return operand.Pop();
        }
    }
}
