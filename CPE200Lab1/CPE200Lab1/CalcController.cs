using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalcController : Controller
    {
        public CalcController()
        {

        }

        public override void Calculate(string str)
        {
            foreach (CalcModel m in mList)
            {
                m.calculator(str);
            }
        }
    }
}
