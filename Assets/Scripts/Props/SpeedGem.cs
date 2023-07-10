using System;
using UnityEngine;

public class SpeedGem : MonoBehaviour, IInteractible
{
    private PlayerMove _playerMove;
    [SerializeField] private float _boostSpeed;
    [SerializeField] private float _boostTime;

    private void Start()
    {
        _playerMove = FindObjectOfType<PlayerMove>();
    }
    
    public void PerformAction()
    {
        _playerMove.ChangeSpeedValue(_boostSpeed, _boostTime);
        Destroy(gameObject);
    }
}
