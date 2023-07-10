using UnityEngine;

public class HPGem : MonoBehaviour, IInteractible
{
    private PlayerHp _playerHp;
    [SerializeField] private float _hpIncreaseValue;

    private void Start()
    {
        _playerHp = FindObjectOfType<PlayerHp>();
    }
    public void PerformAction()
    {
        _playerHp.IncreaseHp(_hpIncreaseValue);
        Destroy(gameObject);
    }
}
