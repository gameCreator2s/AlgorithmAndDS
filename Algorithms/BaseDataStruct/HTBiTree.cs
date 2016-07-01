using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BaseDataStruct
{
    //binary tree
    class HTBiTree<T>
    {
        class Node<T> {
            public T Data
            {
                get;
                set;
            }
            public Node<T> leftchild;
            public Node<T> rightchild;
        }
        Node<T> root;

        public HTBiTree() { 
            
        }
        public void PreOrderTraverse() {
            PreOrderTraverse(root);
        }
        public void InOrderTraverse() {
            InOrderTraverse(root);   
        }

        public void PostOrderTraverse() {
            PostOrderTraverse(root);
        }

        private void PreOrderTraverse(Node<T> root) {
            HTStack<Node<T>> stack = new HTStack<Node<T>>();
            if (root == null)
                return;
            Console.WriteLine(root.Data);
            stack.Push(root);
            while (!stack.IsEmpty()) { 
                
            }
        }
        private void InOrderTraverse(Node<T> root) { 
            
        }

        private void PostOrderTraverse(Node<T> root) { 
            
        }
    }
}
