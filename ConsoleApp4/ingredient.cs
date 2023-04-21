using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{

   
    internal class Ingredient
    { //declaring ingredients attributes privatetly
        private string ingName;
        private int quan;
        private string unitm;

        public string IngName 
        {
            get { return ingName; }
            set { ingName = value; }
            
        }
        public int Quantity
        {
            get { return quan; }
            set { quan = value; }

        }
        public string UnitM
        {
            get { return unitm; }
            set { unitm = value; }

        }

    }
}
