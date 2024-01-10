public class Oranges {
    public int OrangesRotting(int[][] grid) {
        Queue<IList<int>> rottenOranges = new Queue<IList<int>>();
        int time = 0, freshOranges = 0;

        int rows = grid.Length, cols = grid[0].Length;
        for(int row = 0; row < rows; row++) {
            for(int col = 0; col < cols; col++) {
                if(grid[row][col] == 1) freshOranges++;
                else if(grid[row][col] == 2) rottenOranges.Enqueue(new List<int> { row, col });
            }
        }

        var directions = new List<IList<int>> {
            new List<int> { 1, 0 },
            new List<int> { -1, 0 },
            new List<int> { 0, 1 },
            new List<int> { 0, -1 }
        };
        while(rottenOranges.Count > 0 && freshOranges > 0) {
            int size = rottenOranges.Count;

            for(int ind = 0; ind < size; ind++) {
                var inds = rottenOranges.Dequeue();
                int row = inds[0];
                int col = inds[1];

                foreach(var dir in directions) {
                    int rowInd = row + dir[0];
                    int colInd = col + dir[1];

                    if(rowInd < 0 || rowInd >= rows ||
                       colInd < 0 || colInd >= cols ||
                       grid[rowInd][colInd] != 1) continue;

                    grid[rowInd][colInd] = 2;
                    rottenOranges.Enqueue(new List<int> { rowInd, colInd });
                    freshOranges--;
                }
            }

            time++;
        }

        return freshOranges == 0 ? time : -1;
    }
}