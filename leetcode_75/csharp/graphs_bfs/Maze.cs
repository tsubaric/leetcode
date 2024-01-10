public class Maze {
    private int[][] _directions;
    private int _rowLength = 0;
    private int _columnLength = 0;
    private char ValidSymbol = '.';

    public Maze()
    {
        _directions = new int[4][];
        _directions[0] = new[] { 0, 1 };
        _directions[1] = new[] { 1, 0 };
        _directions[2] = new[] { 0, -1 };
        _directions[3] = new[] { -1, 0 };
    }

    class PlayerMove
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public int Steps { get; set; }

        public bool IsFirstStep { get; set; }

        public PlayerMove(int row, int column, int steps, bool isFirstStep = false)
        {
            Row = row;
            Column = column;
            Steps = steps;
            IsFirstStep = isFirstStep;
        }
    }
    
    public int NearestExit(char[][] maze, int[] entrance)
    {
        _rowLength = maze.Length;
        _columnLength = maze[0].Length;
        
        var seen = new bool[_rowLength, _columnLength];
        var queue = new Queue<PlayerMove>();

        seen[entrance[0], entrance[1]] = true;
        queue.Enqueue(new PlayerMove(entrance[0], entrance[1], 0, true));

        while (queue.Count != 0)
        {
            var current = queue.Dequeue();
            if (IsExit(current))
            {
                return current.Steps;
            }

            foreach (var direction in _directions)
            {
                var nextRow = current.Row + direction[0];
                var nextColumn = current.Column + direction[1];

                if (IsValid(nextRow, nextColumn, maze) && !seen[nextRow, nextColumn])
                {
                    seen[nextRow, nextColumn] = true;
                    queue.Enqueue(new PlayerMove(nextRow, nextColumn, current.Steps + 1));
                }
            }
        }
        
        return -1;
    }
    
    bool IsExit(PlayerMove playerMove)
    {
        return !playerMove.IsFirstStep &&
               ((playerMove.Row == 0 || playerMove.Row == _rowLength - 1) ||
                (playerMove.Column == 0 || playerMove.Column == _columnLength - 1));
    }

    bool IsValid(int row, int column, char[][] maze)
    {
        return row >= 0 && row < _rowLength && column >= 0 && column < _columnLength &&
               maze[row][column] == ValidSymbol;
    }
}

using System;

class Program
{
    static void Main()
    {
        Maze mazeObj = new Maze();

        // Example 1
        char[][] maze1 = {
            new[] { "+", "+", ".", "+" },
            new[] { ".", ".", ".", "+" },
            new[] { "+", "+", "+", "." }
        };
        int[] entrance1 = { 1, 2 };
        int result1 = mazeObj.NearestExit(maze1, entrance1);
        Console.WriteLine("Output 1: " + result1);

        // Example 2
        char[][] maze2 = {
            new[] { "+", "+", "+" },
            new[] { ".", ".", "." },
            new[] { "+", "+", "+" }
        };
        int[] entrance2 = { 1, 0 };
        int result2 = mazeObj.NearestExit(maze2, entrance2);
        Console.WriteLine("Output 2: " + result2);

        // Example 3
        char[][] maze3 = {
            new[] { ".", "+" }
        };
        int[] entrance3 = { 0, 0 };
        int result3 = mazeObj.NearestExit(maze3, entrance3);
        Console.WriteLine("Output 3: " + result3);
    }
}
