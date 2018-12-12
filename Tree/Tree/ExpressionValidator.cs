using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class ExpressionValidator
    {
        private string expression;
        private List<Token> tokens = null;

        public ExpressionValidator(string expression)
        {
            this.expression = modifyExpression(expression);
            tokens = new List<Token>();
            if (convertToTokens())
            {
                returnTokens();
            }
            else
            {
                Console.WriteLine("spatne znaky");
            }
        }

        public string getExpression()
        {
            return expression;
        }


        private string modifyExpression(string expression)
        {
            expression = expression.ToLower();
            expression = expression.Replace(" ", string.Empty);
            expression = expression.Replace("\t", string.Empty);

            return expression;
        }

        private bool convertToTokens()
        {
            for(int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case '(':
                        tokens.Add(new TLParen());
                        break;
                    case ')':
                        tokens.Add(new TRParen());
                        break;
                    case '*':
                        tokens.Add(new TStar());
                        break;
                    case '+':
                        tokens.Add(new TPlus());
                        break;
                    default:
                        if(((int)expression[i] >= 48 && (int)expression[i] <= 57) || ((int)expression[i] >= 97 && (int)expression[i] <= 122))
                        {
                            tokens.Add(new TIdent(expression[i].ToString()));
                        }
                        else
                        {
                            tokens = null;
                            return false;
                        }

                        break;

                }
            }
            tokens.Add(new TEof());

            return true;
        }

        public void returnTokens()
        {
            string result = null;
            foreach(Token t in tokens)
            {
                result += t.getName();
            }

            Console.WriteLine(result);
        }
    }
}
