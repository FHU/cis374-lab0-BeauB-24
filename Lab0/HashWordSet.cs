namespace Lab0;

// [ "ryan", "beau", "caleb", "rye", 
// "beautiful", "cale", "cephas", "rhino", "cervid", "cecily"
// "ethan" , "ethel"]


public sealed class HashWordSet : IWordSet
{
    private HashSet<string> words = new();

    public int Count => words.Count;

    public bool Add(string word)
    {
        var normalizedWord = Normalize(word);
        if (normalizedWord.Length == 0)
            return false;

        return words.Add(normalizedWord); 
    }

    public bool Contains(string word)
    {
        var normalizedWord = Normalize(word);
        if (normalizedWord.Length == 0)
            return false;

        return words.Contains(normalizedWord); 
    }

    public bool Remove(string word)
    {
        var normalizedWord = Normalize(word);
        if (normalizedWord.Length == 0)
            return false;

        return words.Remove(normalizedWord); 
    }

    /// TODO
    public string? Prev(string word)
    {
        var normalizedWord = Normalize(word);
        if (normalizedWord.Length == 0)
            return null;

        string? best = null;

        foreach (var w in words)
        {
           
            if (w.CompareTo(normalizedWord) < 0 &&
                (best is null || w.CompareTo(best) > 0))
            {
                best = w;
            }
        }

        return best;
    }

    public string? Next(string word)
    {
        var normalizedWord = Normalize(word);
        if (normalizedWord.Length == 0)
            return null;

        string? best = null;

       
        foreach (var w in words)
        {
           
            if (normalizedWord.CompareTo(w) < 0 
                && (best is null || w.CompareTo(best) < 0))
            {
                best = w;
            }
        }

        return best;
    }

    public IEnumerable<string> Prefix(string prefix, int k)
    {
        var normalizedPrefix = Normalize(prefix);

        var results = new List<string>();

        foreach (var word in words)
        {
            if (word.StartsWith(normalizedPrefix))
            {
                results.Add(word);
            }
        }

        results.Sort();

        return results.Slice(0, Math.Min(k, results.Count));
    }

    /// TODO
    public IEnumerable<string> Range(string lo, string hi, int k)
    {
        var normalizedLo = Normalize(lo);
        var normalizedHi = Normalize(hi);

        if (normalizedLo.Length == 0 || normalizedHi.Length == 0)
            return Enumerable.Empty<string>();

        var results = new List<string>();

        foreach (var w in words)
        {
            if (w.CompareTo(normalizedLo) >= 0 &&
                w.CompareTo(normalizedHi) <= 0)
            {
                results.Add(w);
            }
        }

        results.Sort();

        return results.Take(k);
    }

    /// <summary>
    /// Normalize a word by trimming whitespace and converting to lowercase.
    /// </summary>
    /// <param name="word">The word to normalize.</param>
    /// <returns>The normalized word.</returns>
    private string Normalize(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return string.Empty;

        // Trim and lowercase 
        return word.Trim().ToLowerInvariant();
    }
}
