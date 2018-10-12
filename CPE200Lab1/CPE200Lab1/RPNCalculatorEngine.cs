using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : BasicCalculatorEngine
    {
        protected Stack<string> myStack;

        public string calculate(string oper)
        {
            double retNum;
            string firstOperand;
            string secondOperand;
            string[] parts = oper.Split(' ');
            myStack = new Stack<string>();

            if (parts[parts.Length - 1] == "√")
            {
                if (Double.TryParse(parts[parts.Length - 2], out retNum) == false || Convert.ToDouble(parts[parts.Length - 2]) < 0)
                {
                    return "E";
                }
                return calculate("√", parts[parts.Length - 2]);
            }

            if (parts[parts.Length - 1] == "1/x")
            {
                if (Double.TryParse(parts[parts.Length - 2], out retNum) == false)
                {
                    return "E";
                }
                return calculate("1/x", parts[parts.Length - 2]);
            }

            if (parts[parts.Length-1] == "%")
            {
                /*secondOperand = number.Pop();
                firstOperand = number.Pop();
                number.Push(firstOperand);
                number.Push(calculate(parts[i], firstOperand, secondOperand));*/
                try
                {
                    secondOperand = myStack.Pop();
                    firstOperand = myStack.Pop();
                    myStack.Push(firstOperand);
                    myStack.Push(calculate("%", firstOperand, secondOperand));
                }
                catch (InvalidOperationException e)
                {
                    System.Console.WriteLine("{0} exception caught", e);
                    return "E";
                }
            }

            if (Double.TryParse(parts[1], out retNum) == false)
            {
                string cal;

                if (parts.Length < 3)
                {
                    return "E";
                }

                for (int i = 0; i < parts.Length; i++)
                {
                    myStack.Push(parts[i]);
                    if (myStack.Count == 3)
                    {
                        firstOperand = myStack.Pop();
                        cal = myStack.Pop();
                        secondOperand = myStack.Pop();
                        myStack.Push(calculate(cal, firstOperand, secondOperand));
                    }
                }
                return myStack.Pop();
            }
            if(Double.TryParse(parts[1], out retNum) == true)
            {
                if (parts.Length < 3)
                {
                    return "E";
                }
                bool space = false;
                for (int i = 0; i < parts.Length; i++)
                {
                    
                    space = false;
                    if (parts[i] == "")
                    {
                        space = true;
                    }
                    else if(Double.TryParse(parts[i], out retNum))
                    {
                        myStack.Push(parts[i]);
                    }
                    else if(space == false)
                    {
                        secondOperand = myStack.Pop();
                        System.Console.WriteLine(secondOperand);
                        firstOperand = myStack.Pop();
                        System.Console.WriteLine(firstOperand);
                        myStack.Push(calculate(parts[i], firstOperand, secondOperand));
                    }
                }
                return myStack.Pop();
            }
            return "E";
        }
    }

}
