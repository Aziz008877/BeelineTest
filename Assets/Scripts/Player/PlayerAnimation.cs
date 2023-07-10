using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMove), typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private PlayerMove _playerMove;
    private Animator _animator;
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

    private void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
        _animator = GetComponent<Animator>();
        _playerMove.OnPlayerMoved += MovingState;
    }

    private void MovingState(Vector3 moveVector)
    {
        _animator.SetBool(IsMoving, moveVector != Vector3.zero);
    }

    private void Attack()
    {
        _animator.SetTrigger(IsAttacking);
    }

    private void OnDestroy()
    {
        _playerMove.OnPlayerMoved -= MovingState;
    }
}
