using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class TStar : Token
    {
        public TStar() : base("*")
        {

        }

        public override string getName()
        {
            return "TStar_";
        }
    }
}
