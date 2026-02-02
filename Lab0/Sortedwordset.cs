namespace Lab0;

public sealed class SortedWordSet : IWordSet
{
    private SortedSet<string> words = new();

    public int Count => words.Count;

    public bool Add(string word)
    {
        return words.Add(word);
    }

    public bool Remove(string word)
    {
        return words.Remove(word);
    }

    public bool Contains(string word)
    {
        return words.Contains(word);
    }

    public string? Next(string word)
    {
        // first element strictly greater than word
        foreach (var w in words.GetViewBetween(word, "\uffff"))
        {
            if (w.CompareTo(word) > 0)
                return w;
        }
        return null;
    }

    public string? Prev(string word)
    {
        // walk backwards through elements < word
        foreach (var w in words.GetViewBetween("", word))
        {
            if (w.CompareTo(word) < 0)
                return w;
        }
        return null;
    }

    public IEnumerable<string> Prefix(string prefix, int k)
    {
        var results = new List<string>();

        if (k <= 0) return results;

        string hi = prefix + '\uffff';

        foreach (var word in words.GetViewBetween(prefix, hi))
        {
            if (!word.StartsWith(prefix))
                break;

            results.Add(word);
            if (results.Count == k)
                break;
        }

        return results;
    }

    public IEnumerable<string> Range(string lo, string hi, int k)
    {
        var results = new List<string>();

        if (k <= 0) return results;

        foreach (var word in words.GetViewBetween(lo, hi))
        {
            results.Add(word);
            if (results.Count == k)
                break;
        }

        return results;
    }
}
