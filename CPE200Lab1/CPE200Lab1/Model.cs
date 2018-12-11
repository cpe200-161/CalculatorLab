using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class Model
    {
        protected ArrayList oList;

        public Model()
        {
            oList = new ArrayList();
        }

        public void AttachObserver(View model)
        {
            oList.Add(model);
        }

        public void NotifyAll()
        {
            foreach (View model in oList)
            {
                model.Notify(this);
            }
        }
    }
}