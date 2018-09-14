using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RPNFrom : ExtendForm
    {

        public RPNFrom()
        {
            //InitializeComponent(); เคยประกาศไปใน calss ExtendForm ไม่จำเป็นต้องประกาศอีกครั้ง
        }

        protected override CalculatorEngine Engine()
        { 
            return new RPNCalculatorEngine();
        }
    }
}
