using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    class Tree<T> where T : IComparable<T>
    {
        public Node<T> Root;
        public int Count = 0;
        public int Balance = 0;

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
                Count++;
                return;
            }

            var current = Root;
            var prev = current;
            bool AddLeft = false;
            while (current != null)
            {
                prev = current;
                if (value.CompareTo(current.Value) >= 0)
                {
                    current.Height++;
                    current = current.Right;
                    AddLeft = false;
                }
                else
                {
                    current.Height++;
                    current = current.Left;
                    AddLeft = true;
                }

            }

            current = new Node<T>(value, prev);
            if (AddLeft)
            {
                prev.Left = current;
                
                Count++;
                Root = balanceTree(Root);
                return;
            }
            else
            {
                prev.Right = current;
                
                Count++;
                Root = balanceTree(Root);
                return;
            }
        }
        /*
        public void TreeBalance()
        {
            if (Root.Height >= 3)
            {
                Left(Root);
                Root.Balance();
            }
            else if (Root.Height >= -3)
            {
                Right(Root);
                Root.Balance();
            }
        }
        public void Left(Node<T> node)
        {
            if(node.Parent == null)
            {
                return;
            }
            if (node.Height >= 2)
            {
                node.Left = node.Parent;
                node.Left = node.Parent.Left;
                node.Right = node.Parent.Right;
                node.Parent.Left = node.Left;
            }
            
        }
        public void Right(Node<T> node)
        {
            if (node.Parent == null)
            {
                return;
            }
            if (node.Height <= -2)
            {
                node.Right = node.Parent;
                node.Right = node.Parent.Right;
                node.Left = node.Parent.Left;
                node.Parent.Right = node.Right;
            }
        }*/
        public Node<T> balanceTree(Node<T> node)
        {
            int height = balanceFac(node);
            if(height > 1)
            {
                if(balanceFac(node.Left) >0)
                {
                    node = LeftLeft(node);
                }
                else
                {
                    node = LeftRight(node);
                }
            }
            else if(height < -1)
            {
                if(balanceFac(node) > 0)
                {
                    node = RightLeft(node);
                }
                else
                {
                    node = RightRight(node);
                }
            }
            return node;
        }

        public int balanceFac(Node<T> node)
        {
            int left = 0;
            if(node.Left != null)
            {
                left = node.Left.Height;
            }
            int right = 0;
            if(node.Right != null)
            {
                right = node.Right.Height;
            }
            int bFac = left - right;
            return bFac;
        }

        public Node<T> RightRight(Node<T> parent)
        {
            Node<T> temp = parent.Right;
            temp.Parent = parent.Parent;
            parent.Right = temp.Left;
            temp.Left = parent.Left;
            parent.Parent = temp;
            return temp;
        }

        public Node<T> LeftLeft(Node<T> parent)
        {
            Node<T> temp = parent.Left;
            temp.Parent = parent.Parent;
            parent.Left = temp.Right;
            temp.Right = parent.Right;
            parent.Parent = temp;

            return temp;
        }

        public Node<T> LeftRight(Node<T> parent)
        {
            Node<T> temp = parent.Left;
            parent.Left = RightRight(temp);
            return LeftLeft(parent);
        }

        public Node<T> RightLeft(Node<T> parent)
        {
            Node<T> temp = parent.Right;
            parent.Right = LeftLeft(temp);
            return RightRight(parent);
        }

        public bool remove(T value)
        {
            var current = Root;
            while(current != null)
            {
                if(value.CompareTo(current.Value) == 0)
                {
                    Delete(current);
                    Count--;
                    return true;
                }
                if(value.CompareTo(current.Value)>=0)
                {
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }
            return false;
        }
        public void Delete(Node<T> node)
        {
            if (node.childCount == 0)
            {
                if (node.IsLeftChild)
                {
                    node.Parent.Left = null;
                }
                else if (node.IsRightChild)
                {
                    node.Parent.Right = null;
                }
                else
                {
                    Root = null;
                }
            }
            else if (node.childCount == 1)
            {
                
                if (node.IsLeftChild)
                {
                    node.Parent.Left = node.FirstChild;
                    node.FirstChild.Parent = node.Parent;
                }
                else if (node.IsRightChild)
                {
                    node.Parent.Right = node.FirstChild;
                    node.FirstChild.Parent = node.Parent;
                }
                else
                {
                    Root = node.FirstChild;
                    Root.Parent = null;
                }
            }
            else if(node.childCount == 2)
            {
                var temp = min(node.Right);
                node.Value = temp.Value;
                Delete(temp);
            }

        }
        private Node<T> min(Node<T> node)
        {
            while(node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }
        private Node<T> max(Node<T> Node)
        {
            while(Node.Right != null)
            {
                Node = Node.Right;
            }
            return Node;
        }
        public void BreadthS()
        {
            Func(Root);
            void Func(Node<T> node)
            {
                Console.WriteLine(node.Value);
                if(node.Left != null)
                {
                    Func(node.Left);
                }
                if(node.Right != null)
                {
                    Func(node.Right);
                }
            }
        }
    }
}
