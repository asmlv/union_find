using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind {
public class QuickUnionUF {
    
    private readonly int TOP_ID = -1;
    private readonly int BOTTOM_ID = -2;

    private Dictionary<int, Node> m_nodes;
    private Node m_firstNode, m_lastNode;

    public HashSet<int> OpenNodes { get; private set;}

    public int Size { get; private set;}
    public int TotalAmount { get; private set;}

    public QuickUnionUF(int N) {  
        Size = N;
        TotalAmount = N*N;
        m_nodes = new Dictionary<int, Node>();
        OpenNodes = new HashSet<int>(N);
        m_firstNode = new Node(TOP_ID);  
        m_lastNode = new Node(BOTTOM_ID);
        m_nodes[TOP_ID] = m_firstNode;
        m_nodes[BOTTOM_ID] = m_lastNode;
        for (var i = 0; i < N; i++) {
            for (var j = 0; j < N; j++) { 
                var id = GetId(i, j);
                m_nodes[id] = new Node(id);
                m_nodes[id].X = j;
                if (i == 0) {
                    MakeUnion(TOP_ID, id);
                } else if (i == N - 1) {
                    MakeUnion(BOTTOM_ID, id);
                }

            }
        }
    }

    public bool IsPercolate() {
        return AreConnected(TOP_ID, BOTTOM_ID);
    }

    public void PrintField() {
        Console.Clear();
        for (var i = 0; i < Size; i++) { 
            for (var j = 0; j < Size; j++) {
                var id = GetId(i, j);
                m_nodes[id].Print();
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    
    public bool AreConnected(int id1, int id2) {  
        return GetRootId(id1) == GetRootId(id2);
    }

    public bool IsOpen(int id) {
        if (id >= TotalAmount || id < 0) return false;
        return m_nodes[id].IsOpen;
    }

    public void Open(int id) {
        if (IsOpen(id)) return;

        m_nodes[id].IsOpen = true;
        var x = m_nodes[id].X;

        OpenNodes.Add(id);

        if (IsOpen(id + 1) && x != Size) { 
            MakeUnion(id, id + 1);
        }
        if (IsOpen(id - 1) && x != 0) { 
            MakeUnion(id, id - 1);
        }
        if (IsOpen(id - Size)) { 
            MakeUnion(id, id - Size);
        }
        if (IsOpen(id + Size)) { 
            MakeUnion(id, id + Size);
        }
    }

    private void MakeUnion(int id1, int id2) {
        if (id2 >= TotalAmount || id2 < 0) return;
        var p1RootId = GetRootId(id1);
        var p2RootId = GetRootId(id2);
        if (p1RootId == p2RootId) return;
        if (m_nodes[p1RootId].Weight < m_nodes[p2RootId].Weight) {
            m_nodes[p1RootId].Root = p2RootId;
            m_nodes[p2RootId].Weight += m_nodes[p1RootId].Weight;
        } else {
            m_nodes[p2RootId].Root = p1RootId;
            m_nodes[p1RootId].Weight += m_nodes[p2RootId].Weight;
        }
    }

    private int GetRootId(int id) {
       while (id != m_nodes[id].Root) {
            m_nodes[id].Root = m_nodes[m_nodes[id].Root].Root;
            id = m_nodes[id].Root;
       }
        return id;
    }
    
    private int GetId(int i, int j) {
        return i * Size + j;
    }

    
}

}
