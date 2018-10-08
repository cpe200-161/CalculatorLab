using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine :TheCalculatoeEngine
    {
        Stack<string> Operands = new Stack<string>();

        public string caculate(string oper)
        {
            string firstOperand;
            string secondOperand;
            string result;
            string[] parts = oper.Split(' ');
            foreach(string list in parts)
            {
                if (isNumber(list))
                {
                    Operands.Push(list);
                }
                else if(isOperator(list))
                {
                    if (Operands.Count < 2 && list!="%" && list!= "√" && list != "1/X")
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
                        result = calculate(list, secondOperand);
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
