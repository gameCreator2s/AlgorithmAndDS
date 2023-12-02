using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BaseDataStruct
{
    class SortUtil
    {
        public void PrintList(List<int> list)
        {
            string content = "";
            for(int i = 0; i < list.Count; i++)
            {
                content += "," + list[i].ToString();
            }
            Console.WriteLine(content);
        }

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
            //        break;
            //    }
            //    originList[i + 1] = value;
            //}
            Console.WriteLine("插入前：");
            PrintList(originList);

            //理解上面的内容，插入排序即从原始列表里，从第2个值开始不断往之前的序列里插入
            //平均时间复杂度n的平方,如果待排序序列已经有序，插入过程无需遍历寻找插入点，则时间复杂度为n

            //将插入有序序列的位置
            int j = 0;
            for(int i= 1; i < originList.Count; i++)//待插入部分
            {
                int toInsertValue = originList[i];
                for(j = i - 1; j >= 0 ; j--)
                {
                    if (originList[j] > toInsertValue)
                    {
                        originList[j + 1] = originList[j];
                    }
                    else
                    {
                        break;
                    }
                }
                //处理上面break或者有序序列的值都比待插入值大的情况，统一这里填入插入值
                originList[j+1] = toInsertValue;

            }
            Console.WriteLine("插入后：" );
            PrintList(originList);
        }

        /// <summary>
        /// 希尔排序
        /// 不断将带排序序列分组排序 每组都按直接插入排序操作，直到整个分组有序，分组间隔每次都为 listLen/2,直到间隔为1为止
        /// 平均时间复杂度nlogn
        /// </summary>
        /// <param name="list"></param>

        public void SheelSort(List<int> originList)
        {
            PrintList(originList);
            int length = originList.Count;

            int delta = length / 2;
            int j = 0;
            while(delta >= 1)
            {
                //同插入排序算法，只是序列的间隔要处理
                for(int i = delta; i < length; i++)//这里i的起始值其实就是为这组待排序的序列的各个值之间的间隔值，如果是普通插入，间隔为1，则从1开始，希尔排序则从间隔值delta开始
                {
                    int toInsertValue = originList[i];
                    for(j= i - delta; j >= 0; j -= delta)
                    {
                        if(originList[j] > toInsertValue)
                        {
                            originList[j + delta] = originList[j];
                        }
                        else
                        {
                            break;
                        }
                    }
                    originList[j + delta] = toInsertValue;
                }
                delta /= 2;
            }
            PrintList(originList);
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
