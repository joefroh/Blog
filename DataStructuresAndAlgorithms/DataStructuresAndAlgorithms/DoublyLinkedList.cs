using System;

namespace DataStructuresAndAlgorithms                                  
{
    /// <summary>
    ///     Doubly Linked List Implementation.
    /// </summary>
    /// <typeparam name="T">The type of data the list is storing.</typeparam>
    public class DoublyLinkedList<T> : ILinkedList<T>
    {
        /// <summary>
        ///     Private variable to keep track internally of where we are in traversing the list.
        /// </summary>
        private Node<T> _currentNode;

        /// <summary>
        ///     Private variable to keep track of the head (front) of the list.
        /// </summary>
        private Node<T> _headNode;

        /// <summary>
        ///     Private variable to keep track of the tail (end) of the list.
        /// </summary>
        private Node<T> _tailNode;

        /// <summary>
        ///     Property that keeps track of how large the list is.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        ///     Method that adds a given value to the list.
        /// </summary>
        /// <param name="value">The value to be added to the list.</param>
        public void Add(T value)
        {
            if (Length == 0) //empty list
            {
                _headNode = new Node<T>(value);
                _tailNode = _headNode;
                _currentNode = _headNode;
            }

            else if (Length == 1)
            {
                _tailNode.Next = new Node<T>(value);
                _tailNode.Next.Previous = _tailNode;
                _tailNode = _tailNode.Next;
                _headNode.Next = _tailNode;
            }
            else
            {
                _tailNode.Next = new Node<T>(value);
                _tailNode.Next.Previous = _tailNode;
                _tailNode = _tailNode.Next;
            }
            Length++;
        }

        /// <summary>
        ///     Method that tries to remove a given value from the list. If the value isn't in the list, this method returns false.
        ///     This method returns the first matching value in the list.
        ///     If data repeats, subsequent values are still present in the list.
        /// </summary>
        /// <param name="value">The value to be removed from the list.</param>
        /// <returns>True if the value was found and removed. False otherwise.</returns>
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
                    Length--;
                    return true;
                }
                _currentNode = _currentNode.Next;
            }

            return false;
        }

        /// <summary>
        ///     Removes a given indexed value from the list.
        /// </summary>
        /// <param name="index">The index position to be removed.</param>
        /// <returns>True if the index was in range and removed, false otherwise.</returns>
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
        ///     Searches the DoublyLinkedList and returns the index of the value being searched for.
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
                _currentNode = _currentNode.Next;
            }

            return -1;
        }

        /// <summary>
        ///     Returns the value stored at a given index in the list.
        /// </summary>
        /// <param name="index">The index to be retrieved.</param>
        /// <returns>The value stored at a given index in the list.</returns>
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