using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace percolation
{
    internal class Percolation
    {
        
        private bool[] isOpen;
        private int countOpen;
        private QuickUnionUF qu;
        private int n;
        public bool[] isFull;

        public Percolation(int n) 
        {
            this.n = n;
            this.countOpen = 0;
            qu = new QuickUnionUF(n * n);
            
            isOpen = new bool[n * n];
            isFull = new bool[n * n];
            for (int i = 0; i < n * n; i++) 
            {
                isOpen[i] = false;
                isFull[i] = false;
            }
        }

        public void OpenSite(int x)
        {

            bool isLeft = false, isRight = false;
            if (!isOpen[x])
            {
                if(x % n == 0)
                {
                    isLeft = true;
                }
                if(x % n == n - 1)
                {
                    isRight = true;
                }


                bool isUnion = false;
                this.countOpen++;
                int i = 0;
                this.isOpen[x] = true;
                if (!isRight &&  isOpen[x + 1])
                {
                    isUnion = true;
                    qu.union(x, x + 1);
                }
                if (!isLeft && isOpen[x - 1])
                {
                    isUnion = true;
                    qu.union(x, x - 1);
                }
                if (x < n * n - n  && isOpen[x + this.n])
                {
                    isUnion = true;
                    qu.union(x, x + this.n);
                }
                if (x - n >= 0 && isOpen[x - this.n])
                {
                    isUnion = true;
                    qu.union(x, x - this.n);
                }
                if(x < this.n)
                {
                    isFull[x] = true;
                }
                if (isUnion)
                {
                    while (i < this.n && !isFull[x])
                    {
                        if (qu.connected(x, i))
                        {
                            isFull[x] = true;
                        }
                        i++;
                    }
                }

            }
        }

        public bool IsOpen(int x)
        {
            return isOpen[x];
        }

        public int numOpenSites()
        {
            return this.countOpen;
        }

        public bool isFullSite(int x)
        {
            return isFull[x];
        }

        public bool Percolates()
        {
            for (int i = n * n - n; i < n * n;i++)
            {
                if (isFullSite(i))
                {
                    return true;
                }
            }
            return false;
        }

        

    }
}
