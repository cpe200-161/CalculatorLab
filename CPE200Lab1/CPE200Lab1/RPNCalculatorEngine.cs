using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        
       
        public override string Process(string str)
        {
            Stack<string> numberStack = new Stack<string>();
            
            
            string[] numbers = str.Split(' ');
           
                foreach (string number in numbers)
                {
                    if (isNumber(number))
                    {
                        numberStack.Push(number);
                    }
                    else
                    if (isOperator(number) && numberStack.Count > 1)
                    {
                        string secondNumber = numberStack.Pop();
                        string firstNumber  = numberStack.Pop();
                        string answer = calculate(number, firstNumber, secondNumber);
                        numberStack.Push(answer);
                    }
                    else if(isOperatorX(number) && numberStack.Count>=1)
                    {
                        string UOperand = numberStack.Pop();
                        string answer = unaryCalculate(number, UOperand);
                        numberStack.Push(answer);

                    }
                    else if (numberStack.Count == 1) return numberStack.Pop();


                }
               
           return "E";


        }
        

    }
}
