using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Tokens
{
    class TEps : Token
    {
        public TEps() : base("ε")
        {

        }

        public override string getName()
        {
            return "TEps_";
        }
    }
}
