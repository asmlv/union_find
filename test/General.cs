using System;
using UnionFind;
using Xunit;

namespace UnionFind.Test {
    public class General {
        [Fact]
        public void ConnectTwoNodes() {
            int N = 3;
            var qu = new QuickUnion(N);            
            qu.Open(1);
            qu.Open(2);
            Assert.True(qu.AreConnected(1, 2));
            Assert.True(qu.AreConnected(2, 1));
        }

        [Fact]
        public void CheckIfOpen() {
            int N = 3;
            var qu = new QuickUnion(N);            
            qu.Open(1);
            qu.Open(2);
            Assert.True(qu.IsOpen(1));
            Assert.True(qu.IsOpen(2));
        }

        [Fact]
        public void CheckParent() {
            var qu = new QuickUnion(5);
            qu.Open(20);
            qu.Open(23);
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
            Assert.Equal(QuickUnion.TOP_ID, qu.GetRootId(4));
            Assert.Equal(QuickUnion.TOP_ID, qu.GetRootId(8));
            Assert.Equal(QuickUnion.TOP_ID, qu.GetRootId(9));
        }
    }
}
