using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private Node<T> _root;

        public bool CreateTree(IEnumerable<T> list)
        {
            _root = new Node<T>();

            var length = list.Count();

            if (length != 0)
            {
                _root = CreateTreeNodes(list, 0, length);
                return true;
            }
            return false;
        }

        private Node<T> CreateTreeNodes(IEnumerable<T> list, int start, int end)
        {
            var length = end - start;
            if (length > 0)
            {
                var root = new Node<T>();

                root.Data = list.ElementAt((length / 2) + start);
                root.Left = CreateTreeNodes(list, start, (length / 2) + start);
                root.Right = CreateTreeNodes(list, (length / 2) + start + 1, end);

                return root;
            }

            return null;
        }
    }
}
