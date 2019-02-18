using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class ExpressionValidator
    {
        private char currentCharacter;
        private Token currentToken;
        private int counter = -1;
        private string expression;
        private int starCounter = 0;
        private bool falseExpression = false;

        public ExpressionValidator(string expression)
        {
            this.expression = expression + "?";
        }

        public void parse()
        {
            currentCharacter = nextCharacter();
            currentToken = nextToken();

            parseS();
        }

        private void parseS()
        {
            parseE();
            if(currentToken.getName() != "TEof_")
            {
                error();
            }
        }

        private void parseE()
        {
            parseT();
            parseG();
        }

        private void parseT()
        {
            parseF();
            parseU();
        }

        private void parseG()
        {
            if (currentToken.getName() == "TPlus_")
            {
                currentToken = nextToken();
                parseT();
                parseG();
            }
        }

        private void parseF()
        {
            parseX();
            parseH();
        }

        private void parseU()
        {
            if(currentToken.getName() == "TDot_" || currentToken.getName() == "TLParen" || currentToken.getName() == "TIdent")
            {
                
                currentToken = nextToken();
                parseF();
                parseU();
            }
            
        }

        private void parseX()
        {
            switch (currentToken.getName())
            {
                case "TIdent_":
                    TreeNode<string> node = new TreeNode<string>(currentToken.getValue());
                    currentToken = nextToken();
                    break;
                case "TLParen_":
                    currentToken = nextToken();
                    parseE();
                    if (currentToken.getName() != "TRParen_")
                    {
                        error();
                    }
                    currentToken = nextToken();
                    break;
                default:
                    error();
                    break;
            }
        }

        private void parseH()
        {
            
            if(currentToken.getName() == "TStar_" && starCounter == 0)
            {
                starCounter++;
                currentToken = nextToken();
                parseH();
            }

            starCounter = 0;
            
        }

        private char nextCharacter()
        {
            try
            {
                counter++;
                return expression[counter];
            }
            catch (IndexOutOfRangeException)
            {
                return '-';
                //return null;
            }
            
        }


        private Token nextToken()
        {
            while(currentCharacter == ' ' || currentCharacter == '\t')
            {
                currentCharacter = nextCharacter();
            }

            if (currentCharacter == '?')
            {
                return new TEof();
            }
            else
            {
                switch (currentCharacter)
                {
                    case '(':
                        currentCharacter = nextCharacter();
                        return new TLParen();
                    case ')':
                        currentCharacter = nextCharacter();
                        return new TRParen();
                    case '*':
                        currentCharacter = nextCharacter();
                        return new TStar();
                    case '.':
                        currentCharacter = nextCharacter();
                        return new TDot();
                    case '+':
                        currentCharacter = nextCharacter();
                        return new TPlus();
                    default:
                        if (isValidCharacter(currentCharacter))
                        {
                            return isValidIdentificator(currentCharacter);
                        }
                        else
                        {
                            error();
                            return new TEof();
                        }
                        
                }
            }
        }

        private bool isValidCharacter(char c)
        {
            if (((int)c >= 48 && (int)c <= 57) || ((int)c >= 97 && (int)c <= 122))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Token isValidIdentificator(char c)
        {
            char s = c;
            currentCharacter = nextCharacter();
            while (isValidCharacter(currentCharacter))
            {
                s += currentCharacter;
                currentCharacter = nextCharacter();
            }
            return new TIdent(s.ToString());
        }

        private void error()
        {
            if(falseExpression == false)
            {
                falseExpression = true;

                Console.WriteLine("False expression");
            }

        }

    }
}
