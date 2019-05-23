using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    class RBTree<T>
    {
        public Node<T> root;


        public RBTree(Node<T> root)
        {
            this.root = root;
            this.root.isRed = false;
        }

        protected Node<T> addNode(Node<T> to, int key)
        {
            if (key == to.key)
            {
                to.count++;
                return to;
            }

            if (key < to.key)
            {
                if (to.NextLeft != null)
                    return this.addNode(to.NextLeft, key);

                return to.NextLeft = new Node<T>(key, to);
            }
            else
            {
                if (to.NextRight != null) //там уже есть элемент
                    return this.addNode(to.NextRight, key);

                return to.NextRight = new Node<T>(key, to);
            }
        }

        public Node<T> Add(int key)
        {
            Node<T> n = this.addNode(this.root, key);
            this.case1(ref n);
            if (this.root.Parent != null)
                this.root = root.Parent;
            return n;
        }

        protected void case1(ref Node<T> n)
        {
            if (n.Parent == null)
            {
                n.isRed = false;
            }
            else
            {
                this.case2(ref n);
            }
        }

        protected void case2(ref Node<T> n)
        {
            if (n.Parent.isRed == false)
            {
                return;
            }
            else
                this.case3(ref n);
        }

        protected void case3(ref Node<T> n)
        {
            Node<T> u = this.uncle(n);

            if ((u != null) && (u.isRed)) { 
                n.Parent.isRed = false;
                u.isRed = false;
                Node<T> g = grandparent(n);
                g.isRed = true;
                this.case1(ref g);
            }
            else
                this.case4(ref n);
            }
        protected void case4(ref Node<T> n)
        {
            Node<T> g = grandparent(n);

            if (n==n.Parent.NextRight && n.Parent == g.NextLeft)
            {
                rotate_left(ref n.Parent);
                n = n.NextLeft;
            }
            else if(n==n.Parent.NextLeft && n.Parent == g.NextRight)
            {
                rotate_right(ref n.Parent);
                n = n.NextRight;
            }
            case5(ref n);

        }
        protected void case5(ref Node<T> n)
        {
            Node<T> g = grandparent(n);
            n.Parent.isRed = false;
            n.isRed = true;
            if(n==n.Parent.NextLeft && n.Parent == g.NextLeft)
            {
                rotate_right(ref g);
            }
            else
            {
                rotate_left(ref g);
                g.isRed = true;
            }
        }

     

        protected void rotate_right(ref Node<T> no)
        {
            Node<T> pivot = no.NextLeft;
            Node<T> n = no;
            pivot.Parent = no.Parent;
            if(n.Parent!= null)
            {
                if (n.Parent.NextLeft == n)
                    n.Parent.NextLeft = pivot;
                else
                    n.Parent.NextRight = pivot;
            }

            n.NextLeft = pivot.NextRight;
            if (pivot.NextRight != null)
                pivot.NextRight.Parent = n;

            n.Parent = pivot;

            pivot.NextRight = n;
        }

        //поворот влево
        protected void rotate_left(ref Node<T> no)
        {
            Node<T> pivot = no.NextRight;
            Node<T> n = no;
            pivot.Parent = no.Parent;
            if(n.Parent != null)
            {
                if (n.Parent.NextLeft == n)
                    n.Parent.NextLeft = pivot;
                else
                    n.Parent.NextRight = pivot;
            }
            n.NextRight = pivot.NextLeft;
            if (pivot.NextLeft != null)
                pivot.NextLeft.Parent = n;
            n.Parent = pivot;
            pivot.NextLeft = n;
        }

      

        protected Node<T> grandparent(Node<T> n)
        {
            if ((n != null) && (n.Parent != null))
                return n.Parent.Parent;
            else
                return null;
        }



      
        protected Node<T> uncle(Node<T> n)
        {
            Node<T> g = grandparent(n);
            if (g == null)
                return null;
            if (n.Parent == g.NextLeft)
                return g.NextRight;
            else
                return g.NextLeft;
        }

        public Node<T> Find(int key, Node<T> root)
        {
            if (root.key == key) return root;
            if (key < root.key) return Find(key, root.NextLeft);
            else return Find(key, root.NextRight);

        }


    }
}

