using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Tester
    {
        TreeNode<string> root;
        TreeNode<string> currentNode;

        public void saveString(string expression)
        {
            root = new TreeNode<string>();
            currentNode = root;

            for (int i = 0; i < expression.Length; i++)
            {
                if(expression[i] != '+')
                {
                    TreeNode<string> ident = new TreeNode<string>(expression[i].ToString());
                }
            }
        }
    }
}
