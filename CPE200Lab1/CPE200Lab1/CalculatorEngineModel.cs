using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngineModel : Model
    {
        protected CalculatorEngine engine1;
        protected RPNCalculatorEngine engine2;
        string text;

        public CalculatorEngineModel()
        {
            engine1 = new CalculatorEngine();
            engine2 = new RPNCalculatorEngine();
        }

        public string lblDisplayText()
        {
            return text;
        }

        public void ActionPerform(string str)
        {
            string result = engine1.calculate(str);
            if (result is "E")
            {
                result = engine2.calculate(str);
                if(result is "E")
                {
                    text = "Error";
                }
                else
                {
                    text = result;
                }
            }
            else
            {
                text = result;
            }
            NotifyAll();
        }

        public bool isNumber(string value)
        {
            return engine1.isNumber(value);
        }
        public string calculate(string operate, string operand)
        {
            return engine1.calculate(operate, operand);
        }
        public string calculate(string operate, string firstOperand, string secondOperand)
        {
            return calculate(operate, firstOperand, secondOperand);
        }
    }
}
