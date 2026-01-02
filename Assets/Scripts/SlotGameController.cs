using System.Linq;
using System;
using UnityEngine;

public class SlotGameController : MonoBehaviour
{
    public event Action<int[]> OnAllReelStopped;

    public void StartReel()
    {
        if (!_isStopped.All(x => x)) return;

        Array.Fill(_isStopped, false);
    }

    public void StopReel(int slot)
    {
        if (_isStopped[slot]) return;

        _lottery[slot].Stop();
        _views[slot].UpdateView();
        _lastReel[slot] = _lottery[slot].GetSymbol();
        _isStopped[slot] = true;

        if (_isStopped.All(x => x))
        {
            OnAllReelStopped?.Invoke(_lastReel);
        }
    }

    [SerializeField] private Slot[] _lottery;
    [SerializeField] private ReelView[] _views;
    [SerializeField] private ResultEffectController _resultEffects;
    [SerializeField] private float _speed = 5f;

    private int[] _lastReel;
    private bool[] _isStopped;

    private void Start()
    {
        _lastReel = new int[_lottery.Length];
        _isStopped = new bool[_lottery.Length];

        for (int i = 0; i < _lottery.Length; i++)
        {
            _lottery[i].Init(_speed);
            _views[i].Init(_lottery[i]);
        }

        OnAllReelStopped += _resultEffects.PlayEffect;
    }

    private void Update()
    {
        for (int i = 0; i < _lottery.Length; i++)
        {
            if (!_isStopped[i])
                _lottery[i].Tick(Time.deltaTime);

            if (_views[i] is not null)
                _views[i].UpdateView();
        }
    }

    private void OnDestroy()
    {
        OnAllReelStopped -= _resultEffects.PlayEffect;
    }
}
