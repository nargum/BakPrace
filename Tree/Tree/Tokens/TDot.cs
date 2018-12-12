using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class TDot : Token
    {
        public TDot() : base(".")
        {

        }

        public override string getName()
        {
            return "TDot_";
        }
    }
}
