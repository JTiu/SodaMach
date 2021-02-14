using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Quarter : Coin
    {

        ///Var HAS
        public Quarter() 
        {
            Name = "Quarter";//Name, no lock on the box

            Worth = .25;//Worth, has a wrench
        }


    }
}
