using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BaseDataStruct
{
    /// <summary>
    /// 排序相关算法
    /// 里面关于需要传递序列起始终点索引的，都是传递有效索引，比如长度为3的序列，起始为0，终点为2
    /// </summary>
    class SortUtil
    {
        public void PrintList(List<int> list,string preFix = "")
        {
            string content = preFix+ "\n";
            for(int i = 0; i < list.Count; i++)
            {
                content += (i== 0 ? DateTime.Now.ToString() + "===" + list[i].ToString() : "," + list[i].ToString());
            }
            Console.WriteLine(content);
        }

        public long PrintTimeStamp(string title = "时间戳:",bool toMS =true)
        {
            long TO_MS = 10000;
            long TO_SEC = 10000000;
            var time = DateTime.Now.Ticks / TO_MS;
            Console.WriteLine(title + "\n" + time.ToString());
            return time;
        }

        /// <summary>
        /// 插入排序
        /// 每次从未排序序列中取出一个元素，然后将它插入到已排序序列中，直到整个序列完全有序,是在有序序列里去做比较插入的
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
            PrintList(originList, "插入前：");

            //理解上面的内容，插入排序即从原始列表里，从第2个值开始不断往之前的序列里插入
            //平均时间复杂度n的平方,如果待排序序列已经有序，插入过程无需遍历寻找插入点，则时间复杂度为n

            //将插入有序序列的位置
            int j = 0;
            for(int i= 1; i < originList.Count; i++)//待插入部分
            {
                int toInsertValue = originList[i];
                for(j = i - 1; j >= 0 ; j--)//有序序列部分，待插入值依次跟有序序列里的值比对，更大的后移，否则插入
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
            PrintList(originList, "插入后：");
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

        /// <summary>
        /// 冒泡排序
        /// 可以从小往大排，也可从大往小排，这里实现前者
        /// 将整个初始的序列看做是一个无序区，每次选出一个最大值后，即将此最大值加入有序区，直到整个序列有序（此时整个序列都是有序区）
        /// 每次选出序列中最大的值放到序列最后，重复这个遍历比较的过程，直到有序
        /// 因为每趟从无序区中选出一个最大值，需要n-1趟，故平均时间复杂度 n的平方
        /// </summary>
        /// <param name="originList"></param>
        public void BubbleSort(List<int> originList)
        {
            PrintList(originList);
            //需要排序的无序列表长度
            int toSortLen = originList.Count;
            //int curMaxValue =0;

            int i;
            while(toSortLen > 1)//最后一个数不用比了，肯定是最小的那个
            {
                for (i = 0; i < toSortLen -1; i++)//i最大只为 toSortLen -1，第toSortLen个值这趟比较结束后就是这趟最大值了
                {
                    if(originList[i]> originList[i + 1])
                    {
                        //curMaxValue = originList[i];
                        int temp = originList[i + 1];
                        originList[i+1] = originList[i];
                        originList[i] = temp;
                    }
                    //else if (originList[i] < originList[i + 1])
                    //{
                    //    curMaxValue = originList[i + 1];
                    //}
                }
                //i这里是比较完了的无序区最大索引(因为上面的for循环是在i== toSortLen -1 时退出的,toSortLen每趟比较下来都要减一)
                toSortLen = i;
                //最大值填入这趟得到的有序区第一个位置  冒泡排序是稳定排序，找到了更大的值时交换就已经把对应的值放到对应的位置了，不需要最后这里还设置一次
                //originList[i] = curMaxValue;
            }
            PrintList(originList);
        }

        /// <summary>
        /// 快速排序
        /// 又称为 分区交换排序（ partition-exchange sort ），用到了 分治法 思想，通过对序列进行划分，来降低问题规模. 适用于待排序记录个数很大且原始记录随机排列的情况
        /// 每趟比较，轴值左侧发现比轴值大的 或者 轴值右侧发现比轴值小的  都与轴值进行交换，更新轴值索引和 交换后的的对应侧索引(左侧索引++,右侧索引--,直到 左右侧索引==轴值索引），然后再对轴值2侧序列递归执行通用的比较步骤，直到各个序列大小为1，整体有序
        /// 这里的实现是以左右2个序列的比较值来充当轴值的，故只需要让左右2个序列对应值比较直到都移动到轴值处，一趟排序就算结束
        /// 每趟比较需要遍历 待比较序列大小的次数 n，选定轴值将需要比较的趟数变为logn,故平均时间复杂度为nlogn
        /// </summary>
        /// <param name="originList"></param>
        /// <param name="end">为列表最后一个可读的索引</param>
        public void QuickSort(List<int> originList,int start,int end)
        {
            if(start >= end)
            {
                PrintList(originList,"最终列表");
                return;
            }
            //左序列索引
            int i = start;
            //右序列索引
            int j = end;

            while (i < j)
            {
                //此处实现轴值默认选在了start处，故先从右往左比对，此时轴值在i,j不断左移去跟轴值比较
                //这里面的while也要加上i<j的条件，因为j不断左移，可能>=i,越界了
                while(i<j && originList[i] <= originList[j])
                {
                    j--;
                }
                if (i < j)//i<j才是需要交换位置，相等的话证明比较结束了
                {
                    int temp = originList[j];
                    originList[j] = originList[i];
                    originList[i] = temp;
                    i++;
                }

                //从左往右,此时轴值在j，i不断右移去跟轴值比较
                while(i<j && originList[i] <= originList[j])
                {
                    i++;
                }
                if (i < j)
                {
                    int temp = originList[j];
                    originList[j] = originList[i];
                    originList[i] = temp;
                    j--;
                }
            }
            //Console.WriteLine("固定轴：" + i + "===" + originList[i]);
            //PrintList(originList);
            //左侧递归
            QuickSort(originList, start, i-1);
            //右侧递归
            QuickSort(originList, j+1, end);
        }

        /// <summary>
        /// 选择排序
        /// 将待排序序列划分成有序和无序区，每趟在无序序列里每次选出一个最小值，插入有序序列中
        /// 平均时间复杂度n的平方
        /// </summary>
        /// <param name="originList"></param>
        public void SelectSort(List<int> originList)
        {
            //有序区每趟插入新的值的插入点
            int toInsertIndex = 0;
            while (toInsertIndex < originList.Count)
            {
                for (int i = toInsertIndex; i < originList.Count; i++)
                {
                    if (originList[toInsertIndex] > originList[i])
                    {
                        int temp = originList[i];
                        originList[i] = originList[toInsertIndex];
                        originList[toInsertIndex] = temp;
                    }
                }
                toInsertIndex++;
            }
            PrintList(originList, "最终列表:");
        }

        /// <summary>
        /// 堆排序
        /// 简单选择排序的改进。将待排序的记录序列构造成一个堆（假设用大根堆实现），此时，选出了堆中所有记录的最大者即堆顶记录。
        /// 移走堆顶记录，将剩余的记录调整成堆，找出次大记录。以此类推，直到堆中只有一个记录为止。
        /// 从一个无序序列建堆的过程就是一个反复筛选的过程。因为此序列就是一个完全二叉树的顺序存储，则所有的叶子结点都已经是堆。
        /// 所以只需从第n/2个记录(即最后一个分支结点)开始，执行上述筛选过程，直到根结点。
        /// 堆排序传递进来的数组看做是无序的序列，且此序列是完全二叉树的层序存储序列
        /// 平均时间复杂度 nlogn
        /// </summary>
        /// <param name="originList"></param>
        public void HeapSort(List<int> originList)
        {

        }

        /// <summary>
        /// 归并排序
        /// 也是采用分治法，将若干个有序序列进行两两归并，直至所有待排序记录都在一个有序序列为止
        /// 为了达到将若干有序序列俩俩归并，需要将初始待排序序列进行划分
        /// （分治法，分解成多个子问题，子问题规模更小，解决难度更低，各个子问题解决后再合并解决最初的问题），从每个序列都只有1个数据记录开始合并
        /// 因为一个序列只有一个数据的话则默认就有序了
        /// 对这些原子序列俩俩合并（即递归调用归并排序)直到序列有序),这里划分不是一定要真的对序列划分成物理上的多个子序列而是通过索引范围在原序列上操作
        /// 需要用一个跟待排序序列相同大小的列表作为临时空间存放排序的中间结果
        /// 平均时间复杂度 nlogn
        /// </summary>
        /// <param name="originList"></param>
        public void MergeSort(List<int> originList)
        {
            PrintList(originList);
            List<int> tempList = new List<int>(originList);
            //子序列划分粒度
            int subListLen = 1;
            while(subListLen < originList.Count)//最多拆到2个序列，2个序列合并完就结束了
            {
                MergeSortTraverse(originList,tempList, subListLen);
            PrintList(tempList);
                subListLen *= 2;
            }
            originList = tempList;
            PrintList(originList);
        }

        /// <summary>
        /// 按照给定的 子序列长度，遍历合并处理各个子序列
        /// </summary>
        public void MergeSortTraverse(List<int> originList,List<int> tempList,int subListLen)
        {
            int originListCount = originList.Count;
            int index = 0;
            //每次循环需要处理2个长度为subListLen的子序列，index表示2个待合并连续子序列的起始索引，故index最大只能为 originListCount - 2 * subListLen
            //注意最后一个序列可能不够subListLen长度
            while (index<= originListCount - 2 * subListLen)
            {
                MergeSortToMerge(originList, tempList, index, index + subListLen,index +2 * subListLen - 1);
                //下2个序列的起始索引
                index += 2 * subListLen;
            }
            //最后一个序列长度不够subListLen(注意这里不能等于，否则就把只剩一个序列的情况也包含了,只剩一个不能通过toMerge合并)
            if(index < originListCount - subListLen)
            {
                MergeSortToMerge(originList, tempList, index, index + subListLen,originListCount - 1);
            }
            else//只剩一个序列，直接合入
            {
                for(int k = index; k < originListCount; k++)
                {
                    tempList[k] = originList[k];
                }
            }
            PrintList(tempList, "temp:::");
        }

        /// <summary>
        /// 归并排序的归并
        /// 用于将原始序列中指定范围的2个有序序列合并
        /// 这里只做合并 ，不对范围做合法判断
        /// </summary>
        /// <param name="originList"></param>
        /// <param name="firstStart">2个待合并序列在原序列中的起始索引</param>
        /// <param name="secondStart">第2个待合并序列在原序列中的起始索引</param>
        /// <param name="secondEnd">第2个待合并序列在原序列中的结束索引</param>
        public void MergeSortToMerge(List<int> originList,List<int> tempList,int firstStart,int secondStart,int secondEnd)
        {
            //待合并的第一个序列起始索引
            int firstListIndex = firstStart;
            //待合并的第二个序列起始索引
            int secondListIndex = secondStart;
            //合入临时序列的起始索引
            int mergeIndex = firstStart;
            
            while(firstListIndex <= secondStart - 1 && secondListIndex <= secondEnd)
            {
                if(originList[firstListIndex] < originList[secondListIndex])
                {
                    tempList[mergeIndex++] = originList[firstListIndex++];
                }
                else
                {
                    tempList[mergeIndex++] = originList[secondListIndex++];
                }
            }

            //第二个序列合完了，第一个直接合到后面
            if(firstListIndex <= secondStart - 1)
            {
                for (int k = firstListIndex; k < secondStart; k++)
                {
                    tempList[k] = originList[k];
                }
            }
            else//第一个序列合完了，第二个直接合到后面
            {
                for (int k = secondListIndex; k <= secondEnd; k++)
                {
                    tempList[k] = originList[k];
                }
            }
        }

    }
}
