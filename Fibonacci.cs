using System.Collections.Generic;
public class Fibonacci
{
    // testing function
    static void Main(string[] args){
        System.Console.WriteLine(DynamicProgrammingMemoizationFib(45));
    }


    // recursive non efficient way to check n'th number of fibonacci

hello
    static int RecursiveSlowFib(int n){
        if(n <= 1)
        {
            return n;
        }
        return RecursiveSlowFib(n - 1) + RecursiveSlowFib(n - 2);
    }


    // dynamic programming using dictionary and memoization way to check n'th number of fibonacci
    static int DynamicProgrammingMemoizationFib(int n)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i <= n; i++)
        {
            dict.Add(i, -1);
        }

        return RecFib(n, dict);

        static int RecFib(int n, Dictionary<int, int> dict)
        {
            if (dict[n] != -1)
            {
                return dict[n];
            }

            
            if (n <= 1)
            {
                dict[n] = n;
            }
            else
            {
                dict[n] = RecFib(n - 1, dict) + RecFib(n - 2, dict);
            }

            return dict[n];
        }
    }



    // dynamic programming using dictionary and tabulation way to check n'th number of fibonacci

    static int DynamicProgrammingTabulationFib(int n)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        dict.Add(0, 0);
        dict.Add(1, 1);
        for(int i = 2; i <= n; i++){
            dict.Add(i, dict[i - 1] + dict[i - 2]);
        }
        return dict[n];

    }

    
}
