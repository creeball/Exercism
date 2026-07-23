public class Matrix
{
    private int[][] Array { get; set; }
    public Matrix(string input)
    {
        Array = input
            .Split('\n')
            .Select(r => r
                .Split(' ')
                .Select(int.Parse)
                .ToArray())
            .ToArray();
    }

    public int[] Row(int row)
    {
        return Array[row - 1];
    }
    
    public int[] Column(int col)
    {
        int[] arr = new int[Array.Length];
        for (int i = 0; i < Array.Length; i++)
            arr[i] = Array[i][col - 1];
        return arr;
    }
}