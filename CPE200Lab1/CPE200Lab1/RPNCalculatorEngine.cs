using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine :CalculatorEngine
    {
        /// <summary>
        /// input equation for calculate
        /// </summary>
        /// <param name="str">equation for caculate </param>
        /// <returns>result of equation</returns>
        public string Process(string str)
        {
            string firstOperand;
            string secondOperand;
            string result;
            string[] parts = str.Split(' ');
            Stack<string> Operands = new Stack<string>();

            foreach(string list in parts)
            {
                if (isNumber(list))
                {
                    Operands.Push(list);
                }
                else if(isOperator(list))
                {
                    if (list == "+" || list == "-" || list == "X" || list == "÷")
                    {
                        try
                        {
                            secondOperand = Operands.Pop();
                            firstOperand = Operands.Pop();
                            result = calculate(list, firstOperand, secondOperand);
                            Operands.Push(result);
                        }catch(Exception e)
                        {
                            return "E";
                        }
                    }
                    else if(list == "%")
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
                        secondOperand = Operands.Pop();
                        result = unaryCalculate(list, secondOperand);
                        Operands.Push(result);
                    }
                    
                }
            }
            if (Operands.Count == 1 )
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
