using System;
using System.Collections.Generic;
using System.Linq;

public static class ResultJudge
{
    public static SlotResult Judge(int[] symbols)
    {
        var groups = symbols
            .Select((symbol, index) => new { symbol, index })
            .GroupBy(x => x.symbol)
            .OrderByDescending(g => g.Count())
            .ToArray();

        var top = groups[0];
        var indexes = top.Select(x => x.index).ToArray();

        if (top.Count() == symbols.Length)
            return new SlotResult(SlotResultType.AllSame, top.Key, indexes, symbols);

        if (top.Count() == 3)
            return new SlotResult(SlotResultType.ThreeSame, top.Key, indexes, symbols);

        if (top.Count() == 2)
            return new SlotResult(SlotResultType.TwoSame, top.Key, indexes, symbols);

        return new SlotResult(SlotResultType.AllDifferent, -1, Array.Empty<int>(), symbols);
    }
}


public enum SlotResultType
{
    AllSame,
    TwoSame,
    ThreeSame,
    AllDifferent
}

public readonly struct SlotResult
{
    public readonly SlotResultType Type;
    public readonly int Symbol;              // 揃った絵柄
    public readonly IReadOnlyList<int> Indexes; // 揃ったリール位置
    public readonly IReadOnlyList<int> Reel; // リール

    public SlotResult(
        SlotResultType type,
        int symbol,
        IReadOnlyList<int> indexes,
        IReadOnlyList<int> reel)
    {
        Type = type;
        Symbol = symbol;
        Indexes = indexes;
        Reel = reel;
    }
}
