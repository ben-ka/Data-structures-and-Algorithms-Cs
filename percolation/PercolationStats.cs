using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace percolation
{
    internal class PercolationStats
    {

        private Random rand;
        private double mean;
        
        public PercolationStats(int n, int trials) 
        {
            rand = new Random(); int num_of_cells, rand_num;
            double sum = 0;
            for (int i = 0; i < trials; i++)
            {
                Percolation percolation = new Percolation(n);
                Console.Write(i + "  ");
                while (percolation.Percolates() == false)
                {
                    rand_num = rand.Next(0, n * n);
                    percolation.OpenSite(rand_num);
                }
                num_of_cells = percolation.numOpenSites();
                sum += num_of_cells;

            }
            this.mean = sum / trials;
        }

        public double GetMean()
        {
            return this.mean;
        }
    }
}
