using UnityEngine;
using System;

[Serializable]
public class Slot
{
    public float Position => _position;

    public void Init(float speed)
    {
        _speed = speed;
        _position = 0f;
    }

    public void Tick(float deltaTime)
    {
        _position += _speed * deltaTime;
    }

    public void Stop()
    {
        _position = Mathf.Ceil(_position);
    }

    public int GetSymbol()
    {
        int index = Mathf.FloorToInt(_position) % _reel.Length;
        return _reel[index];
    }

    /// <summary>
    /// 表示用：上下＋現在＋補間量
    /// </summary>
    public (int twoUp, int up, int now, int down, int twoDpwn, float offset) GetCurrentReel()
    {
        int count = _reel.Length;

        int baseIndex = Mathf.FloorToInt(_position);

        int now = baseIndex % count;
        int down = (baseIndex + 1) % count;
        int twoDown = (baseIndex + 2) % count;
        int up = (baseIndex - 1 + count) % count;
        int twoUp = (baseIndex - 2 + count) % count;

        float offset = _position - baseIndex;

        return (
            _reel[twoUp],
            _reel[up],
            _reel[now],
            _reel[down],
            _reel[twoDown],
            offset
        );
    }

    [SerializeField] private int[] _reel;

    private float _position;
    private float _speed;
}
