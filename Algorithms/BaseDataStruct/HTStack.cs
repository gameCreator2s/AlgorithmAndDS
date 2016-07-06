using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BaseDataStruct
{
    class HTStack<T>
    {
        //the test cod of  stack
        //HTStack<int> stack = new HTStack<int>();
        //for (int i = 0; i < 11; i++) {
        //    stack.Push(i);
        //}
        //stack.Pop();
        //stack.Pop();
        //Console.WriteLine(stack.GetTop());
        //Console.WriteLine(stack.ToString());

        const int stacksize = 10;
        int top = -1;
        T[] stackarray = new T[stacksize];

        public HTStack(){
            top = -1;
            //Console.Write("构造");
        }
        public T Pop() {
            if (top == -1) {
                return default(T);
            }
            return stackarray[top--];
        }

        public void Push(T t) {
            if (top == stackarray.Length - 1) {
                T[] temp = stackarray;
                stackarray = new T[stackarray.Length * 2];
                Array.Copy(temp, stackarray, temp.Length);
            }
            stackarray[++top] = t;
        }

        public T GetTop() {
            if (top == stackarray.Length - 1) {
                return default(T);
            }
            return stackarray[top];
        }

        public bool IsEmpty() {
            return top == -1 ? true : false;
        }
        public override string ToString()
        {
            string temp = "";
            for (int i = 0; i <=top; i++) {
                temp += stackarray[i]+" ";
            }
            return temp+" size="+stackarray.Length.ToString();
        }
        public int GetTopIndex() {
            return top;
        }
    }
}
