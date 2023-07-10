using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class PlayerRotate : MonoBehaviour
{
    private PlayerMove _playerMove;

    private void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
        _playerMove.OnPlayerMoved += RotatePlayer;
    }

    private void RotatePlayer(Vector3 moveVector)
    {
        if (moveVector != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveVector);
            transform.rotation = targetRotation;
        }
    }

    private void OnDestroy()
    {
        _playerMove.OnPlayerMoved -= RotatePlayer;
    }
}
