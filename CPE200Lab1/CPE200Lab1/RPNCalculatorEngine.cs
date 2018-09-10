using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str) 
        {
            String firstOperand;
            String secondOperand;
            String opeRator;
            int sizeStack = 0;
            CalculatorEngine engine = new CalculatorEngine();
            Stack<string> numbersStack = new Stack<string>();
            string[] numBers = str.Split(' ');
            

            for (int i = 0; i < numBers.Length; i++)
            {
                Console.WriteLine("loop push&pop");
                if (isNumber(numBers[i]))    
                {
                    Console.WriteLine("Number on");
                    numbersStack.Push(numBers[i]);
                    sizeStack++;
                   
                }
                else if(isOperator(numBers[i]))
                {
                    Console.WriteLine("Operator on");
                    opeRator = numBers[i];
                    Console.WriteLine(opeRator+sizeStack);
                    if (sizeStack != 0)
                    {
                        secondOperand = numbersStack.Pop();
                        sizeStack--;
                        if (sizeStack < 1)
                        {
                            sizeStack = 0;
                            return "E";
                        }
                        firstOperand = numbersStack.Pop();
                        sizeStack--;
                        Console.WriteLine("Ready to calculate");
                        numbersStack.Push(engine.calculate(opeRator, firstOperand, secondOperand,8));
                        Console.WriteLine("Complete!");
                        sizeStack++;
                    }
                }
            }

            if (sizeStack == 1)
            {
                sizeStack = 0;
                return numbersStack.Pop();
            }
            else
            {
                sizeStack = 0;
                return "E";
            }

        }
    }
}
