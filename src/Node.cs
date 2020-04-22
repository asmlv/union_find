using System;

namespace UnionFind {
    public class Node {
        
        public Node(int id) {
            Id = id;
            Root = id;
            Weight = 1;
            IsOpen = false;
            IsFilled = false;
        }

        public readonly int Id;
        public int Weight, Root;
        public bool IsBoundary;
        public bool IsOpen, IsFilled;
    }
}
