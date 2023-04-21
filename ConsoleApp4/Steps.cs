using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Steps
    {
        //declaring steps attributes privatetly
        private int numofsteps;
        private string descr;

        public int NumOfsteps
        {
            get { return numofsteps; }
            set { numofsteps = value; }

        }
        public string Description
        {
            get { return descr; }
            set { descr = value; }

        }
    }
}
