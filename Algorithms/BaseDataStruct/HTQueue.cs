using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BaseDataStruct
{
    class HTQueue<T>
    {
        //test queue
        //HTQueue<int> queue = new HTQueue<int>();
        //for (int i = 0; i < 11; i++) {
        //    queue.EnQueue(i);
        //}
        //Console.WriteLine(queue.ToString());
        //for (int i = 0; i < 11; i++) {
        //    queue.DeQueue();
        //}
        //Console.WriteLine(queue.ToString());






        class Node<T> {
            public T data;
            public Node<T> next;
            public Node() : this(default(T), null)
            {

            }
            public Node(T t, Node<T> n) {
                data = t;
                next = n;
            }
            
        }
        Node<T> head;
        Node<T> rear;
        public HTQueue(){
            head = new Node<T>();
            rear = head;
        }

        public void EnQueue(T t) {
            Node<T> temp = new Node<T>(t,null);
            rear.next = temp;
            rear = temp;
        }

        public T DeQueue() {
            if (head.next == null) {
                Console.WriteLine("queue is null");
                throw new IndexOutOfRangeException();
            }
            Node<T> temp = head.next;
            head.next = temp.next;
            if (head.next == null) {
                rear = head;
            }
            return temp.data;
        }

        public bool IsEmpty() {
            return head == rear ? true : false;
        }
        public override string ToString()
        {
            string temp = "";
            Node<T> tem=head.next;
            int count = 0;
            while(tem!=null){
                temp += tem.data.ToString() + " ";
                count++;
                tem = tem.next;
            }
            return temp + " size=" + count.ToString();
        }

        
    }
}
