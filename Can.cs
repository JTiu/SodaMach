using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    abstract class Can //good, learned about get & set. Private field price has the lock on the box, Public has the wrench = can read. 
    {

        private double price;//field, has a get/ set, and a lock on the box
        public string Name;//no lock on this box
        public double Price //Price has a wrench
        {
            get {return price;}//price has a lock on the box


            set {this.price = value;}//lock on the box
        }


    }
}
