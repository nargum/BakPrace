using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class TLParen : Token
    {
        public TLParen() : base("(")
        {
            
        }

        public override string getName()
        {
            return "TLParen_";
        }
    }
}
