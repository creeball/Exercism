public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType Classify<T>(List<T> list1, List<T> list2) where T : IComparable
    {
        if (list1.Count == list2.Count)
        {
            int count = -1;
            return list1.All(t =>
            {
                count++;
                return t.Equals(list2[count]);
            }) ? SublistType.Equal : SublistType.Unequal;
        }
        List<T> superlist, subList;
        bool isLarger = list1.Count > list2.Count;
        if (isLarger)
        {
            superlist = list1;
            subList = list2;
        }
        else
        {
            superlist = list2;
            subList = list1;
        }
        if (subList is []) return isLarger ? SublistType.Superlist : SublistType.Sublist;
        for (int i = 0; i <= superlist.Count - subList.Count; i++)
        {
            if (!superlist[i].Equals(subList[0])) continue;
            int count = -1;
            if (subList.All(t =>
                {
                    count++;
                    return t.Equals(superlist[i + count]);
                })) return isLarger ? SublistType.Superlist : SublistType.Sublist;
        }
        return SublistType.Unequal;
    }
}