using System.Linq;

public static class ResultJudge
{
    public static SlotResult Judge(int[] symbols)
    {
        var groups = symbols
            .GroupBy(x => x)
            .OrderByDescending(g => g.Count())
            .ToArray();

        var top = groups[0];

        // 全揃い
        if (top.Count() >= symbols.Length)
            return new SlotResult(SlotResultType.AllSame, top.Key);
        // 3揃い
        if (top.Count() == 3)
            return new SlotResult(SlotResultType.ThreeSame, top.Key);

        // 2揃い
        if (top.Count() == 2)
            return new SlotResult(SlotResultType.TwoSame, top.Key);

        return new SlotResult(SlotResultType.AllDifferent, null);
    }
}


public enum SlotResultType
{
    None,
    AllSame,
    TwoSame,
    ThreeSame,
    AllDifferent
}

public readonly struct SlotResult
{
    public readonly SlotResultType Type;
    public readonly int? Symbol; // 揃った絵柄（なければ null）

    public SlotResult(SlotResultType type, int? symbol)
    {
        Type = type;
        Symbol = symbol;
    }
}