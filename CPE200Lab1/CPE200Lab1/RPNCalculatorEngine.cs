using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            Stack<string> numbers = new Stack<string>();
            string[] part = str.Split(' ');
            foreach(string text in part)
            {
                if (isOperator(text))
                {
                    string ansWer;
                    string secondOperand = numbers.Pop();
                    string firstOperand = numbers.Pop();
                    ansWer = calculate(text, firstOperand, secondOperand);
                    numbers.Push(ansWer);


                }
                else if(isNumber(text))
                {
                    numbers.Push(text);
                    
                }
                
                    
            }
            
            return numbers.Peek();
        }
    }
}
