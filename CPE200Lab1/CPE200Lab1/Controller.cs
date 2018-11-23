using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class Controller
    {
        protected Model m;

        public Controller()
        {

        }

        public void AddModel(Model m)
        {
            this.m = m;
        }

        // The `virtual` keyword allows the method to be overridden
        public virtual void ActionPerformed(int action)
        {
            throw new NotImplementedException();
        }
    }
}