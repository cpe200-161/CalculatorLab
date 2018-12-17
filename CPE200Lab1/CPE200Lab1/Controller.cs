using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class Controlller
    {
        CalculatorEngine Engine_1;
        RPNCalculatorEngine Engine_2;
        
        public Controlller()
        {
            Engine_1 = new CalculatorEngine();
            Engine_2 = new RPNCalculatorEngine();
        }

        public string Calculate(string str)
        {
            return Engine_1.Process(str);
        }

        public string RPNCalculate(string str)
        {
            return Engine_2.Process(str);
        }
    }
}
