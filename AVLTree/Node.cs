using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    class Node<T>
    {
        public Node<T> Left;
        public Node<T> Right;
        public Node<T> Parent;
        public T Value;
        public int Height;

        public int Balance()
        {
            int leftH = 0;
            int righH = 0;
            if(Left != null)
            {
                leftH = Left.Height;
            }
            if (Right != null)
            {
                righH = Right.Height;
            }
            int balance = leftH - righH;
            return balance;
        }

        public Node<T> FirstChild
        {
            get
            {
                if (Left != null) return Left;
                if (Right != null) return Right;
                return null;
            }
        }

        public int childCount;

        public bool IsLeftChild;
        public bool IsRightChild;

        public Node(T value, Node<T> parent = null)
        {
            Value = value;
            Parent = parent;
            Left = null;
            Right = null;
            Height = 1;
            childCount = 0;

        }
        
        
    }
}
