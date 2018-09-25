using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{

    class SimpleCalculatorEngines : CalculatorEngine
    {
        protected double firstOperand;
        protected double secondOperand;

        public double setFirstOperand
        {
            get => firstOperand;
            set => firstOperand = value;
        }
        public double setSecondOperand
        {
            get => secondOperand;
            set => secondOperand = value;
        }

        public string calculate(string oper)
        {
            return oper;
        }
    }
}
