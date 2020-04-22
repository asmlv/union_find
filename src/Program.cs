using System;
using System.Collections.Generic;
using System.Linq;

namespace UnionFind {

    class Program {
        public const int EXPERIMENT_COUNT = 1;

        static void Main(string[] args) {
            var qu = new QuickUnionUF(5);
            qu.Open(20);
            qu.Open(9);
            qu.Open(2);
            qu.Open(13);
            qu.Open(19);
            qu.Open(21);
            qu.Open(24);
            qu.Open(5);
            qu.Open(17);
            qu.Open(8);
            qu.Open(22);
            qu.Open(12);
            qu.Open(4);
            qu.PrintField();
        //    qu.PrintPercolatedField();
        /*
            //var N = int.Parse(args[0]);            
            var N = 5;
            var results = new List<double>(EXPERIMENT_COUNT);
            for (var i = 0; i < EXPERIMENT_COUNT; i++) { 
                var qu = new QuickUnionUF(N);
                while (true) {                   
                    qu.OpenRandom();  
                    if (qu.IsPercolate()) {
                        qu.PrintField();
                        qu.PrintPercolatedField();
                        results.Add(100 * ((double)qu.OpenNodesCnt / qu.TotalAmount));                        
                        break;                
                    }
                }       
            }           
            Console.WriteLine("Percolation threshold = " + results.Average()); */
        }
    }
}
