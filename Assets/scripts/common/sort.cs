using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class sort {

	public static List<uint> sortUintByCost(List<uint> list)
	{
		int lowIndex = 0;                                       //数组的起始位置（从0开始）
		int highIndex = list.Count - 1;         //数组的终止位置

		//快速排序
		QuickSortFunction(list, lowIndex, highIndex);
		return list;
	}

	//快速排序（目标数组，数组的起始位置，数组的终止位置）
	private static void QuickSortFunction(List<uint> array, int low, int high)
	{

		try
		{
			int keyValuePosition;   //记录关键值的下标

			//当传递的目标数组含有两个以上的元素时，进行递归调用。（即：当传递的目标数组只含有一个元素时，此趟排序结束）
			if (low < high)
			{
				keyValuePosition = keyValuePositionFunction(array, low, high);  //获取关键值的下标（快排的核心）

				QuickSortFunction(array, low, keyValuePosition - 1);    //递归调用，快排划分出来的左区间
				QuickSortFunction(array, keyValuePosition + 1, high);   //递归调用，快排划分出来的右区间
			}
		}
		catch (Exception ex)
		{
			Debug.LogError(ex);
		}
	}

	//快速排序的核心部分：确定关键值在数组中的位置，以此将数组划分成左右两区间，关键值游离在外。（返回关键值应在数组中的下标）
	public static int keyValuePositionFunction(List<uint> array, int low, int high)
	{
		int leftIndex = low;        //记录目标数组的起始位置（后续动态的左侧下标）
		int rightIndex = high;      //记录目标数组的结束位置（后续动态的右侧下标）

		int keyValue = Convert.ToInt16(Data.data.card[array[low]]["cost"].ToString());  //数组的第一个元素作为关键值
		uint temp = 0;

		//当 （左侧动态下标 == 右侧动态下标） 时跳出循环
		while (leftIndex < rightIndex)
		{
			while (leftIndex < rightIndex && Convert.ToInt16(Data.data.card[array[leftIndex]]["cost"].ToString()) <= keyValue)  //左侧动态下标逐渐增加，直至找到大于keyValue的下标
			{
				leftIndex++;
			}

			while (leftIndex < rightIndex && Convert.ToInt16(Data.data.card[array[rightIndex]]["cost"].ToString()) > keyValue)  //右侧动态下标逐渐减小，直至找到小于或等于keyValue的下标
			{
				rightIndex--;
			}
			if (leftIndex < rightIndex)
			{  //如果leftIndex < rightIndex，则交换左右动态下标所指定的值；当leftIndex==rightIndex时，跳出整个循环
				temp = array[leftIndex];
				array[leftIndex] = array[rightIndex];
				array[rightIndex] = temp;
			}
		}


		//当左右两个动态下标相等时（即：左右下标指向同一个位置），此时便可以确定keyValue的准确位置
		temp = array[low];
		if (Convert.ToInt16(Data.data.card[array[low]]["cost"].ToString()) < Convert.ToInt16(Data.data.card[array[rightIndex]]["cost"].ToString()))   //当keyValue < 左右下标同时指向的值，将keyValue与rightIndex - 1指向的值交换，并返回rightIndex - 1
		{
			array[low] = array[rightIndex - 1];
			array[rightIndex - 1] = temp;
			return rightIndex - 1;
		}
		else //当keyValue >= 左右下标同时指向的值，将keyValue与rightIndex指向的值交换，并返回rightIndex
		{
			array[low] = array[rightIndex];
			array[rightIndex] = temp;
			return rightIndex;
		}
	}

}
