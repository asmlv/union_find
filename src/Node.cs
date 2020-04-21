using System;

namespace UnionFind {
    public class Node {
        
        public Node(int id) {
            Id = id;
            Root = id;
            Weight = 1;
            IsOpen = false;
        }

        public readonly int Id;

        public int Weight, Root;
        public int X;
        public bool IsOpen;

        public void Print() {
            if (IsOpen) {
                Console.Write($"[*]");
            } else  {
                Console.Write($"[ ]");
            }
        }

    }
}
