using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FreezeScreen : MonoBehaviour
{
    [SerializeField] private DotweenSettings _dotweenSettings;
    [SerializeField] private Image _freezeImage;
    [SerializeField] private Color _alphaFullColor;
    [SerializeField] private Color _alphaLowColor;

    private void Start()
    {
        FreezeGem.OnSlowedTime += StartFreezing;
    }

    private void StartFreezing()
    {
        StartCoroutine(FreezeEffect());
    }

    private IEnumerator FreezeEffect()
    {
        _freezeImage
            .DOColor(_alphaFullColor, _dotweenSettings.Duration)
            .SetEase(_dotweenSettings.AnimationType);
        
        yield return new WaitForSeconds(2);
        
        _freezeImage
            .DOColor(_alphaLowColor, _dotweenSettings.Duration)
            .SetEase(_dotweenSettings.AnimationType);
    }

    private void OnDestroy()
    {
        FreezeGem.OnSlowedTime -= StartFreezing;
    }
}
