using System.Diagnostics;

namespace percolation
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
             int GRIDLENGTH = 10;
             int TESTS = 250;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            PercolationStats ps = new PercolationStats(GRIDLENGTH   , TESTS);
            stopwatch.Stop();
            Console.WriteLine(ps.GetMean()/ (GRIDLENGTH * GRIDLENGTH));
            Console.WriteLine("Time taken: " + stopwatch.Elapsed.TotalSeconds + " seconds");

        }
    }
}