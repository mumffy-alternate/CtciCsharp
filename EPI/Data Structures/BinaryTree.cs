﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EPI.DataStructures
{
    public class BinaryTree<T>
    {
        private Node<T> root;

        public Node<T> Root
        {
            get
            {
                return root;
            }
            set
            {
                root = value;
            }
        }

        public string ToBfstrString()
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            StringBuilder sb = new StringBuilder();

            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                Node<T> node = queue.Dequeue();
                if (node != null)
                {
                    sb.AppendFormat("{0}", node.Value);
                    if(node.Left != null)
                    {
                        sb.AppendFormat(" L:{0}", node.Left.Value);
                        queue.Enqueue(node.Left);
                    }
                    if(node.Right != null)
                    {
                        sb.AppendFormat(" R:{0}", node.Right.Value);
                        queue.Enqueue(node.Right);
                    }
                    sb.Append("\n");
                }
            }

            return sb.ToString();
        }
    }

    public class Node<T>
    {
        private T value;
        private Node<T> left;
        private Node<T> right;

        public Node(T value, Node<T> left = null, Node<T> right = null)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public T Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        public Node<T> Left { get { return left; } set { left = value; } }
        public Node<T> Right { get { return right; } set { right = value; } }

    }

    public class BinaryTree_Tests
    {
        [Fact]
        public void Test01()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Root = new Node<int>(314);
            tree.Root.Left = new Node<int>(6,
                left: new Node<int>(271),
                right: new Node<int>(561)
                );
            tree.Root.Right = new Node<int>(7,
                left: new Node<int>(2),
                right: new Node<int>(999)
                );

            Assert.Equal(314, tree.Root.Value);
            Assert.Equal(6, tree.Root.Left.Value);
            Assert.Equal(7, tree.Root.Right.Value);
            Assert.Equal(271, tree.Root.Left.Left.Value);
            Assert.Equal(561, tree.Root.Left.Right.Value);
            Assert.Equal(2, tree.Root.Right.Left.Value);
            Assert.Equal(999, tree.Root.Right.Right.Value);
        }
    }
}
