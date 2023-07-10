using System;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour, ISlowable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyAttack _enemyAttack;
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
    private static readonly int IsSleeping = Animator.StringToHash("IsSleeping");

    private void Start()
    {
        _enemyAttack.OnEnemyAttacking += AttackAnimation;
        _enemyAttack.OnSleepStateSent += EnemySleepStateAnimation;
    }

    private void EnemySleepStateAnimation(bool state)
    {
        _animator.SetBool(IsSleeping, state);
    }

    private void AttackAnimation()
    {
        _animator.SetTrigger(IsAttacking);
    }

    private void OnDestroy()
    {
        _enemyAttack.OnEnemyAttacking -= AttackAnimation;
        _enemyAttack.OnSleepStateSent -= EnemySleepStateAnimation;
    }

    public void Slow()
    {
        _animator.speed = 0.5f;
    }

    public void Unslow()
    {
        _animator.speed = 1;
    }
}
