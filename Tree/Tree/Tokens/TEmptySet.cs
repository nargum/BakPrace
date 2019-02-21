using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Tokens
{
    class TEmptySet : Token
    {

        public TEmptySet() : base("#")
        {

        }

        public override string getName()
        {
            return "TEmptySet_";
        }
    }
}
