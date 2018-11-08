﻿using System;
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
        private int priority;

        public TreeNode(T data)
        {
            this.data = data;
            generatePriority();
        }

        private void generatePriority()
        {
            if (data.Equals("*"))
                priority = 1;

            if (data.Equals("."))
                priority = 2;

            if (data.Equals("+"))
                priority = 3;
        }

        public int getPriority()
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
                    if(getPriority() < leftChild.getPriority())
                    {
                        builder.Append("(");
                        builder.Append(leftChild.BuildShortExpression());
                        builder.Append(")");
                    }else
                        builder.Append(leftChild.BuildShortExpression());
                }
                    

                builder.Append(GetData());

                if (rightChild != null)
                {
                    if (getPriority() < rightChild.getPriority())
                    {
                        builder.Append("(");
                        builder.Append(rightChild.BuildShortExpression());
                        builder.Append(")");
                    }
                    else
                        builder.Append(rightChild.BuildShortExpression());
                }


                return builder.ToString();
            }
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}