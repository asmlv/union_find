using System;

namespace UnionFind {
    public class Node {
        
        public Node(int val) {
            Val = val;
        }

        public int Val { get; }
        public int Weight, Root;
        public bool IsOpen;

        public void Print() {
            if (IsOpen) {
                Console.Write($"{Val, 4}*");
            } else  {
                Console.Write($"{Val, 5}");
            }
        }

    }
}
