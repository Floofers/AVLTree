using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            tree.Add(42);
            tree.Add(37);
            tree.Add(17);
            tree.Add(49);
            tree.Add(12);
            Console.ReadKey();
        }
    }
}
