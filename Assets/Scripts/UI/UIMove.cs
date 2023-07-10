using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class UIMove : MonoBehaviour
    {
        [SerializeField] private DotweenSettings _dotweenSettings;
        [SerializeField] private bool _isGoingBack = false;
        [SerializeField] private Vector2 _startPosition, _activePosition;
        private RectTransform _rect;
        private bool _isMoving = false;

        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
        }

        public void MoveToActive()
        {
            MovePanel(_activePosition);
        }

        private void MoveBack()
        {
            MovePanel(_startPosition);
        }
        
        private void MovePanel(Vector2 movePos)
        {
            if (!_isMoving)
            {
                _isMoving = true;
                var sequence = DOTween.Sequence();
            
                sequence.Append(
                    _rect
                        .DOAnchorPos(movePos, _dotweenSettings.Duration)
                        .SetEase(_dotweenSettings.AnimationType)
                        .OnComplete(async delegate
                        {
                            if (_isGoingBack)
                            {
                                await Task.Delay(1500);
                                _isMoving = false;
                                MoveBack();
                            }
                        }));
            }
            
        }
    }
}
