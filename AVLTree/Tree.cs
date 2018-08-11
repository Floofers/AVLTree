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
                    current = current.Right;
                    AddLeft = false;
                }
                else
                {
                    current = current.Left;
                    AddLeft = true;
                }

            }

            current = new Node<T>(value, prev);
            if (AddLeft)
            {
                prev.Left = current;
                current.Height = getHeight(current);
                Count++;
                Root = balanceTree(Root);
                return;
            }
            else
            {
                prev.Right = current;
                current.Height = getHeight(current);
                Count++;
                Root = balanceTree(Root);
                return;
            }
        }

        public Node<T> balanceTree(Node<T> node)
        {
            int height = getHeight(node);

            int lH = getHeight(node.Left);
            int rH = getHeight(node.Right);

            int balance = lH - rH;

            if (balance > 1)
            {
                LeftLeft(node);

                //rotate right
            }
            else if (balance < -1)
            {
                RightRight(node);
                //rotate left
            }

            return node;
        }


        

        public Node<T> RightRight(Node<T> parent)
        {
            Node<T> temp = parent.Right;
            parent.Right = temp.Left;
            temp.Left = parent;
            temp.Parent = parent.Parent;
            parent.Parent = temp;
            return temp;
        }
        public Node<T> LeftLeft(Node<T> parent)
        {
            Node<T> temp = parent.Left;
            parent.Left = temp.Right;
            temp.Right = parent;
            temp.Parent = parent.Parent;
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

        public bool Remove(T value)
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

        private void Delete(Node<T> node)
        {
            if (node.childCount == 0)
            {
                if (node.Parent.Left != null)
                {
                    node.Parent.Left = null;
                }
                else if (node.Parent.Right != null)
                {
                    node.Parent.Right = null;
                }
                node = null;
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
        private int getHeight(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else if (node.Left == null && node.Right == null)
            {
                return 1;
            }
            else
            {
                if (node.Left == null)
                {
                    return getHeight(node.Right) + 1;
                }
                else if (node.Right == null)
                {
                    return getHeight(node.Left) + 1;
                }
                else
                {
                    int lH = getHeight(node.Left);
                    int rH = getHeight(node.Right);
                    if (rH >= lH)
                    {
                        return rH + 1;
                    }
                    else
                    {
                        return lH + 1;
                    }
                }
            }
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
