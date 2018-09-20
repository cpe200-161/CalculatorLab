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
            string firstnum;
            string secondnum;
            string[] parts = str.Split(' ');
            Stack<string> number = new Stack<string>();

            for (int i = 0; i < parts.Length; i++)
            {
                if (isOperator(parts[i]))
                {
                    if (number.Count < 2)
                    {
                        if (parts[i] == "1/x" || parts[i] == "√")
                        {
                            firstnum = number.Pop();
                            number.Push(unaryCalculate(parts[i], firstnum));
                        }
                        else return "E";
                    }
                    else if (parts[i] == "1/x" || parts[i] == "√")
                    {
                        firstnum = number.Pop();
                        number.Push(unaryCalculate(parts[i], firstnum));
                    }
                    else if (parts[i] == "%")
                    {
                        secondnum = number.Pop();
                        firstnum = number.Pop();
                        number.Push(firstnum);
                        number.Push(calculate(parts[i], firstnum, secondnum));
                    }
                    else
                    {
                        secondnum = number.Pop();
                        firstnum = number.Pop();
                        number.Push(calculate(parts[i], firstnum, secondnum));
                    }
                    
                }
                else if (isNumber(parts[i]))
                {
                    number.Push(parts[i]);
                }
            }
            if (number.Count == 1) return number.Pop();
            else return "E";
        }
    }
}
