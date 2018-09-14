using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        
        
        
        private string v1, v2;


        public override void BtSpace_Click()
        {
            base.BtSpace_Click();
            isNumberPart = false;
            
        }

        public override string Process(string str)
        {
            Stack<string> s = new Stack<string>();
            string[] parts = str.Split(' ');



            foreach (string i in parts) 
                {
                    if (isNumber(i))
                    {
                        s.Push(i);

                    }
                    else if(isOperator(i))
                    {
                        v1 = s.Pop();
                        v2 = s.Pop();
                        s.Push(calculate(i, v2, v1 ));
                    }


                }

                return s.Peek();
            
        }

        


    }
    }
