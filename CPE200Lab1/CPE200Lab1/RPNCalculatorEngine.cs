using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : TheCalculatorEngine
    {
        protected Stack<string> myStack = new Stack<string>();
        protected bool hasDot;
        protected string oper;

        public new string calculate(string str) 
        {
            string keep;
            String firstOperand;
            String secondOperand;
            String opeRator;
            int sizeStack = 0;
            TheCalculatorEngine engine = new TheCalculatorEngine();
            
            string[] numBers = str.Split(' ');

            if (numBers.Length < 3)
            {
                return "E";
            }

            for (int i = 0; i < numBers.Length; i++)
            {
                
                if (isNumber(numBers[i]))    
                {
                    
                    myStack.Push(numBers[i]);
                    sizeStack++;
                   
                }
                else if(isOperator(numBers[i]))
                {
                    
                    opeRator = numBers[i];
                    Console.WriteLine("Enter operator");
                    if (sizeStack != 0)
                    {

                        secondOperand = myStack.Pop();
                        if (opeRator == "%" && sizeStack == 1)
                        {
                            myStack.Push(engine.calculate(opeRator, "1",secondOperand, 8));
                            return myStack.Pop();
                        }
                        sizeStack--;
                        if (opeRator == "√" || opeRator == "1/x")
                        {
                            Console.WriteLine("Enter unarycalculate SecondOperand "+secondOperand+"Operator "+opeRator);
                            myStack.Push(engine.calculate(opeRator, secondOperand, 8));
                            Console.WriteLine("Complete!");
                            sizeStack++;
                            
                        }
                        if (sizeStack < 1)
                        {
                            sizeStack = 0;
                            return "E";
                        }
                        firstOperand = myStack.Pop();
                        
                        if (opeRator== "√")
                        {
                            myStack.Push(firstOperand);
                        }
                        else if (opeRator == "+" || opeRator == "-" || opeRator == "X" || opeRator == "÷")
                        {
                 
                            sizeStack--;
                            myStack.Push(engine.calculate(opeRator, firstOperand, secondOperand, 8));
                            
                            sizeStack++;
                        }
                        else if (opeRator == "%")
                        {
                            sizeStack--;
                            keep = firstOperand;
                            myStack.Push(engine.calculate(opeRator, firstOperand, secondOperand, 8));
                            firstOperand = keep;
                            sizeStack++;
                        }
                    }
                }
            }

            if (sizeStack == 1)
            {
                sizeStack = 0;
                return myStack.Pop();
            }
            else
            {
                sizeStack = 0;
                return "E";
            }

        }
    }
}
