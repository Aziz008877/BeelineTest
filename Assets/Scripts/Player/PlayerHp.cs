using UnityEngine;
using UnityEngine.Events;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] private float _hpValue;
    [SerializeField] private UnityEvent _onPlayerDead;
    [SerializeField] private UnityEvent<float> _onPlayerHpChanged;
    private float _minHpValue = 0;
    private float _maxHpValue = 100;

    public void IncreaseHp(float increaseValue)
    {
        if (_hpValue + increaseValue > _maxHpValue)
        {
            _hpValue = _maxHpValue;
        }
        else
        {
            _hpValue += increaseValue;
        }
        
        _onPlayerHpChanged?.Invoke(_hpValue);
    }

    public void DecreaseHp(float decreaseValue)
    {
        if (_hpValue - decreaseValue <= 0)
        {
            _onPlayerDead?.Invoke();
        }
        else
        {
            _hpValue -= decreaseValue;
        }
        
        _onPlayerHpChanged?.Invoke(_hpValue);
    }
}
