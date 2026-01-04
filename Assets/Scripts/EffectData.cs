using UnityEngine;

[CreateAssetMenu(fileName = "EffectData", menuName = "Data/Effect")]

public class EffectData : ScriptableObject
{
    public int[] Reel => _symbol;
    public GameObject EffectPrefab => _effectPrefab;

    [SerializeField] private int[] _symbol;
    [SerializeField] private GameObject _effectPrefab;
}
