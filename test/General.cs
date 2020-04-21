using System;
using UnionFind;
using Xunit;

namespace UnionFind.Test {
    public class General {
        [Fact]
        public void ConnectTwoNodes() {
            int N = 3;
            var qu = new QuickUnionUF(N);            
            qu.Open(1);
            qu.Open(2);
            Assert.True(qu.AreConnected(1, 2));
            Assert.True(qu.AreConnected(2, 1));
        }

        [Fact]
        public void CheckIfOpen() {
            int N = 3;
            var qu = new QuickUnionUF(N);            
            qu.Open(1);
            qu.Open(2);
            Assert.True(qu.IsOpen(1));
            Assert.True(qu.IsOpen(2));
        }
    }
}
