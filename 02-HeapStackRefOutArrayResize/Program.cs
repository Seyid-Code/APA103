//namespace _02_HeapStackRefOutArrayResize
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello, World!");
//        }
//    }
//}

//----------------------------------------------------------------------------------------------------------------------

//using System;

//class Program
//{
//    static int[] CustomArrResize(int[] numbers, params int[] nums)
//    {
//        int[] result = new int[numbers.Length + nums.Length];

//        for (int i = 0; i < numbers.Length; i++)
//        {
//            result[i] = numbers[i];
//        }

//        for (int i = 0; i < nums.Length; i++)
//        {
//            result[numbers.Length + i] = nums[i];
//        }

//        return result;
//    }

//    static void Main()
//    {
//        int[] numbers = { 1, 2, 3 };

//        int[] result = CustomArrResize(numbers, 4, 5, 6, 7);

//        foreach (int n in result)
//        {
//            Console.Write(n + " ");
//        }
//    }
//}