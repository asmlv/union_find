using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnionFind;
using Xunit;

namespace UnionFind.Test {
    public class Simulate {
        [Fact]
        public void RunSimulation() {
            var N = 1000;
            var results = new List<double>();
            for (var i = 0; i < 5; i++) { 
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
            
            Assert.InRange(results.Average(), 58.5, 59.5);
        }

    }
}
