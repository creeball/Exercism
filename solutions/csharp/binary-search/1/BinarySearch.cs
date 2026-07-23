public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        if (input.Length == 0) return -1;
        int indexA = 0;
        int indexB = input.Length - 1;
        int index;
        while (true)
        {
            index = (indexA + indexB) / 2;
            if (index == indexA || index == indexB)
            {
                if (input[indexA] == value) index = indexA;
                else if (input[indexB] == value) index = indexB;
                else index = -1;
                break;
            }
            if (input[index] == value) break;
            if (input[index] > value) indexB = index;
            else indexA = index;
        }
        return index;
    }
}