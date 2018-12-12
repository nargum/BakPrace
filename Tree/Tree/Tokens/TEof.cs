using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class TEof : Token
    {
        public TEof() : base("__")
        {

        }

        public override string getName()
        {
            return "TEof_";
        }
    }
}
