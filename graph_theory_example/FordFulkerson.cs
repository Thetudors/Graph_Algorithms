using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_theory_example
{
   public class FordFulkerson
    {

        public int[,] cap;

        public void fordF(int n, int s, int t)
        {
            int flow = 0;
            int[] prev = new int[n];

            int[,] fnet = new int[n, n];

            while (true)
            {


                for (int i = 0; i < n; i++)
                {
                    prev[i] = -1;
                    Queue<int> q = new Queue<int>();
                    prev[s] = -2;
                    q.Enqueue(s);

                    while (q.Count != 0 && prev[t] == -1)
                    {
                        int u = q.Dequeue();

                        for (int v = 0; v < n; v++)
                        {
                            if (prev[v] == -1)
                            {
                                if (fnet[v, u] > 0 || fnet[u, v] < cap[u, v])
                                {
                                    prev[v] = u;
                                    q.Enqueue(v);
                                }

                            }

                        }

                    }

                }


                if (prev[t] == -1)
                {
                    break;

                }

                int bot = 10000;
                for (int v = t, u = prev[v]; u >= 0; v = u, u = prev[v])
                {
                    //Geek Hub
                    if (fnet[v, u] > 0)
                    {
                        bot = Math.Min(bot, fnet[u, v]);
                    }
                    else
                    {
                        bot = Math.Min(bot, cap[u, v] - fnet[u, v]);
                    }

                }

                for (int v = t, u = prev[v]; u >= 0; v = u, u = prev[v])
                {

                    //Geek Hub
                    if (fnet[v, u] > 0)
                    {
                        fnet[v, u] -= bot;
                    }
                    else
                    {
                        fnet[u, v] += bot;
                    }

                }


                flow += bot;


            }

            System.Windows.Forms.MessageBox.Show("Maksimum akış (FordFulkerson) :" + flow);


        }
    }





}

