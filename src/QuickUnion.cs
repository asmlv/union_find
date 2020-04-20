using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind {
public class QuickUnionUF {

    private List<Node> m_nodes;
    public int Size { get; private set;}

    public QuickUnionUF(int N) {  
        Size = N;
        m_nodes = new List<Node>(N*N);
        for (var i = 0; i < N; i++) {
            for (var j = 0; j < N; j++) { 
                var id = GetId(i, j);
                m_nodes.Add(new Node(id));
                m_nodes[id].Root = id;
                m_nodes[id].Weight = 1;
            }
        }
    }

    public void PrintField() {
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
        return m_nodes[id].IsOpen;
    }

    public void MakeUnion(int id1, int id2) {
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
        m_nodes[p2RootId].IsOpen = true;
        m_nodes[p1RootId].IsOpen = true;
    }

    private int GetRootId(int id) {
        var tmp = m_nodes[id].Root;
        while (id != tmp) {
            tmp = m_nodes[tmp].Val;
            id = tmp;
        }
        return id;
    }
    
    private int GetId(int i, int j) {
        return i * Size + j;
    }

    
}

}
