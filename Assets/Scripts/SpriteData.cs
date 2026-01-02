using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReelData", menuName = "Data/Reel")]
public class ReelData : ScriptableObject
{
    public Sprite GetSprite(int key)
    {
        if (_sprites == null)
            BuildDictionary();

        return _sprites[key];
    }

    [SerializeField] private SpriteData[] _data;

    private Dictionary<int, Sprite> _sprites;

    private void BuildDictionary()
    {
        _sprites = new Dictionary<int, Sprite>();

        foreach (var data in _data)
        {
            _sprites[data.Symbol] = data.Sprite;
        }
    }
}

[Serializable]
public struct SpriteData
{
    public int Symbol => _symbol;
    public Sprite Sprite => _sprite;

    [SerializeField] private int _symbol;
    [SerializeField] private Sprite _sprite;
}