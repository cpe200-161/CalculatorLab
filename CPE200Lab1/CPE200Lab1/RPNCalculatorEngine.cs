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

            if (numBers.Length < 3 || !isNumber(numBers[0]))
            {
                return "E";
            }

            for (int i = 0; i < numBers.Length; i++)
            {
                if (isNumber(numBers[i]))
                {
                    numbersStack.Push(numBers[i]);
                    sizeStack++;
                }
                else if (isOperator(numBers[i]))
                {
                    opeRator = numBers[i];
                    if (sizeStack != 0)
                    {
                        if (sizeStack < 1)
                        {
                            return "E";
                        }
                        try
                        {
                            secondOperand = numbersStack.Pop();
                            firstOperand = numbersStack.Pop();
                        }
                        catch (InvalidOperationException)
                        {
                            return "E";
                        }
                        sizeStack -= 2;
                        numbersStack.Push(engine.calculate(opeRator, firstOperand, secondOperand));
                        sizeStack++;
                    }
                }
            }

            if (sizeStack == 1)
            {
                return numbersStack.Pop();
            }
            else
            {
                return "E";
            }

        }
    }
}
