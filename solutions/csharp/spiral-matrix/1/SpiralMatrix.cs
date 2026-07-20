public class SpiralMatrix
{
    private static (int, int) NextDirection((int, int) direction)
    {
        return direction switch
        {
            (1, 0) => (0, 1),
            (0, 1) => (-1, 0),
            (-1, 0) => (0, -1),
            _ => (1, 0)
        };
    }
    public static int[,] GetMatrix(int size)
    {
        int[,] square = new int[size, size];
        (int row, int col) position = (-1, 0);
        (int row, int col) direction = (0, -1);
        int counter = 0;
        int times = 1;
        for (int steps = size; steps > 0; steps--)
        {
            while (times-- > 0)
            {
                direction = NextDirection(direction);
                for (int step = 0; step < steps; step++)
                {
                    counter++;
                    position = (position.row + direction.row, position.col + direction.col);
                    square[position.col, position.row] = counter;
                }
            }
            times = 2;
        }
        return square;
    }
}