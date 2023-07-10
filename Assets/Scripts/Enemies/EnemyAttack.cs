using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawnPlace;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private UnityEvent _onEnemyAttacking;
    public event Action OnEnemyAttacking;
    public event Action<bool> OnSleepStateSent;

    public void Attack()
    {
        OnEnemyAttacking?.Invoke();
        _onEnemyAttacking?.Invoke();
    }

    public void Sleep(bool state)
    {
        OnSleepStateSent?.Invoke(state);
    }

    //called from Animation Event
    public void AttackFromAnimation()
    {
        Instantiate(_bullet, _bulletSpawnPlace.position, _bulletSpawnPlace.rotation);
    }
}
