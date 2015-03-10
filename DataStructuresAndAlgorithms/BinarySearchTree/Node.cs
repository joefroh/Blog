using System;

namespace BinarySearchTree
{
    public class Node<T> where T : IComparable
    {
        public T Data { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public Node()
        {
            Left = null;
            Right = null;
        }
    }
}