using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BaseDataStruct
{
    class SortUtil
    {
        /// <summary>
        /// 直接插入排序
        /// 每次从未排序序列中取出一个元素，然后将它插入到已排序序列中，直到整个序列完全有序
        /// </summary>
        public void InsertSort(List<int> originList)
        {
            //理解如何往一个有序序列里插入数值，
            //如果从左往右插[即从小到大]，则遇到的第一个比插入值大的值的位置即为插入点
            //如果从右往左插[即从大到小]，则遇到的第一个比插入值小的值的位置即为插入点
            //因为插入需要将插入值后面的原值往后移，故一般都是从大往小插，可以边比较边把值往后移
            //eg:示例从大往小插
            //for(int i = originList.Count - 1; i >=0; i--)
            //{
            //    if(originList[i] > value)
            //    {
            //        originList[i + 1] = originList[i];
            //    }
            //    else
            //    {
            //        originList[i + 1] = value;
            //    }
            //}

            Console.WriteLine("插入前：" + originList.ToString());

            //理解上面的内容，插入排序即从原始列表里，从第2个值开始不断往之前的序列里插入
            //平均时间复杂度n的平方,如果待排序序列已经有序，插入过程无需遍历寻找插入点，则时间复杂度为n

            //标志已经排好序的序列长度
            int sortedListLen = 1;
            for(int i= 1; i < originList.Count; i++)//待插入部分
            {
                int toInsertValue = originList[i];
                for(int j = sortedListLen-1; j >= 0 ; j--)
                {
                    if (originList[j] > value)
                    {
                        originList[j + 1] = originList[j];
                    }
                    else
                    {
                        originList[j + 1] = value;
                    }
                }
                sortedListLen++;
            }
            Console.WriteLine("插入后：" + originList.ToString());
        }

        public void MaoPaoSort(List<int> orginList, int toCompareCnt)
        {
            if (toCompareCnt > orginList.Count || toCompareCnt== 0)
            {
                return;
            }
            int startIndex = 0;

            for (int i = 0; i < toCompareCnt; i++)
            {
                if(orginList[startIndex]> orginList[i])
                {
                    int temp = orginList[startIndex];
                    orginList[startIndex] = orginList[i];
                    orginList[i] = orginList[startIndex];

                    startIndex = i;
                }
                else
                {
                    startIndex = i;
                }
            }

        }
    }
}
