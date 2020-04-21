﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace UnionFind {

    class Program {
        public const int EXPERIMENT_COUNT = 10;

        static void Main(string[] args) {
            var N = int.Parse(args[0]);
            var results = new List<double>(EXPERIMENT_COUNT);
            for (var i = 0; i < EXPERIMENT_COUNT; i++) { 
                var qu = new QuickUnionUF(N);
                while (true) {
                    var id = RandomNumberGenerator.GetInt32(0, qu.TotalAmount);
                    qu.Open(id);  
                    if (qu.IsPercolate()) {
                        results.Add(100 * ((double)qu.OpenNodes.Count / qu.TotalAmount));                        
                        break;                
                    }
                }       
            }
            
            Console.WriteLine("Percolation threshold = " + results.Average());
        }
    }
}
