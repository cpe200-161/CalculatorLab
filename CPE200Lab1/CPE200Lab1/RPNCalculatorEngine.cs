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
                
                if (isNumber(numBers[i]))    
                {
                    
                    numbersStack.Push(numBers[i]);
                    sizeStack++;
                   
                }
                else if(isOperator(numBers[i]))
                {
                    
                    opeRator = numBers[i];
                    
                    if (sizeStack != 0)
                    {
                        secondOperand = numbersStack.Pop();
                        sizeStack--;
                        if (opeRator == "√" || opeRator == "1/x")
                        {
                            numbersStack.Push(engine.unaryCalculate(opeRator, secondOperand, 8));
                        }
                        if (sizeStack < 1)
                        {
                            sizeStack = 0;
                            return "E";
                        }
                        firstOperand = numbersStack.Pop();
                        sizeStack--;
                        
                        numbersStack.Push(engine.calculate(opeRator, firstOperand, secondOperand,8));
                        
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
