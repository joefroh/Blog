using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new[] {1, 2, 3, 4, 5, 6, 7};

            var tree = new BinarySearchTree<int>();
            var result = tree.CreateTree(list);
        }
    }
}
