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
      
        
        private bool isNotOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return false;
            }
            return true;
        }

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
                
                if (isNotOperator(element[i]))
                {
                    RPN.Push(float.Parse(element[i]));
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
                        
                        RPN.Push(float.Parse(engine.calculate(element[i], firstOperand, secondOperand)));

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
