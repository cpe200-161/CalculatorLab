using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class Model
    {
        protected View v;

        public Model()
        {

        }

        public void NotifyAll()
        {
            v.Notify(this);
        }

        public void AttachObserver(View v)
        {
            this.v = v;
        }
    }
}