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
        protected RPNCalculatorEngine RPNEngine;
        private string display;
        public CalculatorModel()
        {
            engine = new CalculatorEngine();
            RPNEngine = new RPNCalculatorEngine();
        }
        public string Display()
        {
            return display;
        }
        public void calculator(string str)
        {
            string result = engine.calculate(str);
            if (result is "E")
            {
                result = RPNEngine.calculate(str);
                if (result is "E")
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
        public string calculate(string operate, string operand)
        {
            return engine.calculate(operate, operand);
        }
        public string calculate(string operate, string firstoperand, string secondoperand)
        {
            return calculate(operate, firstoperand, secondoperand);
        }
    }
}