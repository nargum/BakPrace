using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class ExpressionChecker
    {
        private string expression;
        private int counter = -1;
        private char c;
        private Token t;

        public ExpressionChecker(string expression)
        {
            expression += "?";
            this.expression = expression;
            
        }

        public void parse()
        {
            c = nextChar();
            t = nextToken();
              
            parseS();
        }
        
        public void parseS()
        {
            parseE();
            if(t.getName() != "TEof_")
            {
                error();
            }
        }

        public void parseE()
        {
            parseT();
            parseG();
        }

        public void parseT()
        {
            parseF();
            parseR();
        }

        public void parseG()
        {
            if(t.getName() == "TPlus_")
            {
                parseA();
                parseT();
                parseG();
            }
        }

        public void parseF()
        {
            
                switch (t.getName())
                {
                    case "TIdent_":
                        t = nextToken();
                        break;
                    case "TLParen_":
                        t = nextToken();
                        parseE();
                        if (t.getName() != "TRParen_")
                        {
                            error();
                        }
                        t = nextToken();
                        break;
                    default:
                        error();
                        break;
                }
            
            
        }

        public void parseR()
        {
            if(t.getName() == "TDot_")
            {
                parseM();
                parseF();
                parseR();
            }
        }

        public void parseA()
        {
            if(t.getName() == "TPlus_")
            {
                t = nextToken();
            }
            else
            {
                error();
            }
        }

        public void parseM()
        {
            if (t.getName() == "TDot_")
            {
                t = nextToken();
            }
            else
            {
                error();
            }
        }

        public char nextChar()
        {
            counter++;
            return expression[counter];
        }

        public Token nextToken()
        {
            while(c == ' ' || c == '\t')
            {
                c = nextChar();
            }

            if(c == '?')
            {
                return new TEof();
            }
            else
            {
                switch (c)
                {
                    case '(':
                        c = nextChar();
                        return new TLParen();
                    case ')':
                        c = nextChar();
                        return new TRParen();
                    case '*':
                        c = nextChar();
                        return new TStar();
                    case '.':
                        c = nextChar();
                        return new TDot();
                    case '+':
                        c = nextChar();
                        return new TPlus();
                    default:
                        if (isCorrectChar())
                        {
                            return scanChar();
                        }
                        else
                        {
                            error();
                            return new TEof();
                        }

                }
            }
            

        }

        public bool isCorrectChar()
        {
            if(((int)c >= 48 && (int)c <= 57) || ((int)c >= 97 && (int)c <= 122))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Token scanChar()
        {
            char s = c;
            c = nextChar();
            while (isCorrectChar())
            {
                s += c;
                c = nextChar();
            }
            return new TIdent(s.ToString());
        }

        public void error()
        {
            Console.WriteLine("Invalid expression");
        }
    }
}
