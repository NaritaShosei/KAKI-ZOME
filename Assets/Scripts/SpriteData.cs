using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ReelData", menuName = "Data")]
public class ReelData : ScriptableObject
{
    public SpriteData[] Data => _data;
    [SerializeField] private SpriteData[] _data;
}

[Serializable]
public struct SpriteData
{
    public int Symbol => _symbol;
    public Sprite Sprite => _sprite;

    [SerializeField] private int _symbol;
    [SerializeField] private Sprite _sprite;
}