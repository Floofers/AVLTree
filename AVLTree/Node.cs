﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    [DebuggerDisplay("Value={Value};")]
    class Node<T>
    {
        public Node<T> Left;
        public Node<T> Right;
        public Node<T> Parent;
        public T Value;
        public int Height;

        

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
