using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine  : CalculatorEngine
    {
        private CalculatorEngine engine;
        Stack<float> RPN = new Stack<float>();
        public string firstOperand;
        public string secondOperand;
        public string result;
      
        /// <summary> Determine wheter str is not operator </summary>
        /// <param name="str"> input </param>
        /// <returns> type of operator which is integer </returns>
        
        private int isNotOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return 0;
                case "%":
                    return 2;
                case "√":
                    return 3;
                case "1/X":
                    return 4;
            }
            return 1;
        }

        /// <summary> get input from RPN calculator,push number to stack and separate operator then sent to calculate in CalculatorEngine  </summary>
        /// <param name="str"> input </param>
        /// <returns> result </returns>
        public new string Process(string str)
        {
            engine = new CalculatorEngine();
            string[] element = str.Split(' ');

            if(element.Length == 1)
                {
                    return "E";
                }
                
            for (int i=0; i<element.Length; i++)
            {
                
                if (isNotOperator(element[i]) == 1)
                {
                    try
                    {
                        RPN.Push(float.Parse(element[i]));
                    }
                    catch
                    {
                        return "E";
                    }
                    
                }
                else if(isNotOperator(element[i]) == 2)
                {
                    try
                    {
                        if (element.Length == 2)
                        {
                        secondOperand = RPN.Pop().ToString();
                        secondOperand = (float.Parse(secondOperand) * 0.01).ToString();
                        }
                        else if (element[i + 1] == "+" || element[i + 1] == "-")
                        {
                            try
                            {
                                    secondOperand = RPN.Pop().ToString();
                                    firstOperand = RPN.Peek().ToString();
                                    secondOperand = (float.Parse(firstOperand) * float.Parse(secondOperand) * 0.01).ToString();

                            }
                            catch
                            {
                                    return "E";
                            }

                        }
             
                        else if (element[i + 1] == "X" || element[i + 1] == "÷")
                        {
                            secondOperand = RPN.Pop().ToString();
                            secondOperand = (float.Parse(secondOperand) * 0.01).ToString();
                        }
                    
                    
                        RPN.Push(float.Parse(secondOperand));
                    }
                    catch
                    {
                        return "E";
                    }

                    
                }
                else if(isNotOperator(element[i]) == 3)
                {
                    firstOperand = RPN.Pop().ToString() ;
                    result = engine.unaryCalculate(element[i], firstOperand);
                    RPN.Push(float.Parse(result));
                }
                else if(isNotOperator(element[i]) == 4)
                {
                    if (RPN.Peek() != 0)
                    {
                    firstOperand = 1.ToString();
                    secondOperand = RPN.Pop().ToString();
                    result = engine.calculate("÷", firstOperand, secondOperand);
                    RPN.Push(float.Parse(result));
                    }
              
                }
                else 
                {   
                    if(RPN.Count != 0)
                    {
                        secondOperand = RPN.Pop().ToString();
                        if(RPN.Count == 0)
                        {
                            return "E";
                        }
                        else
                        {
                            firstOperand = RPN.Pop().ToString();
                        }
                        try{
                            RPN.Push(float.Parse(engine.calculate(element[i], firstOperand, secondOperand)));
                        }
                        catch{
                            return "E";
                        }
                        

                    }
                    else
                    {
                        return "E";
                    }
                    

                }
                

            }

            
            if (RPN.Count == 1)
            {
                result = RPN.Pop().ToString();
                return result;
            }
            else
            {
                return "E";
            }

           

        }
        

    }
        
}
