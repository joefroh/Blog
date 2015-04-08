using System;

namespace DataStructuresAndAlgorithms
{
    public class SinglyLinkedList<T> : ILinkedList<T>
    {
        private Node<T> _currentNode;
        private Node<T> _headNode;
        private Node<T> _tailNode;

        /// <summary>
        ///     Constructor.
        /// </summary>
        public SinglyLinkedList()
        {
            Length = 0;
            _headNode = null;
            _tailNode = null;
            _currentNode = null;
        }

        /// <summary>
        ///     The number of values in the list.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        ///     Adds a value to the end of the list.
        /// </summary>
        /// <param name="value">The value to add to the list.</param>
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

        /// <summary>
        ///     Tries to remove the first instance of the given value from the list. If the value is not in the list, returns
        ///     false.
        /// </summary>
        /// <param name="value">The value to remove from the list.</param>
        /// <returns>True if the value was found and removed, otherwise false.</returns>
        public bool Remove(T value)
        {
            int index = Find(value);

            return RemoveIndex(index);
        }

        /// <summary>
        ///     Tries to remove the element in the list at the given index. If the value is not int the list, returns
        ///     false.
        /// </summary>
        /// <param name="index">The index of the node to remove.</param>
        /// <returns>True if the index was valid, otherwise false.</returns>
        public bool RemoveIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                return false;
            }

            Node<T> node = _headNode;
            Node<T> prevNode = null;

            for (int i = 0; i < index; i++)
            {
                prevNode = node;
                node = node.Right;
            }

            if (prevNode == null)
            {
                //case where the head is to be removed
                _headNode = node.Right;
                node.Right = null;
                Length--;
            }
            else
            {
                if (index == Length - 1)
                {
                    _tailNode = prevNode;
                }
                prevNode.Right = node.Right;
                node.Right = null;
                Length--;
            }

            return true;
        }

        /// <summary>
        /// Searches the list for a given value.
        /// </summary>
        /// <param name="value">The value of interest.</param>
        /// <returns>The index of the node if found, -1 otherwise.</returns>
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

        /// <summary>
        /// Returns the value at a given index.
        /// </summary>
        /// <param name="index">The index of the value requested.</param>
        /// <returns>The value at the given index, or throws an exception if the index is invalid.</returns>
        public T GetValueAtIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException("index", "The provided index is outside the range of the list.");
            }
            var current = _headNode;

            for (int i = 0; i < index; i++)
            {
                current = current.Right;
            }
            return current.Data;
        }
    }
}