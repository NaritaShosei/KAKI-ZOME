using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class Effect : MonoBehaviour
{
    [SerializeField] private RectTransform _transform1;
    [SerializeField] private float _scale1;
    [SerializeField] private float _scaleDuration1;
    [SerializeField] private float _rotateY1;
    [SerializeField] private float _rotateDuration1;
    [SerializeField] private Ease _ease1;

    [SerializeField] private RectTransform _transform2;
    [SerializeField] private float _scale2;
    [SerializeField] private float _scaleDuration2;
    [SerializeField] private float _rotateY2;
    [SerializeField] private float _rotateDuration2;
    [SerializeField] private Ease _ease2;

    [SerializeField] private float _lastScale;
    [SerializeField] private float _lastDuration;
    [SerializeField] private float _rotate;
    [SerializeField] private float _rotateDuration;
    [SerializeField] private float _posY1;
    [SerializeField] private float _posY2;
    [SerializeField] private Ease _lastEase;

    private void Start()
    {
        Play();
    }

    private void Play()
    {
        var seq = DOTween.Sequence();

        AppendEffect(
            seq,
            _transform1,
            _scale1,
            _scaleDuration1,
            _rotateY1,
            _rotateDuration1,
            _ease1,
            _posY1
        );

        AppendEffect(
            seq,
            _transform2,
            _scale2,
            _scaleDuration2,
            _rotateY2,
            _rotateDuration2,
            _ease2,
            _posY2
        );

        AppendLastEffect(seq);
    }

    private void AppendEffect(
        Sequence seq,
        RectTransform target,
        float scale,
        float scaleDuration,
        float rotateY,
        float rotateDuration,
        Ease scaleEase,
        float lastPos
    )
    {
        seq.Append(
            target.DOScale(Vector3.one * scale, scaleDuration)
                  .SetEase(scaleEase)
        )
        .Join(
            target.DORotate(
                new Vector3(0, -rotateY, 0),
                rotateDuration
            )
            .SetEase(Ease.Linear)
        )
        .Append(
            target.DORotate(
                new Vector3(0, rotateY, 0),
                rotateDuration
            )
            .SetEase(Ease.Linear)
        )
        .Append(
                target.DOScale(Vector3.zero, 0.1f)
            .OnComplete(() => target.anchoredPosition = new Vector2(target.anchoredPosition.x, lastPos)
            )
        );
    }

    private void AppendLastEffect(Sequence seq)
    {

        seq.Append(
            _transform1.DOScale(Vector3.one * _lastScale, _lastDuration)
                .SetEase(_lastEase)
        )
        .Join(
            _transform2.DOScale(Vector3.one * _lastScale, _lastDuration)
                .SetEase(_lastEase)
        )
        .Join(
            _transform1.DORotate(
                new Vector3(0, -_rotate, 0),
                _rotateDuration
            ).SetEase(Ease.Linear)
        )
         .Join(
            _transform2.DORotate(
                new Vector3(0, -_rotate, 0),
                _rotateDuration
            ).SetEase(Ease.Linear)
        )
        .Append(
            _transform1.DORotate(
                new Vector3(0, _rotate, 0),
                _rotateDuration
            ).SetEase(Ease.Linear)
        )
        .Join(
            _transform2.DORotate(
                new Vector3(0, _rotate, 0),
                _rotateDuration
            ).SetEase(Ease.Linear)
        )
        .OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }

}
