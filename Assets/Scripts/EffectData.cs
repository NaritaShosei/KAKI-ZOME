using UnityEngine;

[CreateAssetMenu(fileName = "EffectData", menuName = "Data/Effect")]

public class EffectData : ScriptableObject
{
    public int[] Reel => _symbol;
    public SlotResultType ResultType => _resultType;
    public GameObject EffectPrefab => _effectPrefab;

    [SerializeField] private int[] _symbol;
    [SerializeField] private SlotResultType _resultType;
    [SerializeField] private GameObject _effectPrefab;
}
