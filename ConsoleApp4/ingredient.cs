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
        private double ScaleQuantity;
        public string IngName 
        {
            get;set;
            
        }
        public double Quantity
        {
            get;set;
            

        }
        public string UnitM
        {
            get;set;

        }
        public double ScaleQuantityyy
        {
            get; set;
        }

    }
}
