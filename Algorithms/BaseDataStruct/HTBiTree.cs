using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BaseDataStruct
{
    //binary tree
    //二叉树
    class HTBiTree<T>
    {
        class Node<T> {
            public Node(T data) {
                this.Data = data;
            }
            public T Data
            {
                get;
                set;
            }
            public Node<T> leftchild;
            public Node<T> rightchild;
            public int identity = 0;
        }
        Node<T> root;

        public HTBiTree(T[] content)//按照层序顺序构建
        {
            HTQueue<Node<T>> queue=new HTQueue<Node<T>>();
            int len=content.Length;
            int index=1;
            if (len > 0)
            {
                root = new Node<T>(content[index - 1]);
                queue.EnQueue(root);
            }
            else
                return;
            Node<T> temp=null;
            while(!queue.IsEmpty()){
                temp=queue.DeQueue();
                if (2 * index <= len) {
                    temp.leftchild = new Node<T>(content[2*index-1]);
                    queue.EnQueue(temp.leftchild);
                }
                if (2 * index+1 <= len)
                {
                    temp.rightchild = new Node<T>(content[2 * index]);
                    queue.EnQueue(temp.rightchild);
                }
                index++;
            }
        }
        public void PreOrderTraverse()
        {
            PreOrderTraverse(root);
        }
        public void InOrderTraverse() {
            InOrderTraverse(root);   
        }

        public void PostOrderTraverse() {
            PostOrderTraverse(root);
        }

        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <param name="root"></param>
        private void PreOrderTraverse(Node<T> root) {
            if (root == null)
                return;
            HTStack<Node<T>> stack = new HTStack<Node<T>>();
            while (root != null || !stack.IsEmpty()) {
                while (root != null) {
                    Console.WriteLine(root.Data);
                    stack.Push(root);
                    root = root.leftchild;
                }
                if (!stack.IsEmpty()) {
                    root = stack.Pop().rightchild;
                }
            }
        }

        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="root"></param>
        private void InOrderTraverse(Node<T> root) {
            HTStack<Node<T>> stack = new HTStack<Node<T>>();
            while (root != null || !stack.IsEmpty()) {
                while (root != null) {
                    stack.Push(root);
                    root = root.leftchild;
                }
                if (!stack.IsEmpty()) {
                    root = stack.Pop();
                    Console.WriteLine(root.Data);
                    root = root.rightchild;
                }
            }
        }

        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="root"></param>
        private void PostOrderTraverse(Node<T> root) {
            HTStack<Node<T>> stack = new HTStack<Node<T>>();
            while (root != null || !stack.IsEmpty()) {
                while (root != null) {
                    if (root.identity != 2)
                    {
                        root.identity ++;
                        stack.Push(root);
                        root = root.leftchild;
                    }
                }
                while (!stack.IsEmpty() && stack.GetTop().identity == 2) {
                    root = stack.Pop();
                    Console.WriteLine(root.Data);
                }
                if (!stack.IsEmpty()) {
                    stack.GetTop().identity++;
                    root = stack.GetTop().rightchild;
                }
            }
        }
    }
}
