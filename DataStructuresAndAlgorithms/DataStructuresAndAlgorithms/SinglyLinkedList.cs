using System;

namespace DataStructuresAndAlgorithms
{
    public class SinglyLinkedList<T> : ILinkedList<T>
    {
        private Node<T> _currentNode;
        private Node<T> _headNode;
        private Node<T> _tailNode;


        public SinglyLinkedList()
        {
            Length = 0;
            _headNode = null;
            _tailNode = null;
            _currentNode = null;
        }

        public int Length { get; private set; }

        public void Add(T value)
        {
            if (Length == 0) //nothing in the list.
            {
                _headNode = new Node<T>(value);
                _tailNode = _headNode;
                Length++;
            }
            else if (Length == 1) //single item in list, head == tail
            {
                _tailNode.Right = new Node<T>(value);
                _headNode.Right = _tailNode.Right;
                _tailNode = _tailNode.Right;
                Length++;
            }
            else
            {
                _tailNode.Right = new Node<T>(value);
                _tailNode = _tailNode.Right;
                Length++;
            }
        }

        public bool Remove(T value)
        {
            throw new NotImplementedException();
        }

        public bool RemoveIndex(int index)
        {
            throw new NotImplementedException();
        }

        public int Find(T value)
        {
            int index = 0;
            _currentNode = _headNode;

            while (_currentNode != null)
            {
                if (_currentNode.Data.Equals(value))
                {
                    return index;
                }
                _currentNode = _currentNode.Right;
                index++;
            }
            return -1;
        }

        public T GetValueAtIndex(int index)
        {
            _currentNode = _headNode;

            for (int i = 0; i < index; i++)
            {
                _currentNode = _currentNode.Right;
            }
            return _currentNode.Data;
        }
    }
}