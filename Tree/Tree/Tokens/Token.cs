using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    abstract class Token
    {
        private string value;

        public Token(string value)
        {
            this.value = value;
        }

        public string getValue()
        {
            return value;
        }

        public abstract string getName();
        
    }
}
