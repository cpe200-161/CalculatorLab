using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        protected Stack<string> myStack;
        public string calculate(string str)
        {
            myStack = new Stack<string>();
            string[] part = str.Split(' ');
            string secondOperand;
            string firstOperand;
            string ansWer;
            foreach (string text in part)
            {
                if (isOperator(text))
                {
                    if (myStack.Count >= 2)
                    {
                        secondOperand = myStack.Pop();
                        firstOperand = myStack.Pop();
                        ansWer = calculate(text, firstOperand, secondOperand);
                        myStack.Push(ansWer);
                    }
                    else
                    {
                        return "E";
                    }
                }
                else if (isNumber(text))
                {

                    myStack.Push(text);

                }
                else if (text == "√" || text == "1/x")
                {
                    ansWer = calculate(text, myStack.Pop());
                    myStack.Push(ansWer);
                }
                else
                {
                    return "E";
                }
            }
            if (myStack.Count == 1)
            {
                return myStack.Peek();
            }
            else
            {
                return "E";
            }
        }
    }
}
