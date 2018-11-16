using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine :BasicCalculatorEngine
    {
        /// <summary>
        /// Calculate with RPN Calculator.
        /// </summary>
        /// <param name="str">str is string of input.</param>
        /// <returns>The result from calculate.</returns>
        public string Process(string str)
        {
            // your code here
            string Num1;
            string Num2;
            string[] space = str.Split(' ');
            Stack<string> number = new Stack<string>();

            for(int i = 0; i < space.Length; i++)
            {
                if (isOperator(space[i]))
                {
                    if (number.Count < 2)
                    {
                        if (space[i] == "1/x" || space[i] == "√")
                        {
                            Num1 = number.Pop();
                            number.Push(calculate(space[i], Num1));
                        }
                        else return "E";
                    }
                    else if(space[i] == "1/x" || space[i] == "√")
                    {
                        Num1 = number.Pop();
                        number.Push(calculate(space[i], Num1));
                    }
                    else if(space[i] == "%")
                    {
                        Num2 = number.Pop();
                        Num1 = number.Pop();
                        number.Push(Num1);
                        number.Push(calculate(space[i], Num1, Num2));
                    }
                    else
                    {
                        Num2 = number.Pop();
                        Num1 = number.Pop();
                        number.Push(calculate(space[i], Num1, Num2));
                    }
                }
                else if(isNumber(space[i]))
                {
                    number.Push(space[i]);
                }
            }
            if (number.Count == 1) return number.Pop();
            else return "E";
        }
    }
}
