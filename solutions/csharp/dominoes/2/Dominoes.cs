public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int Left, int Right)> dominoes)
    {
        var dominoesList = dominoes.ToList();
        return dominoesList.Count == 0 || Check(dominoesList, dominoesList.First().Left);
    }
    private static bool Check(List<(int Left, int Right)> dominoesList, int firstNum, int lastNum = -1)
    {
        if (dominoesList.Count == 0) return firstNum == lastNum;
        for (int i = 0; i < dominoesList.Count; i++)
        {
            var checkedDomino = dominoesList[i];
            if (TryMatched(checkedDomino, lastNum, out int nextLastNum))
            {
                dominoesList.RemoveAt(i);
                if (Check(dominoesList, firstNum, nextLastNum)) return true;
                dominoesList.Insert(i, checkedDomino);
            }
        }
        return false;
    }
    private static bool TryMatched((int Left, int Right) checkedDomino, int lastNum, out int nextLastNum)
    {
        if (lastNum == checkedDomino.Left || lastNum == -1)
        {
            nextLastNum = checkedDomino.Right;
            return true;
        }
        if (lastNum == checkedDomino.Right)
        {
            nextLastNum = checkedDomino.Left;
            return true;
        }
        nextLastNum = lastNum;
        return false;
    }
}