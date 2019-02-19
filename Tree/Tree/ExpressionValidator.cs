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

        public TreeNode<string> parse()
        {
            currentCharacter = nextCharacter();
            currentToken = nextToken();

            return parseS();
        }

        private TreeNode<string> parseS()
        {
            TreeNode<string> nodeS = parseE();
            if(currentToken.getName() != "TEof_")
            {
                error();
                return null;
            }
            return nodeS;
        }

        private TreeNode<string> parseE()
        {
            TreeNode<string> nodeT = parseT();
            TreeNode<string> nodeG = parseG();

            if(nodeG != null)
            {
                //nodeT.AddRightChild(nodeG);
                nodeG.AddLeftChild(nodeT);
                return nodeG;
            }

            return nodeT;
        }

        private TreeNode<string> parseT()
        {
            TreeNode<string> nodeF = parseF();
            TreeNode<string> nodeU = parseU();

            if (nodeU != null)
                nodeF.AddRightChild(nodeU);

            return nodeF;
        }

        private TreeNode<string> parseG()
        {
            if (currentToken.getName() == "TPlus_")
            {
                TreeNode<string> node = new TreeNode<string>(currentToken.getValue());
                currentToken = nextToken();
                TreeNode<string> nodeT = parseT();
                TreeNode<string> nodeG = parseG();

                if(nodeG != null)
                {
                    //nodeT.AddRightChild(nodeG);
                    nodeG.AddLeftChild(nodeT);
                    node.AddRightChild(nodeG);
                    return node;
                }

                node.AddRightChild(nodeT);

                return node;
                

            }
            return null;
        }

        private TreeNode<string> parseF()
        {
            TreeNode<string> nodeX = parseX();
            TreeNode<string> nodeH = parseH();

            if(nodeH == null)
            {
                return nodeX;
            }
            
            nodeH.AddLeftChild(nodeX);
            return nodeH;
        }

        private TreeNode<string> parseU()
        {
            if(currentToken.getName() == "TDot_" || currentToken.getName() == "TIdent")
            {
                TreeNode<string> node = new TreeNode<string>(currentToken.getValue());
                currentToken = nextToken();
                TreeNode<string> nodeF = parseF();
                TreeNode<string> nodeU = parseU();

                
                if(nodeU != null)
                    nodeF.AddRightChild(nodeU);

                node.AddRightChild(nodeF);
                return node;
                
            }else if(currentToken.getName() == "TLParen")
            {
                currentToken = nextToken();
                TreeNode<string> nodeF = parseF();
                TreeNode<string> nodeU = parseU();

                if(nodeU != null)
                    nodeF.AddRightChild(nodeU);
                return nodeF;
            }
            return null;
            
        }

        private TreeNode<string> parseX()
        {
            TreeNode<string> node = new TreeNode<string>();
            switch (currentToken.getName())
            {
                case "TIdent_":
                    //TreeNode<string> node = new TreeNode<string>(currentToken.getValue());
                    node.SetData(currentToken.getValue());
                    currentToken = nextToken();
                    return node;
                case "TLParen_":
                    currentToken = nextToken();
                    node = parseE();
                    if (currentToken.getName() != "TRParen_")
                    {
                        error();
                        return null;
                    }
                    currentToken = nextToken();
                    return node;
                default:
                    error();
                    return null;
            }
        }

        private TreeNode<string> parseH()
        {
            TreeNode<string> node = null;
            if(currentToken.getName() == "TStar_" && starCounter == 0)
            {
                starCounter++;
                node = new TreeNode<string>(currentToken.getValue());
                currentToken = nextToken();
                TreeNode<string> child = parseH();
                node.AddRightChild(child);
            }

            starCounter = 0;
            return node;
            
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
