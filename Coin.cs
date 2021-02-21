using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    abstract class Coin //Parent
    {
        public string Name;//control FK to align curly brackets
        protected double worth;//worth has lock on the box

        public double Worth //Worth has a wrench
        {
            get { return worth;}//lock on the box

            //set {worth = value; }//lock on the box not used, as this is read only
           
        }

    }
}
