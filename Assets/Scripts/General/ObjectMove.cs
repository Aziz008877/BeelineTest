using System;
using DG.Tweening;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private MoveDirection _moveDirection;
    [SerializeField] private float _movePoint;
    [SerializeField] private DotweenSettings _dotweenSettings;

    public void MoveObject()
    {
        switch (_moveDirection)
        {
            case MoveDirection.Horizontal:
                transform
                    .DOMoveX(_movePoint, _dotweenSettings.Duration)
                    .SetEase(_dotweenSettings.AnimationType);
                break;
            
            case MoveDirection.Vertical:
                transform
                    .DOMoveY(_movePoint, _dotweenSettings.Duration)
                    .SetEase(_dotweenSettings.AnimationType);
                break;
            
            case MoveDirection.Forward:
                transform
                    .DOMoveZ(_movePoint, _dotweenSettings.Duration)
                    .SetEase(_dotweenSettings.AnimationType);
                break;
        }
    }
}

public enum MoveDirection
{
    Horizontal,
    Vertical,
    Forward
}

[Serializable]
public class DotweenSettings
{
    public float Duration;
    public Ease AnimationType;
}
