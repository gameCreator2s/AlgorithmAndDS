using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.BaseDataStruct;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] content = new int[] { 1,2,3,4,5,6,7};
            HTBiTree<int> bitree = new HTBiTree<int>(content);
            //bitree.PreOrderTraverse();
            //bitree.InOrderTraverse();
            bitree.PostOrderTraverse();
            Console.ReadLine();
        }
    }
}
