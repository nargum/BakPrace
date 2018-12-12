using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class TPlus : Token
    {
        public TPlus() : base("+")
        {

        }

        public override string getName()
        {
            return "TPlus_";
        }
    }
}
