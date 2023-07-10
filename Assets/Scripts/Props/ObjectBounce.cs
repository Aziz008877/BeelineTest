using System;
using DG.Tweening;
using UnityEngine;

public class ObjectBounce : MonoBehaviour
{
    [SerializeField] private DotweenSettings _dotweenSettings;
    [SerializeField] private float _levitationHeight;
    private Vector3 _initialPosition;

    private void Start()
    {
        _initialPosition = transform.position;
        StartLevitation();
    }

    private void StartLevitation()
    {
        transform.DOMoveY(_initialPosition.y + _levitationHeight, _dotweenSettings.Duration)
            .SetEase(_dotweenSettings.AnimationType)
            .OnComplete(ReverseLevitation);
    }

    private void ReverseLevitation()
    {
        transform.DOMoveY(_initialPosition.y, _dotweenSettings.Duration)
            .SetEase(_dotweenSettings.AnimationType)
            .OnComplete(StartLevitation);
    }

    private void OnDestroy()
    {
        DOTween.Kill(this);
    }
}
