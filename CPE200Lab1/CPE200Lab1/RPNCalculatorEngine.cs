using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public readonly object result;
        public override string Process(string str)
        {

            if (str == null || str == "")
            {
                return "E";
            }
            string[] parts = str.Split(' ');
            Stack<string> operands = new Stack<string>();
            for (int i = 0; i < parts.Length; i++)

                if (isNumber(parts[i]))
                {
                    operands.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    if (operands.Count < 2)
                    {
                        return "E";
                    }
                    String op2 = operands.Pop();
                    String op1 = operands.Pop();
                    string result = calculate(parts[i], op1, op2, 4);
                    if (result is "E")
                    {
                        return result;
                    }
                    operands.Push(result);
                }
                else
                {
                    string Errnum = parts[i];
                    for (int j = 0; j < Errnum.Length; j++)
                    {
                        if (isOperator(Errnum[j].ToString()) && Errnum[j] != '-')
                        {
                            return "E";
                        }
                    }
                }


            //FIXME, what if there is more than one, or zero, items in the stack?

            if (operands.Count != 1)
            {
                return "E";
            }

            else if (operands.Count == 1)
            {
                string number = operands.Pop();
                string numberReturn = number;
                for (int i = 0; i < number.Length; i++)
                {
                    if (isOperator(number[i].ToString()) && number[0] != '-')
                        return "E";
                }
                string[] checktxt = number.Split('.');
                string decimals;
                int decimalsint;
                if (checktxt.Length > 1 && isNumber(checktxt[1]) && checktxt[1].Length > 4)
                {
                    decimals = checktxt[1].Substring(0, 5);
                    if (Int32.Parse(decimals[4].ToString()) > 5)
                    {
                        decimalsint = Int32.Parse(checktxt[1].Substring(0, 4));
                        decimalsint++;
                        decimals = decimalsint.ToString();
                    }
                    else
                    {
                        decimals = checktxt[1].Substring(0, 4);
                    }
                    numberReturn = checktxt[0] + "." + decimals;
                }
                operands.Push(numberReturn);
            }
            return operands.Pop();
        }
    }
    /*public override void handleSpace()
    {
        base.handleSpace();
        isNumberPart = false;


    }*/
}
    


