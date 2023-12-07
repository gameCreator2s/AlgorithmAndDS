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
            //bitree.PostOrderTraverse();

            SortUtil sortUtil = new SortUtil();
            List<int> toSortList = new List<int> { 30,3, 1, 4,19, 19, 5, 9, 6 ,22};
            //sortUtil.InsertSort(toSortList);
            //sortUtil.SheelSort(toSortList);
            //sortUtil.BubbleSort(toSortList);
            //sortUtil.QuickSort(toSortList, 0, toSortList.Count - 1);
            //sortUtil.SelectSort(toSortList);
            sortUtil.MergeSort(toSortList);
            Console.ReadLine();
        }
    }
}
