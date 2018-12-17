using System;
using System.Collections;
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
        private TreeNode<string> root;
        private TreeNode<string> currentNode;
        private ArrayList nodes = new ArrayList();
        private Stack<TreeNode<string>> brackets = new Stack<TreeNode<string>>();
        private bool bracket = false;

        public ExpressionChecker(string expression)
        {
            expression += "?";
            this.expression = expression;
            
        }

        public TreeNode<string> getTree()
        {
            return root;
        }

        public void parse()
        {
            c = nextChar();
            t = nextToken();
              
            parseS();
        }
        
        public void parseS()
        {
            /*if(t.getValue() != "(" || t.getValue() != ")")
            {
                root = new TreeNode<string>(t.getValue());
            }
            parseE(root);*/
            root = new TreeNode<string>();
            //nodes.Add(root);
            currentNode = root;
            parseE();
            if(t.getName() != "TEof_")
            {
                error();
            }
        }

        public void parseE()
        {
            /*TreeNode<string> left = new TreeNode<string>();
            TreeNode<string> right = new TreeNode<string>();
            node.AddLeftChild(left);
            node.AddRightChild(right);
            parseT(left);
            parseG(right);*/
            parseT();
            parseG();
        }

        public void parseT()
        {
            /*TreeNode<string> left = new TreeNode<string>();
            TreeNode<string> right = new TreeNode<string>();
            node.AddLeftChild(left);
            node.AddRightChild(right);
            parseF(left);
            parseR(right);*/
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
                        TreeNode<string> child = new TreeNode<string>(t.getValue());
                        /*if(currentNode.GetLeftChild() == null)
                        {
                            if(nodes.Count == 0)
                            {
                                currentNode.AddLeftChild(child);
                                nodes.Add(currentNode);
                        }
                        else
                            {
                                TreeNode<string> n = (TreeNode<string>)nodes[0];
                                n.AddRightChild(child);
                                nodes.RemoveAt(0);
                            }
                        }*/
                        if(nodes.Count == 0)
                        {
                            currentNode.AddLeftChild(child);
                            nodes.Add(currentNode);
                        }
                        else
                        {
                            TreeNode<string> n = (TreeNode<string>)nodes[0];
                            n.AddRightChild(child);
                            nodes.RemoveAt(0);
                        }
                        
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
                currentNode.SetData(t.getValue());
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
                currentNode.SetData(t.getValue());
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
                        bracket = true;
                        TreeNode<string> br = new TreeNode<string>();
                        brackets.Push(br);
                        currentNode = br;
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
                        if(currentNode.GetData() == default(string))
                        {
                            currentNode.SetData("+");
                        }
                        else
                        {
                            TreeNode<string> node = new TreeNode<string>("+");
                            if (currentNode.GetLeftChild() == null)
                            {
                                currentNode.AddLeftChild(node);
                            }
                            else
                            {
                                if(currentNode.GetRightChild() == null)
                                {
                                    currentNode.AddRightChild(node);
                                }
                                else
                                {
                                    node.AddLeftChild(currentNode.GetRightChild());
                                    currentNode.AddRightChild(node);
                                    nodes.Add(node);
                                }
                                
                            }
                            currentNode = node;
                        }
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
