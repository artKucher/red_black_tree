using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    class Node<T>
    {
        public Node<T> NextLeft; 
        public Node<T> NextRight;
        public Node<T> Parent;

        public bool isRed = true;

        public T data;
        public int key;
        public int count;

        public Node(int key)
        {
            this.key = key;
            this.count = 1;
        }

        public Node(int key, Node<T> parent) : this(key)
        {
            this.Parent = parent;
        }

    }
}
