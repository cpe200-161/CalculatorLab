using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalController : Controller
    {
        public CalController()
        {

        }

        public override void Calculate(string str)
        {
            foreach (CalModel m in mList)
            {
                m.calculator(str);
            }
        }
    }
}
