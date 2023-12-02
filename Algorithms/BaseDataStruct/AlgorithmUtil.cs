using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BaseDataStruct
{
    /// <summary>
    /// 算法工具类，提供一些leetcode题目算法的函数
    /// </summary>
    class AlgorithmUtil
    {
        /// <summary>
        /// 返回一个序列里面的最大连续子序列的和，以及这个最大连续子序列在原序列里的起始索引和终点索引
        /// 最大连续子序列 一定是以原序列里某个节点为终点的，主要思路为：MaxSum(i) = Max( MasSum(i-1) + CurNode(i),CurNode(i))
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int[] GetMaxSum(int[] list)
        {
            if (list.Length == 0)
            {
                return null;
            }

            int[] allData = new int[] { 0, 0, 0 };
            int maxSum = list[0];
            int startIndex = 0;
            int endIndex = 0;

            int sum = 0;
            for (int i = 0; i < list.Length; i++)
            {
                sum += list[i];
                if (sum < list[i])
                {
                    sum = list[i];
                    startIndex = i;
                }
                if (maxSum < sum)
                {
                    maxSum = sum;
                    endIndex = i;
                }
            }

            allData[0] = maxSum;
            allData[1] = startIndex;
            allData[2] = endIndex;

            return allData;
        }

        

    }

    #region 
    //往一个有序的序列里 ，插入 一个单独的序列，查找某个数在序列里的索引，将另一个有序序列merge到之前的有序序列里并保持有序
    //原题：请你实现一个 无重叠的，按照区间起始端点排序的 区间列表类，实现如下接口:
    //1.Insert:在列表中插入一个新的区间，需要确保列表中的区间仍然有序且不重叠(如果有必要的话，可以合并区间)
    //2.Find:查找一个目标值所处的区间的内部索引
    //3.Merge: 将另外一个区间列表类实例的内容合并至本区间列表类实例
    //插入区间的示例:
    //示例 1:
    //输入: intervals = [[1,3],[6,9]],newlnterval =[2,5] 输出:[[1,5],[6,9]]
    //示例 2:输入: intervals =[[1,2],[3,5],[6,7].[8.10],[12.16]]newlnterval =[4.8] 输出:[[1.2].[3.10],[12,16]]解释:这是因为新的区间[4, 8] 与[3, 5][6,7] [8,10] 重叠。
    //示例 3:
    //输入: intervals = [], newlnterval =[5,7] 输出:[[5,7]]
    //示例 4:
    //输入: intervals =[[1,5]], newlnterval =[2,3]
    //        输出:[[1,5]]
    //示例 5:
    //输入: interval = [[1,5]], newlnterval = [[2,7]] 
    //  输出 [[1,7]]
    public class IntervalList
    {
        public void Test()
        {
            List<int[]> originList = new List<int[]>() { new int[] { 1, 3 }, new int[] { 6, 9 } };
        }

        public void Insert(List<int[]> originList, int[] targetValue)
        {
            if(originList.Count == 0)
            {
                originList.Add(targetValue);
                return;
            }
            int toReplaceFirstIndex = -1;
            int toReplaceSecondIndex = -1;

            int newOneValue = targetValue[0];
            int newTwoValue = targetValue[1];

            for (int i = 0; i < originList.Count; i++)
            {
                int oneValue = originList[i][0];
                int twoValue = originList[i][1];

                if (oneValue < newOneValue && newOneValue < twoValue)
                {
                    toReplaceFirstIndex = i;
                }
                else
                {
                    if (newOneValue < oneValue)
                    {

                    } else if (newOneValue > twoValue)
                    {

                    }
                }


                if (oneValue < newTwoValue && newTwoValue < twoValue)
                {
                    toReplaceSecondIndex = i;
                }

            }

            if(toReplaceFirstIndex == -1)//没有
            {

            }


        }
    }
    #endregion
}
