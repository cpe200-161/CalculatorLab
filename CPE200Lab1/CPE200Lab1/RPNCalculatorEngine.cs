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
            string keep;
            String firstOperand;
            String secondOperand;
            String opeRator;
            int sizeStack = 0;
            CalculatorEngine engine = new CalculatorEngine();
            Stack<string> numbersStack = new Stack<string>();
            string[] numBers = str.Split(' ');

            if (numBers.Length < 3)
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
                    Console.WriteLine("Enter operator");
                    if (sizeStack != 0)
                    {

                        secondOperand = numbersStack.Pop();
                        if (opeRator == "%" && sizeStack == 1)
                        {
                            numbersStack.Push(engine.calculate(opeRator, "1", secondOperand, 8));
                            return numbersStack.Pop();
                        }
                        sizeStack--;
                        if (opeRator == "√" || opeRator == "1/x")
                        {

                            numbersStack.Push(engine.unaryCalculate(opeRator, secondOperand, 8));
                            sizeStack++;

                        }

                        try
                        {
                            firstOperand = numbersStack.Pop();
                        }
                        catch (Exception ex)
                        {
                            return "E";
                        }


                        if (opeRator == "√")
                        {
                            numbersStack.Push(firstOperand);
                        }
                        else if (opeRator == "+" || opeRator == "-" || opeRator == "X" || opeRator == "÷")
                        {

                            sizeStack--;
                            numbersStack.Push(engine.calculate(opeRator, firstOperand, secondOperand, 8));

                            sizeStack++;
                        }
                        else if (opeRator == "%")
                        {
                            sizeStack--;
                            keep = firstOperand;
                            numbersStack.Push(engine.calculate(opeRator, firstOperand, secondOperand, 8));
                            firstOperand = keep;
                            sizeStack++;
                        }
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
