using System;

namespace DataStructuresAndAlgorithms
{
    public class LinkedList<T>
    {
        private Node<T> _currentNode;
        private Node<T> _headNode;
        private Node<T> _tailNode;

        public int Length { get; private set; }

        public void Add(T value)
        {
            if (Length == 0) //empty list
            {
                _headNode = new Node<T>(value);
                _tailNode = _headNode;
                _currentNode = _headNode;
            }

            _tailNode.Next = new Node<T>(value);
            _tailNode.Next.Previous = _tailNode;
            _tailNode = _tailNode.Next;
            Length++;
        }

        public bool Remove(T value)
        {
            _currentNode = _headNode;

            while (_currentNode != null)
            {
                if (_currentNode.Data.Equals(value))
                {
                    if (Length == 1) //only 1 thing in the list, tail == head == current
                    {
                        _currentNode = null;
                        _headNode = null;
                        _tailNode = null;
                    }
                    else if (_currentNode == _headNode) //head
                    {
                        _headNode = _headNode.Next;
                        _headNode.Previous.Next = null;
                        _headNode.Previous = null;
                    }
                    else if (_currentNode == _tailNode) //tail
                    {
                        _tailNode = _tailNode.Previous;
                        _tailNode.Next.Previous = null;
                        _tailNode.Next = null;
                    }
                    else
                    {
                        _currentNode.Previous.Next = _currentNode.Next;
                        _currentNode.Next.Previous = _currentNode.Previous;
                        _currentNode.Next = null;
                        _currentNode.Previous = null;
                    }
                }
                Length--;
                return true;
            }

            return false;
        }

        public bool RemoveIndex(int index)
        {
            if (index > Length - 1 || index < 0) //if index is out of range, or less than zero
            {
                return false;
            }

            _currentNode = _headNode;
            for (int i = 0; i < index; i++) //set current node to point to the index in question
            {
                _currentNode = _currentNode.Next;
            }

            if (Length == 1) //there is only one thing in the list
            {
                _headNode = null;
                _tailNode = null;
                _currentNode = null;
            }
            else if (index == 0) //head
            {
                _headNode = _headNode.Next;
                _headNode.Previous.Next = null;
                _headNode.Previous = null;
            }
            else if (index == Length - 1) //tail
            {
                _tailNode = _tailNode.Previous;
                _tailNode.Next.Previous = null;
                _tailNode.Next = null;
            }
            else
            {
                _currentNode.Previous.Next = _currentNode.Next;
                _currentNode.Next.Previous = _currentNode.Previous;
                _currentNode.Next = null;
                _currentNode.Previous = null;
            }

            Length--;
            return true;
        }

        /// <summary>
        ///     Searches the LinkedList and returns the index of the value being searched for.
        /// </summary>
        /// <param name="value">The value being searched for.</param>
        /// <returns>The index of the value being searched for or -1 if the value is not found.</returns>
        public int Find(T value)
        {
            _currentNode = _headNode;

            for (int i = 0; i < Length; i++)
            {
                if (_currentNode.Data.Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        public T GetValueAtIndex(int index)
        {
            if (index > Length - 1 || index < 0) //if index is out of range, or less than zero
            {
                throw new ArgumentOutOfRangeException();
            }

            _currentNode = _headNode;
            for (int i = 0; i < index; i++) //set currentNode to point to the index requested
            {
                _currentNode = _currentNode.Next;
            }

            return _currentNode.Data;
        }
    }
}