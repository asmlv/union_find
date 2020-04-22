namespace UnionFind {
    interface IQuickUnion {
        // Печать всего поля с очисткой консоли  
        void PrintField();

        // Печать поля только с протекающими ячейками
        void PrintPercolatedField();

        // Проверка, протекает ли система
        bool IsPercolate();

        // Открыть случайную ячейку в системе 
        void OpenRandom();
    }
}
