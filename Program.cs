using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Prim
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialization();
            Prim();
            Output();
            Console.ReadLine();
        }
        
        // Struct
        struct Edge
        {
            public int u, v;
        };

        // Variables
        static int[,] graph; // do thi
        static List<int> MST; // cay khung nho nhat, danh sach cac dinh, tap V moi
        static List<Edge> EDGE; // Danh sach canh trong cay khung

        // Prim algorithm
        static void Prim()
        {
            int u = -1, v = -1; // canh (u,v)
            int min; // trong so min
            int n = graph.GetLength(0); // so dinh cua do thi
            
            // b1: bat dau tu 1 dinh x bat ky, cho vao tap V
            int x = 3; // bat dau tu x
            MST.Add(x);

            // b2: lap cho toi khi |Vmoi| = |V|
            while(MST.Count != n)
            {
                min = int.MaxValue;

                // tim (u,v) co trong so nho nhat. u thuoc V moi, v khong thuoc V moi
                foreach (int i in MST)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (MST.Contains(j)) continue;
                        if (graph[i, j] != 0 && graph[i, j] < min)
                        {
                            min = graph[i, j];
                            u = i; v = j;
                        }
                    }
                }

                MST.Add(v);
                Edge e = new Edge();
                e.u = u; e.v = v;
                EDGE.Add(e);
            }
        }

        static void Initialization()
        {
            //graph = new int[,]
            //{
            //    {0,5,0,3,0},
            //    {5,0,0,8,10},
            //    {0,0,0,7,0},
            //    {3,8,7,0,1},
            //    {0,10,0,1,0}
            //};

            graph = new int[,] 
            {
                {0,7,0,5,0,0,0},
                {7,0,8,9,7,0,0},
                {0,8,0,5,0,0,0},
                {5,9,0,0,15,6,0},
                {0,7,5,15,0,8,9},
                {0,0,0,6,8,0,11},
                {0,0,0,0,9,11,0}
            };
            MST = new List<int>();
            EDGE = new List<Edge>();
        }

        static void Output()
        {
            Console.Write("Danh sach dinh: ");
            foreach (int i in MST)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
 
            Console.Write("Danh sach canh: ");
            foreach (Edge e in EDGE)
            {
                Console.Write("({0}, {1}) ", e.u, e.v);
            }
        }
    }
}
