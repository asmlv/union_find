
namespace UnionFind {
    public class Node {
        
        public Node(int rootId) {
            Root = rootId;
            Weight = 1;
            IsOpen = false;
        }

        public int Weight, Root;
        public bool IsBoundary;
        public bool IsOpen;
    }
}
