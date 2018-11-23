using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngineController : Controller
    {
        public CalculatorEngineController()
        {

        }

        public override void Calculate(string str)
        {
            foreach (CalculatorEngineModel m in mList)
            {
                m.ActionPerform(str);
            }
        }
          
           
    }           
}

