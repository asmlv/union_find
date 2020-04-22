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
            var N = 200;
            var results = new List<double>();
            for (var i = 0; i < 100; i++) { 
                var qu = new QuickUnion(N);
                while (true) {
                    var id = RandomNumberGenerator.GetInt32(0, qu.TotalAmount);
                    qu.Open(id);  
                    if (qu.IsPercolate()) {
                        results.Add(100 * ((double)qu.OpenNodesCnt / qu.TotalAmount));                        
                        break;                
                    }
                }       
            }
            
            Assert.InRange(results.Average(), 59.1, 59.5);
        }

    }
}
