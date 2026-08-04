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
            return list1.SequenceEqual(list2) ? SublistType.Equal : SublistType.Unequal;
        bool isLarger = list1.Count > list2.Count;
        List<T> superlist = isLarger ? list1 : list2;
        List<T> subList = isLarger ? list2 : list1;
        if (subList is []) return isLarger ? SublistType.Superlist : SublistType.Sublist;
        for (int i = 0; i <= superlist.Count - subList.Count; i++)
        {
            if (!superlist[i].Equals(subList[0])) continue;
            if (subList.SequenceEqual(superlist[i..(i + subList.Count)]))
                return isLarger ? SublistType.Superlist : SublistType.Sublist;
        }
        return SublistType.Unequal;
    }
}