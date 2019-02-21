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
        private TreeNode<T> leftChild = null;
        private TreeNode<T> rightChild = null;
        private int priority;

        public TreeNode(T data)
        {
            this.data = data;
            GeneratePriority();
        }

        public TreeNode()
        {
            data = default(T);
        }

        private void GeneratePriority()
        {
            if (data.Equals("*"))
                priority = 1;

            if (data.Equals("."))
                priority = 2;

            if (data.Equals("+"))
                priority = 3;
        }

        public int GetPriority()
        {
            return priority;
        }

        public T GetData()
        {
            return data;
        }

        public void SetData(T data)
        {
            this.data = data;
            GeneratePriority();
        }

        public TreeNode<T> GetParrent()
        {
            return parrent;
        }

        public void SetParrent(TreeNode<T> parrent)
        {
            this.parrent = parrent;
        }

        public TreeNode<T> GetLeftChild()
        {
            return leftChild;
        }

        public TreeNode<T> GetRightChild()
        {
            return rightChild;
        }


        public void AddLeftChild(TreeNode<T> leftChild)
        {
            this.leftChild = leftChild;
            try
            {
                leftChild.SetParrent(this);
            }
            catch (NullReferenceException)
            {
                //left child is null
            }
        }

        public void AddRightChild(TreeNode<T> rightChild)
        {
            this.rightChild = rightChild;

            try
            {
                rightChild.SetParrent(this);
            }
            catch (NullReferenceException)
            {
                //right child is null
                
            }
            
        }

        public string BuildFullExpression()
        {
            StringBuilder builder = new StringBuilder();

            if(leftChild == null && rightChild == null)
            {
                builder.Append(GetData());
                return builder.ToString();
            }
            else
            {
                builder.Append("(");
                if (leftChild != null)              
                    builder.Append(leftChild.BuildFullExpression());                
                    
                builder.Append(GetData());

                if (rightChild != null)
                    builder.Append(rightChild.BuildFullExpression());

                builder.Append(")");

                return builder.ToString();
            }
        }

        public string BuildShortExpression()
        {
            StringBuilder builder = new StringBuilder();

            if (leftChild == null && rightChild == null)
            {
                builder.Append(GetData());
                return builder.ToString();
            }
            else
            {
                if (leftChild != null)
                {
                    ComparePriority(this, leftChild, builder);
                }
                    

                builder.Append(GetData());

                if (rightChild != null)
                {
                    ComparePriority(this, rightChild, builder);
                }


                return builder.ToString();
            }
        }

        private void ComparePriority(TreeNode<T> currentNode, TreeNode<T> childNode, StringBuilder builder)
        {
            if (currentNode.GetPriority() < childNode.GetPriority())
            {
                builder.Append("(");
                builder.Append(childNode.BuildShortExpression());
                builder.Append(")");
            }
            else
                builder.Append(childNode.BuildShortExpression());
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
