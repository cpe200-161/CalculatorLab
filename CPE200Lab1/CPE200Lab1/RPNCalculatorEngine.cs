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
            if (numbers.Length < 3 || isOperator(numbers[0]) || isOperator(numbers[1]))
            {
                return "E";
            }

            foreach (string number in numbers)
                {
                    if (isNumber(number))
                    {
                        numberStack.Push(number);
                    }
                    
                    if (isOperator(number))
                    {
                        try {
                        string secondNumber = numberStack.Pop();
                        string firstNumber = numberStack.Pop();
                        string answer = calculate(number, firstNumber, secondNumber);
                        numberStack.Push(answer);
                        }
                        catch (InvalidOperationException)
                        { 
                         return "E";
                        }
                    }
                    else if (isOperatorX(number) && numberStack.Count >= 1)
                    {
                        string UOperand = numberStack.Pop();
                        string answer = unaryCalculate(number, UOperand);
                        numberStack.Push(answer);

                    }

                

                }



            if (numberStack.Count == 1) return numberStack.Pop();
            else return "E";
            



        }
        

    }
}
