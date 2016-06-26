using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BaseDataStruct
{
    class HTQueue<T>
    {
        class Node<T> {
            public T data;
            public Node<T> next;
        }
        Node<T> head = null;
        Node<T> rear = null;
        public void EnQueue(T t) { 
            
        }

        public T DeQueue() {
            if (head == null)
                throw new Exception();
            Node<T> temp = head;
            head = head.next;
            return temp.data;

        }

        
    }
}
