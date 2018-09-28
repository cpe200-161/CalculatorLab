using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : BasicCalculatorEngine
    {
        protected Stack mystack;

        /// <summary>
        /// Use for Calculate with RPN Calculator style
        /// </summary>
        /// <param name="str">INPUT is String</param>
        /// <returns>OUTPUT is String</returns>
        public string calculate(string str)
        {
            try
            {
                mystack = new Stack();
                string[] parts;
                if (str.Last() != ' ')
                {
                    str += " ";
                }
                parts = str.Split(' ');
                for (int i = 0; i < parts.Length - 1; i++)
                {
                    if (isOperator(parts[i]) == false && isSingle_Operator(parts[i]) == false)
                    {
                        mystack.Push(parts[i]);
                    }
                    else if (isOperator(parts[i]) == true)
                    {
                        if (mystack.Count < 2)
                        {
                            return "E";
                        }
                        string firstOperand = "0";
                        if (parts[i] != "%")
                        {
                            firstOperand = mystack.Pop().ToString();
                        }
                        string secondOperand = mystack.Pop().ToString();
                        mystack.Push(calculate(parts[i], secondOperand, firstOperand, 4));
                    }
                    else if (isSingle_Operator(parts[i]) == true)
                    {
                        if (mystack.Count < 1)
                        {
                            return "E";
                        }
                        string firstOperand = mystack.Pop().ToString();
                        mystack.Push(Calculate(parts[i], firstOperand, 4));
                    }
                    Console.WriteLine(mystack.Count.ToString());
                }
                Console.WriteLine(mystack.Count.ToString());
                if (mystack.Count == 1)
                {
                    return mystack.Peek().ToString();
                }
                // your code here

                return "E";
            }
            catch (Exception er)
            {
                Console.WriteLine(er.ToString());
                return "E";
            }
        }

        /// <summary>
        /// Check is a Single_Operator
        /// </summary>
        /// <param name="str">INPUT is String</param>
        /// <returns>OUTPUT is String</returns>
        private bool isSingle_Operator(string str)
        {
            switch (str)
            {
                case "√":
                case "1/x":
                    return true;
            }
            return false;
        }
    }
}
