namespace Utils;

public static class Extensions
{
    public static IEnumerable<IEnumerable<T>> Subsets<T>(this IEnumerable<T> set, int subsetSize)
    {
        if (subsetSize < 1)
            throw new ArgumentException($"Subset size must be greater than 0. Requested : \"{subsetSize}\"", nameof(subsetSize));
        
        var baseSet = set as T[] ?? set.ToArray();
        
        var count = baseSet.Length;
        if (subsetSize > count)
            throw new ArgumentException($"Subset size can't be greater than the base set. Requested : \"{subsetSize}\", Possible : \"{count}\"", nameof(subsetSize));
        
        var indices = new int[subsetSize];
        
        while (indices[0] <= count - subsetSize)
        {
            yield return indices.Select(i => baseSet[i]).ToArray();

            var i = subsetSize - 1;
            while (i >= 0)
            {
                if (indices[i] < count - subsetSize + i)
                {
                    indices[i]++;
                    for (int j = i + 1; j < subsetSize; j++)
                    {
                        indices[j] = indices[j - 1] + 1;
                    }
                    break;
                }
                i--;
            }

            if (i < 0) yield break;
        }
    }
}