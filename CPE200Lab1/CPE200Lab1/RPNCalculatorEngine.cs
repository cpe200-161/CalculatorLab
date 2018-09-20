using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine:CalculatorEngine
    {
        public string Process(string str)
        {
            Stack mystack = new Stack();
            string first, second;
            string[] parts = str.Split(' ');
            Console.WriteLine(parts);

            for (int i = 0; i < parts.Length; i++)
            {
                if (isOperator(parts[i]))
                {
                    if (mystack.Count < 2) return "E";
                }

                if (isNumber(parts[i])) mystack.Push(parts[i]);
                else if (isOperator(parts[i]))
                {
                    first = (string)mystack.Pop();
                    second = (string)mystack.Pop();
                    mystack.Push(calculate(parts[i], second, first, 4));
                }
                else if (parts[i] == "√" || parts[i] == "1/x")
                {
                    first = (string)mystack.Pop();
                    mystack.Push(unaryCalculate(parts[i], first, 4));
                }
            }           
            if(mystack.Count==1) return (string)mystack.Pop();

            return "E";
        }
    }
}
