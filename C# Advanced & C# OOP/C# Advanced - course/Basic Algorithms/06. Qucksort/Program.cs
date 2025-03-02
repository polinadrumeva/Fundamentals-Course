﻿using System;
using System.Linq;

namespace _06._Qucksort
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            QuickSort(numbers, 0, numbers.Length - 1);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void QuickSort(int[] numbers, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = start;
            var left = start + 1;
            var right = end;

            while (left <= right)
            {
                if (numbers[left] > numbers[pivot] && numbers[right] < numbers[pivot])
                {
                    Swap(numbers, left, right);
                }
                if (numbers[left] <= numbers[pivot])
                {
                    left++;
                }
                if (numbers[right] >= numbers[pivot])
                {
                    right--;
                }

            }

            Swap(numbers, pivot, right);
            QuickSort(numbers, start, right - 1);
            QuickSort(numbers, right + 1, end);

        }

        private static void Swap(int[] numbers, int first, int second)
        {
            int current = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = current;
        }
    }
}
