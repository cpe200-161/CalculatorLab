using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    /// <summary>
    /// Provide method for calculate with RPN style.
    /// </summary>
    public class RPNCalculatorEngine : CalculatorEngine
    {
        /// <summary>
        /// Check that is unary operator.
        /// </summary>
        /// <param name="str">
        /// The string going to check.
        /// </param>
        /// <returns>
        /// Return true if string id unary operator, otherwise return false.
        /// </returns>
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

        /// <summary>
        /// Calculate with RPN style calculation.
        /// </summary>
        /// <param name="str">
        /// The string of RPN style.
        /// </param>
        /// <returns>
        /// The string of result.
        /// </returns>
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
                    try
                    {
                        string secondOperand = Operands.Pop();
                        string firstOperand = Operands.Pop();
                        string result = calculate(parts[i], firstOperand, secondOperand);
                        Operands.Push(result);
                    }
                    catch (Exception e)
                    {
                        return "E";
                    }
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
