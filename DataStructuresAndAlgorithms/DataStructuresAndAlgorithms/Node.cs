using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class Node<T>
    {
        private Node<T> _previous ;
        private Node<T> _next;
        private T _data;

        public Node(T data)
        {
            _data = data;
        }

        public Node<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public Node<T> Previous
        {
            get { return _previous; }
            set { _previous = value; }
        }

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }

    }
}
