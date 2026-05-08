public class Solution {
    public void Solve(char[][] board)
    {
        var queue = new Queue<(int y, int x, char desiredValue)>();

        for (int y = 0; y < board.Length; y++)
        {
            char[] row = board[y];
            for (int x = 0; x < row.Length; x++)
            {
                char value = board[y][x];

                if (value != 'O')
                {
                    // only start searches at an island tile
                    continue;
                }

                bool isSurrounded = this.DfsCheckIsSurrounded(board, y: y, x: x);
                if (isSurrounded)
                {
                    // set surrounded islands to X (currently marked as visited)
                    queue.Enqueue((y: y, x: x, 'X'));
                }
                else
                {
                    // set border islands back to O (currently marked as visited)
                    queue.Enqueue((y: y, x: x, 'O'));
                }
            }
        }

        // Actually do the changes from visited at the end so we don't process islands more than once
        while (queue.Any())
        {
            (int y, int x, char desiredValue) = queue.Dequeue();

            this.DfsReplaceVisited(board, y: y, x: x, desiredValue: desiredValue);
        }
    }

    private void DfsReplaceVisited(char[][] board, int y, int x, char desiredValue)
    {
        if (y < 0 ||
            y >= board.Length)
        {
            return;
        }

        char[] row = board[y];

        if (x < 0 ||
            x >= row.Length)
        {
            return;
        }
        
        char value = board[y][x];

        // only look at visited ones from DfsCheckIsSurrounded
        if (value != 'V')
        {
            return;
        }

        // update value to desired
        board[y][x] = desiredValue;

        // recurse
        this.DfsReplaceVisited(board, y - 1, x, desiredValue); // down
        this.DfsReplaceVisited(board, y + 1, x, desiredValue); // up
        this.DfsReplaceVisited(board, y, x - 1, desiredValue); // left
        this.DfsReplaceVisited(board, y, x + 1, desiredValue); // right
    }


    // 'X' represents water
    // 'O' represents un-visited land
    // 'V' represents land visited in this loop - marked temporarily, we don't know yet
    // 'E' represents land that we have confirmed is connected to the edge of the board - its group is not surrounded

    // return value is 'isSurrounded', true if this path was surrounded, false if it hit an edge
    private bool DfsCheckIsSurrounded(char[][] board, int y, int x)
    {
        if (y < 0 ||
            y >= board.Length)
        {
            return false;
        }

        char[] row = board[y];

        if (x < 0 ||
            x >= row.Length)
        {
            return false;
        }

        char value = board[y][x];

        switch (value)
        {
            case 'X':
            case 'V':
                // assume surrounded by default
                return true;

            case 'E':
                // hit an edge
                return false;

            case 'O':
                // Mark as visited to prevent cycles
                board[y][x] = 'V';

                ReadOnlySpan<(int y, int x)> stack =
                [
                    (y - 1, x), // down
                    (y + 1, x), // up
                    (y, x - 1), // left
                    (y, x + 1), // right
                ];

                // recurse
                foreach ((int y, int x) neighbor in stack)
                {
                    bool branchIsSurrounded = this.DfsCheckIsSurrounded(board, y: neighbor.y, x: neighbor.x);

                    if (!branchIsSurrounded)
                    {
                        // if found edge, it overrides everything
                        return false;
                    }
                }

                return true;


            default:
                throw new NotImplementedException($"Unexpected value '{value}' from position y={y}, x={x}");
        }
    }
}