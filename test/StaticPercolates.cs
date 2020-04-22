using System;
using UnionFind;
using Xunit;

namespace UnionFind.Test {
    public class StaticPercolates {
        [Fact]
        public void CheckIfPercolates() {
            var qu = new QuickUnion(6);
            Assert.False(qu.IsPercolate());
            qu.Open(1);
            Assert.False(qu.IsPercolate());
            qu.Open(2);
            Assert.False(qu.IsPercolate());
            qu.Open(6);
            Assert.False(qu.IsPercolate());
            qu.Open(8);
            Assert.False(qu.IsPercolate());
            qu.Open(12);
            Assert.False(qu.IsPercolate());
            qu.Open(14);
            Assert.False(qu.IsPercolate());
            qu.Open(18);
            Assert.False(qu.IsPercolate());
            qu.Open(19);
            Assert.False(qu.IsPercolate());
            qu.Open(20);
            Assert.False(qu.IsPercolate());
            qu.Open(23);
            Assert.False(qu.IsPercolate());
            qu.Open(24);
            Assert.False(qu.IsPercolate());
            qu.Open(29);
            Assert.False(qu.IsPercolate());
            qu.Open(34);
            Assert.False(qu.IsPercolate());
            qu.Open(35);
            Assert.False(qu.IsPercolate());
            qu.Open(21);
            Assert.False(qu.IsPercolate());
            qu.Open(22);
            Assert.True(qu.IsPercolate());
        }

    }
}
