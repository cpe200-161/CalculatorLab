using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        Stack<string> Operands = new Stack<string>();
        /// <summary>
        /// input equation for calculate
        /// </summary>
        /// <param name="oper">equation for caculate </param>
        /// <returns>result of equation</returns>
        public string calculate(string oper)
        {
            string[] parts = oper.Split(' ');
            foreach (string list in parts)
            {
                if (isNumber(list))
                {
                    Operands.Push(list);
                    Console.Write(list);
                }
                else if (isOperator(list))
                {
                    string firstOperand;
                    string secondOperand;
                    string result;
                    if (list == "+" || list == "-" || list == "X" || list == "÷")
                    {
                        try
                        {
                            secondOperand = Operands.Pop();
                            firstOperand = Operands.Pop();
                            result = calculate(list, firstOperand, secondOperand);
                            Operands.Push(result);
                        }
                        catch (Exception e)
                        {
                            return "E";
                        }
                    }
                    else if (list == "%")
                    {
                        if (Operands.Count == 1)
                        {
                            secondOperand = Operands.Pop();
                            firstOperand = "1";
                        }
                        else
                        {
                            secondOperand = Operands.Pop();
                            firstOperand = Operands.Peek();
                        }
                        result = calculate(list, firstOperand, secondOperand);
                        Operands.Push(result);
                    }
                    else
                    {
                        return "E";
                        secondOperand = Operands.Pop();
                        result = calculate(list, secondOperand);
                        Operands.Push(result);
                    }

                }
            }
            if (Operands.Count == 1)
            {
                return Operands.Peek();
            }
            else
            {
                return "E";
            }

        }

    }
}