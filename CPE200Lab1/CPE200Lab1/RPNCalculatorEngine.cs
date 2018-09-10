using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine :CalculatorEngine
    {
        public string Process(string str)
        {
            // your code here
            Stack<string> Stacknumber = new Stack<string>();
            string[] parts = str.Split(' ');
            string first, second;

            foreach (string number in parts)
            {
                if (isOperator(number))
                {
                    if (Stacknumber.Count < 2)
                    {
                        return "E";
                    }
                    first = Stacknumber.Pop();
                    second = Stacknumber.Pop();
                    Stacknumber.Push(calculate(number, second, first));

                }
                else if (isNumber(number))
                {
                    Stacknumber.Push(number);
                }
                else if (number== "1/x")
                {
                    first = Stacknumber.Pop();
                    Stacknumber.Push(unaryCalculate(number, first));
                }
                else if (number == "%")
                {
                    first = Stacknumber.Pop();
                    second = Stacknumber.Pop();
                    Stacknumber.Push(calculate(number, first, second));
                }
                else if (number == "√")
                {
                    first = Stacknumber.Pop();
                    Stacknumber.Push(unaryCalculate(number, first));
                }
            }

            if (Stacknumber.Count > 1)
            {
                return "E";
            }

            return Stacknumber.Pop();
        }
    }
}