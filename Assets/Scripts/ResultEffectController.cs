using System.Linq;
using UnityEngine;

public class ResultEffectController : MonoBehaviour
{
    public void PlayEffect(int[] reel)
    {
        var result = ResultJudge.Judge(reel);

        Show(result);
    }

    [SerializeField] private EffectData[] _effects;

    private void Show(SlotResult result)
    {
        var effect = _effects.FirstOrDefault(e =>
            e.Symbol == result.Symbol &&
            e.ResultType == result.Type);

        if (effect == null) return;

        Instantiate(effect.EffectPrefab);
    }
}
