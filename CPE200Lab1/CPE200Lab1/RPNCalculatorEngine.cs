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
            string secondOperand;
            string firstOperand;
            string ansWer;
            foreach (string text in part)
            {
                if (isOperator(text))
                {
                    try   
                    {
                        secondOperand = numbers.Pop(); 
                        firstOperand = numbers.Pop();
                        ansWer = calculate(text, firstOperand, secondOperand);  // calculate secondOperand and firstOperand
                        numbers.Push(ansWer);
                    }
                    catch (Exception)  // Pop stack when stack empty
                    {
                        return "E";
                    }
                }
                else if (isNumber(text)) // if String is Number
                {

                    numbers.Push(text);

                }
                else if (text == "√" || text == "1/x") // text is square root or OneOverX  
                {
                    ansWer = unaryCalculate(text, numbers.Pop()); // calculate with method unaryCalculate()
                    numbers.Push(ansWer);
                }
                else
                {
                    return "E";
                }
            }
            if (numbers.Count == 1) // stack must have only one value after calculate
            {
                return numbers.Pop();
            }
            else // stack have many value
            {
                return "E";
            }
        }
    }
}
