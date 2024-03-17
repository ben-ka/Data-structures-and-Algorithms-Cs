using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace percolation
{
    internal class Test
    {
        
        public Test(int lowPoint, int highPoint, int minActionsPrecentage)
        {

            int num1, num2;
            Random rand = new Random();
            int randAmount = rand.Next(lowPoint, highPoint);
            Console.WriteLine("Number of Nodes: " + randAmount); 

            int randActions = rand.Next(randAmount * (minActionsPrecentage/ 100), randAmount - 1);
            QuickUnionUF qu = new QuickUnionUF(randAmount);
            for (int i = 0; i < randActions; i++)
            {
                num1 = rand.Next(0, randAmount);
                num2 = rand.Next(0, randAmount);
                qu.union(num1, num2);
            }

            /*printArr(qu.GetSize(), qu.GetId(), qu.GetMax());*/

            //Console.WriteLine(qu.connected(0, 213));
            Console.WriteLine();
            Console.WriteLine("max: " + qu.findMax(0));
        }

        public static void printArr(int[] sz, int[] id, int[] max)
        {
            for (int i = 0; i < id.Length; i++)
            {
                Console.Write(id[i] + ", ");
            }
            Console.WriteLine(" sizes: ");
            for (int i = 0; i < sz.Length; i++)
            {
                Console.Write(sz[i] + ", ");
            }
            Console.WriteLine(" maxes: ");
            for (int i = 0; i < max.Length; i++)
            {
                Console.Write(max[i] + ", ");
            }
        }
    }
}
