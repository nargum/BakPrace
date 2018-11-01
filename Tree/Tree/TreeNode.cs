using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class TreeNode<T>
    {
        private T data;
        private TreeNode<T> parrent;
        private TreeNode<T> leftChild;
        private TreeNode<T> rightChild;

        public TreeNode(T data)
        {
            this.data = data;
        }

        public T GetData()
        {
            return data;
        }

        public void SetData(T data)
        {
            this.data = data;
        }

        public TreeNode<T> GetParrent()
        {
            return parrent;
        }

        public void SetParrent(TreeNode<T> parrent)
        {
            this.parrent = parrent;
        }


        public void AddLeftChild(TreeNode<T> leftChild)
        {
            this.leftChild = leftChild;
            leftChild.SetParrent(this);
        }

        public void AddRightChild(TreeNode<T> rightChild)
        {
            this.rightChild = rightChild;
            rightChild.SetParrent(this);
        }

        public string BuildExpression()
        {
            StringBuilder builder = new StringBuilder();

            if(leftChild == null && rightChild == null)
            {
                builder.Append(GetData());
                return builder.ToString();
            }
            else
            {
                if (leftChild != null)
                    builder.Append(leftChild.BuildExpression());

                builder.Append(GetData());

                if (rightChild != null)
                    builder.Append(rightChild.BuildExpression());

                return builder.ToString();
            }
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
