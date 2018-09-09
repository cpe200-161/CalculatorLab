using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{    
    public class RPNCalculatorEngine : CalculatorEngine
    {
        //string firstOperand, secondOperand;
        public string Process(string str)
        {

            String firstOperand;
            String secondOperand;
            String opeRator;
            int membersStack = 0;
            CalculatorEngine engine = new CalculatorEngine();

            Stack<string> numbersStack = new Stack<string>();
            string[] numBers = str.Split(' ');

            if(numBers.Length < 3)
            {
                membersStack = 0;
                return "E";
            }

            for (int i = 0; i < numBers.Length; i++)
            {
                if (isNumber(numBers[i]))
                {
                    numbersStack.Push(numBers[i]);
                    membersStack++;
                }
                else if(isOperator(numBers[i]))
                {                    
                    opeRator = numBers[i];
                    if(membersStack != 0)
                    {
                        secondOperand = numbersStack.Pop();
                        membersStack--;
                        if(membersStack < 1)
                        {
                            membersStack = 0;
                            return "E";
                        }
                        firstOperand = numbersStack.Pop();
                        membersStack--;
                        numbersStack.Push(engine.calculate(opeRator, firstOperand, secondOperand));
                        membersStack++;
                    }                    
                }
            }
            
            if(membersStack == 1)
            {
                membersStack = 0;
                return numbersStack.Pop();
            }
            else
            {
                membersStack = 0;
                return "E";
            }
            
        }
    }
}
