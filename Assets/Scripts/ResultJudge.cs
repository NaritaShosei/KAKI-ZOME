using System.Linq;
using UnityEngine;

public class ResultJudge
{
    public SlotResultType Judge(int[] symbols)
    {
        if (symbols.All(x => x == symbols[0]))
            return SlotResultType.AllSame;

        if (symbols.GroupBy(x => x).Any(g => g.Count() >= 2))
            return SlotResultType.TwoSame;

        if (symbols.GroupBy(x => x).Any(g => g.Count() >= 3))
            return SlotResultType.ThreeSame;

        return SlotResultType.AllDifferent;
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
