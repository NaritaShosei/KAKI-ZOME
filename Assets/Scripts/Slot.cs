using System;
using UnityEngine;

[Serializable]
public class Slot
{
    public void Init(float changeTime)
    {
        _changeTime = changeTime;
    }
    public int GetSymbol()
    {
        return _reel[_currentIndex];
    }

    public void RotateReel(float deltaTime)
    {
        _timer += deltaTime;

        if (_changeTime <= _timer)
        {
            _timer = 0;
            _currentIndex = ++_currentIndex % _reel.Length;
        }
    }

    [SerializeField] private int[] _reel;
    private float _timer;
    private float _changeTime;
    private int _currentIndex;
}
