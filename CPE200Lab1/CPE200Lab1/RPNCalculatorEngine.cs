
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string calculate(string str)
        {
            Stack<string> numbers = new Stack<string>();
            string[] parts = str.Split(' ');
            if (parts.Length == 1)
            {
                return "E";
            }
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    numbers.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    try
                    {
                        string firstnumber, secondnumber;
                        secondnumber = numbers.Peek();
                        numbers.Pop();
                        firstnumber = numbers.Peek();
                        numbers.Pop();
                        numbers.Push(calculate(parts[i], firstnumber, secondnumber, 8));
                    }catch(InvalidOperationException)
                        {
                            return "E";
                        }

                }
            }
            if (numbers.Count == 1)
            {
                try
                {
                if (parts[1] == "√" || parts[1] == "1/x")
                {
                    string firstnumber;
                    firstnumber = numbers.Peek();
                    numbers.Pop();
                    numbers.Push(calculate(parts[1], firstnumber));
                }
                return numbers.Peek();
                }catch(InvalidOperationException)
                {
                    return "E";
                }
            }
            else
            {
                return "E";
            }
        }
    }
}