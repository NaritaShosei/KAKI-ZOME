using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ReelView : MonoBehaviour
{
    public void Init(Slot slot)
    {
        _slot = slot;
    }

    public void UpdateView()
    {
        var reel = _slot.GetCurrentReel();

        Set(_twoUp, reel.twoUp);
        Set(_up, reel.up);
        Set(_now, reel.now);
        Set(_down, reel.down);
        Set(_twoDown, reel.twoDown);
        Set(_twoDownUp, reel.twoDown);

        float y = -reel.offset * _symbolHeight;

        _twoDownUp.anchoredPosition = new Vector2(_now.anchoredPosition.x, _base.anchoredPosition.y + y - _symbolHeight * 3);
        _twoUp.anchoredPosition = new Vector2(_now.anchoredPosition.x, _base.anchoredPosition.y + y - _symbolHeight * 2);
        _up.anchoredPosition = new Vector2(_now.anchoredPosition.x, _base.anchoredPosition.y + y - _symbolHeight);
        _now.anchoredPosition = new Vector2(_now.anchoredPosition.x, _base.anchoredPosition.y + y);
        _down.anchoredPosition = new Vector2(_now.anchoredPosition.x, _base.anchoredPosition.y + y + _symbolHeight);
        _twoDown.anchoredPosition = new Vector2(_now.anchoredPosition.x, _base.anchoredPosition.y + y + _symbolHeight * 2);
    }

    private Slot _slot;
    [SerializeField] private RectTransform _twoUp;
    [SerializeField] private RectTransform _up;
    [SerializeField] private RectTransform _now;
    [SerializeField] private RectTransform _down;
    [SerializeField] private RectTransform _twoDown;
    [SerializeField] private RectTransform _twoDownUp; // 下の画像が見切れるタイミングで一番上にくる

    [SerializeField] private RectTransform _base;
    [SerializeField] private float _symbolHeight;
    [SerializeField] private ReelData _data;

    private void Set(RectTransform rt, int symbol)
    {
        // symbol → Sprite 変換
        rt.GetComponent<Image>().sprite = GetSprite(symbol);
    }

    private Sprite GetSprite(int symbol)
    {
        return _data.GetSprite(symbol);
    }
}