using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class TIdent : Token
    {
        public TIdent(string value) : base(value)
        {

        }

        public override string getName()
        {
            return "TIdent_";
        }
    }
}
