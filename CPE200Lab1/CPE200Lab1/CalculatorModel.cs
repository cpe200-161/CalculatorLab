using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorModel : Model
    {
        protected CalculatorEngine engine;
        protected RPNCalculatorEngine RPN_engine;
        private string show;

        public CalculatorModel()
        {
            engine = new CalculatorEngine();
            RPN_engine = new RPNCalculatorEngine();
        }

        public string Show()
        {
            return show;
        }

        public void calculator(string str)
        {
            string result = engine.calculate(str);
            if (result is "E")
            {
                result = RPN_engine.calculate(str);
                if (result is "E")
                {
                    show = "Error";
                }
                else
                {
                    show = result;
                }
            }
            else
            {
                show = result;
            }
            NotifyAll();
        }

        public bool isNumber(string num)
        {
            return engine.isNumber(num);
        }

        public string calculate(string operate, string operand)
        {
            return engine.calculate(operate, operand);
        }

        public string calculate(string operate, string firstOperand, string secondOperand)
        {
            return calculate(operate, firstOperand, secondOperand);
        }
    }
}