/*Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
 * The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
 * You must write an algorithm that runs in O(n) time and without using the division operation.
 * Example 1:
    * Input: nums = [1,2,3,4]
    * Output: [24,12,8,6]
 * Example 2:
    * Input: nums = [-1,1,0,-3,3]
    * Output: [0,0,9,0,0]*/

namespace CCAD16_Assignment6_2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //test case 1
            int[] nums = { 1, 2, 3, 4 };

            //test case 2
            //int[] nums = { -1, 1, 0, -3, 3 };

            //print original array
            Console.WriteLine("Original array: [" + string.Join(", ", nums) + "]");

            //new array being called
            int[] result = ArrayProduct(nums);

            //print new array
            Console.WriteLine("Output of new array: [" + string.Join(", ", result) + "]");
        }

        static int[] ArrayProduct(int[] nums)
        {
            int[] answer = new int[nums.Length];

            // Compute prefix products directly into the result array
            answer[0] = 1; // No elements to the left of the first element
            for (int i = 1; i < nums.Length; i++)
            {
                answer[i] = answer[i - 1] * nums[i - 1];
            }

            // Compute suffix products on the fly and multiply with prefix products in the result array
            int suffixProduct = 1; // No elements to the right of the last element
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                answer[i] = answer[i] * suffixProduct;
                suffixProduct = suffixProduct * nums[i];
            }

            return answer;
        }
    }
}
