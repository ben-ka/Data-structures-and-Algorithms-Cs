using System;

namespace DynamicProgramming
{
    public class IncreasingSubsequence
    {
        // a function that gets an array of integers and returns the count of the longest increasing subsequence
        static int LongestIncreasingSubsequence(int[] arr)
        {
            int max_sub = 1;
            int[] counts = new int[arr.Length];
            for (int i = 0; i < counts.Length; i++){
                counts[i] = 1;
            }
            for (int i = 1; i < counts.Length; i++)
            {
                for(int j = 0 ; j < i; j++)
                {
                    if(arr[j] < arr[i]){
                        counts[i] = Math.Max(counts[i], counts[j] + 1);
                    }    
                }
            }
            for(int i = 0; i < counts.Length; i++){
                max_sub = Math.Max(max_sub, counts[i]);
            }
            return max_sub;
        }


    }
}

