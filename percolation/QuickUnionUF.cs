using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace percolation
{
    internal class QuickUnionUF
    {
        private int[] id;
        private int[] sz;
        private int[] max;
        public QuickUnionUF(int n)
        {
            id = new int[n];
            sz = new int[n];
            max = new int[n];
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
                sz[i] = 1;
                max[i] = i;
            }

        }

        public void union(int p, int q)
        {
            int rootQ = findRoot(q);
            int rootP = findRoot(p);
            if (rootP == rootQ)
                return;

            int highest = Math.Max(max[rootQ], max[rootP]);

            if (sz[rootQ] < sz[rootP])
            {
                id[rootQ] = rootP;
                sz[rootP] += sz[rootQ];
                sz[rootQ] = 0;
                max[rootP] = highest;
                max[rootQ] = -999;
            }

            else
            {
                id[rootP] = rootQ;
                sz[rootQ] += sz[rootP];
                sz[rootP] = 0;
                max[rootQ] = highest;
                max[rootP] = -999;
            }




        }

        public bool connected(int p, int q)
        {
            return findRoot(q) == findRoot(p);
        }



        // gets the index of the number in the array and returns its root
        private int findRoot(int x)
        {
            int father = id[x];

            while (father != id[father])
            {
                this.id[x] = id[id[father]];
                father = id[father];
            }
            //this.id[x] = this.id[father];
            return father;
        }


        public int findMax(int i)
        {
            int root = findRoot(i);
            return max[root];
        }

        public int[] GetSize()
        {
            int[] copy = new int[this.sz.Length];
            for (int i = 0; i < this.sz.Length; i++)
            {
                copy[i] = this.sz[i];
            }
            return copy;
        }

        public int[] GetId()
        {
            int[] copy = new int[this.id.Length];
            for (int i = 0; i < this.id.Length; i++)
            {
                copy[i] = this.id[i];
            }
            return copy;
        }

        public int[] GetMax()
        {
            int[] copy = new int[this.max.Length];
            for (int i = 0; i < this.max.Length; i++)
            {
                copy[i] = this.max[i];
            }
            return copy;
        }

        public void SetId(int i, int num)
        {
            this.id[i] = num;
        }
    }
}
