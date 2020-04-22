using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace UnionFind {

public class QuickUnion : IQuickUnion {
    
    public static readonly int TOP_ID = -1;
    public static readonly int BOTTOM_ID = -2;

    private Dictionary<int, Node> m_nodes;

    public int OpenNodesCnt {  get; private set; }

    public int Size { get; private set;}

    public int TotalAmount { get; private set;}

    public QuickUnion(int N) {  
        Size = N;
        TotalAmount = N*N;
        m_nodes = new Dictionary<int, Node>(N*N);
        OpenNodesCnt = 0;
        m_nodes[TOP_ID] = new Node(TOP_ID);  
        m_nodes[BOTTOM_ID] = new Node(BOTTOM_ID);
        for (var i = 0; i < N; i++) {
            for (var j = 0; j < N; j++) { 
                var id = GetId(i, j);
                m_nodes[id] = new Node(id);
                if (j == 0 || j == N - 1) { 
                    m_nodes[id].IsBoundary = true;
                }
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
                if (IsOpen(id)) {
                    Console.Write("[*]");
                } else  {
                    Console.Write("[ ]");
                }      
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    
    public void PrintPercolatedField() {
        Console.Clear();
        for (var i = 0; i < Size; i++) { 
            for (var j = 0; j < Size; j++) {
                var id = GetId(i, j);
                if (IsOpen(id) && GetRootId(id) == TOP_ID) {
                    Console.Write("[*]");
                } else  {
                    Console.Write("[ ]");
                }      
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void OpenRandom() {
         var id = RandomNumberGenerator.GetInt32(0, TotalAmount);
         while (IsOpen(id)) {
            id = RandomNumberGenerator.GetInt32(0, TotalAmount);
         }
         Open(id);
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
        
        OpenNodesCnt++;

        if (IsOpen(id + 1) && !m_nodes[id].IsBoundary) { 
            MakeUnion(id, id + 1);                     
        }
        if (IsOpen(id - 1) && !m_nodes[id].IsBoundary) { 
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
        if (id2 >= TotalAmount || id2 < 0) throw new ArgumentException("Неверное значение идентификатора ячейки");

        var p1RootId = GetRootId(id1);
        var p2RootId = GetRootId(id2);
        if (p1RootId == p2RootId) return;
        if ((m_nodes[p1RootId].Weight < m_nodes[p2RootId].Weight) 
            && p1RootId != TOP_ID) {
            m_nodes[p1RootId].Root = p2RootId;
            m_nodes[p2RootId].Weight += m_nodes[p1RootId].Weight;
        } else {
            m_nodes[p2RootId].Root = p1RootId;
            m_nodes[p1RootId].Weight += m_nodes[p2RootId].Weight;
        }
    }

    public int GetRootId(int id) {
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
