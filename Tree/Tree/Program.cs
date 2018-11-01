using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode<string> root = new TreeNode<string>("+");
            TreeNode<string> node1 = new TreeNode<string>("*");
            TreeNode<string> node2 = new TreeNode<string>(".");
            root.AddLeftChild(node1);
            root.AddRightChild(node2);

            TreeNode<string> node3 = new TreeNode<string>("+");
            node1.AddLeftChild(node3);

            TreeNode<string> node4 = new TreeNode<string>("a");
            TreeNode<string> node5 = new TreeNode<string>(".");
            node3.AddLeftChild(node4);
            node3.AddRightChild(node5);

            TreeNode<string> node6 = new TreeNode<string>("b");
            TreeNode<string> node7 = new TreeNode<string>(".");
            node5.AddLeftChild(node6);
            node5.AddRightChild(node7);

            TreeNode<string> node8 = new TreeNode<string>("a");
            TreeNode<string> node9 = new TreeNode<string>("b");
            node7.AddLeftChild(node8);
            node7.AddRightChild(node9);

            TreeNode<string> node10 = new TreeNode<string>("b");
            TreeNode<string> node11 = new TreeNode<string>("c");
            node2.AddLeftChild(node10);
            node2.AddRightChild(node11);
            Console.WriteLine(root.BuildExpression());
            Console.ReadKey();
 
        }
    }
}
