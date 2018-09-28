using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str, bool useRPN)
        {
            System.Console.WriteLine("In process RPN");
            // your code here
            string firstOperand, secondOperand;
            bool isCal = false;
            string[] parts = str.Split(' ');
            System.Console.WriteLine("parts.length is " + parts.Length);
            Stack stack = new Stack();
            for(int i = 0; i < parts.Length-1; i++)
            {
                if(parts[i] == "+" || parts[i] == "-" || parts[i] == "X" || parts[i] == "÷")
                {
                    //if(stack.Count >= 2)
                    //{
                    //    secondOperand = stack.Pop().ToString();
                    //    firstOperand = stack.Pop().ToString();
                    //    stack.Push(calculate(parts[i], firstOperand, secondOperand, 4));
                    //    isCal = true;
                    //}
                    //else
                    //{
                    //    return "E";
                    //}

                    try
                    {
                        secondOperand = stack.Pop().ToString();
                        firstOperand = stack.Pop().ToString();
                        stack.Push(calculate(parts[i], firstOperand, secondOperand, 4));
                        isCal = true;
                    }
                    catch(InvalidOperationException e)
                    {
                        Console.WriteLine("{0} exception caught.", e);
                        return "E";
                    }

                }
                else
                {
                    stack.Push(parts[i]);
                }
            }
            //if (stack.Count != 1 || isCal == false)
            //{
            //    return "E";
            //}
            //else
            //{
            //    return stack.Pop().ToString();
            //}

            try
            {
                return stack.Pop().ToString();
            }

            catch (InvalidOperationException e)
            {
                System.Console.WriteLine("Exception caught." + e.Message);
                Console.WriteLine("{0} exception caught.", e);
                return "E";
            }
        }


    }
}
