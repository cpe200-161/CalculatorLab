using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : TheCalculatorEngine
    {

        protected Stack<string> myStack;

        public override string calculate(string str)
        {
             myStack = new Stack<string>();
            
            
            string[] numbers = str.Split(' ');
            if (numbers.Length < 3 || isOperator(numbers[0]) || isOperator(numbers[1]))
            {
                return "E";
            }

            foreach (string number in numbers)
                {
                    if (isNumber(number))
                    {
                        myStack.Push(number);
                    }
                    
                    if (isOperator(number))
                    {
                        if (myStack.Count > 1)
                        {
                        string secondNumber = myStack.Pop();
                        string firstNumber = myStack.Pop();
                        string answer = calculate(number, firstNumber, secondNumber);
                        myStack.Push(answer);
                        }
                        else return "E";
                    }
                    else if (isOperatorX(number) && myStack.Count >= 1)
                    {
                        string UOperand = myStack.Pop();
                        string answer = calculate(number, UOperand);
                        myStack.Push(answer);

                    }

                

                }
            
            if (myStack.Count == 1) return myStack.Pop();
            else return "E";



        }
        

    }
}
