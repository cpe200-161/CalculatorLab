using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorModel : Model
    {
        protected SimpleCalculatorEngine engine;
        protected RPNCalculatorEngine RPNengine;
        private string display;

        public CalculatorModel() { }

        public string Display()
        {
            return display;
        }

        public void calculator(string str)
        {
            string result = engine.calculate(str);
            if(result is "E")
            {
                result = RPNengine.calculate(str);
                if(result is "E")
                {
                    display = "Error";
                }
                else
                {
                    display = result;
                }
            }
            else
            {
                display = result;
            }
            NotifyAll();
        }

        public bool isNumber(string num)
        {
            return engine.isNumber(num);
        }

        public string calculate(string oper,string operand)
        {
            return engine.calculate(oper, operand);
        }

        public string calculate(string oper,string firstOperand,string secondOperand)
        {
            return calculate(oper, firstOperand, secondOperand);
        }

    }
}
