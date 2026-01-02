using System;
using System.Linq;
using System.Text;
using UnityEngine;

public class SlotGameController : MonoBehaviour
{
    #region ボタンから呼び出される

    public void StopReel(int slot)
    {
        _lastReel[slot] = _lottery[slot].GetSymbol();
        _isStopped[slot] = true;
        LogReel();
    }

    public void StartReel()
    {
        if (!_isStopped.All(x => x)) { return; }

        Array.Fill(_isStopped, false);
    }

    #endregion

    [SerializeField] private Slot[] _lottery;
    [SerializeField] private float _changeTime = 0.5f;

    private int[] _lastReel;
    private bool[] _isStopped;

    private void Start()
    {
        _lastReel = new int[_lottery.Length];
        Array.ForEach(_lottery, lottery => lottery.Init(_changeTime));

        _isStopped = new bool[_lottery.Length];
    }

    private void Update()
    {
        for (int i = 0; i < _lottery.Length; i++)
        {
            if (_isStopped[i]) { continue; }

            _lottery[i].RotateReel(Time.deltaTime);
        }
    }

    private void LogReel()
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < _lottery.Length; i++)
        {
            sb.Append($"{_lastReel[i]},");
        }

        Debug.Log(sb.ToString());
    }
}
