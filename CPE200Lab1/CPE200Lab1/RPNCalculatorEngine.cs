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
            string firstOperand;
            string secondOperand;
            string result;
            string[] parts = str.Split(' ');
            Stack<string> Operands = new Stack<string>();

            foreach (string list in parts)
            {
                if (isNumber(list))
                {
                    Operands.Push(list);
                }
                else if (isOperator(list))
                {
                    if (Operands.Count < 2 && list != "%" && list != "√" && list != "1/x")
                    {
                        return "E";
                    }
                    if (list == "+" || list == "-" || list == "X" || list == "÷")
                    {
                        secondOperand = Operands.Pop();
                        firstOperand = Operands.Pop();
                        result = calculate(list, firstOperand, secondOperand);
                        Operands.Push(result);
                    }
                    else if (list == "%")
                    {
                        try
                        {
                            secondOperand = Operands.Pop();
                            firstOperand = Operands.Peek();
                        }catch(Exception a)
                        {
                            secondOperand = Operands.Pop();
                            firstOperand = "1";
                        }

                        result = calculate(list, firstOperand, secondOperand);
                        Operands.Push(result);
                    }
                    else
                    {
                        secondOperand = Operands.Pop();
                        result = unaryCalculate(list, secondOperand);
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