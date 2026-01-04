using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private Image _image;
    private void Start()
    {
        transform.DOScale(Vector3.one * 5, 5).
            OnComplete(() => Destroy(gameObject));
    }
}
