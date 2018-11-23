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
        protected RPNCalculatorEngine RPNengine;
        private string result;

        public CalculatorModel()
        {
            engine = new CalculatorEngine();
            RPNengine = new RPNCalculatorEngine();
        }

        public string getResult()
        {
            return result;
        }

        public void calculator(string str)
        {
            string result = engine.calculate(str);
            if (result is "E")
            {
                result = RPNengine.calculate(str);
                if (result is "E")
                {
                    this.result = "Error";
                }
                else
                {
                    this.result = result;
                }
            }
            else
            {
                this.result = result;
            }
            NotifyAll();

        }

        public bool isNumber(string str)
        {
            return engine.isNumber(str);
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
