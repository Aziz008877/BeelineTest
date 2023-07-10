using System;
using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Joystick _joystick;
    public event Action<Vector3> OnPlayerMoved;
    private float _startSpeed;
    private bool _canMove = true;

    private void Start()
    {
        _startSpeed = _moveSpeed;
    }

    public void ChangeSpeedValue(float newSpeedValue, float bonusTime)
    {
        StartCoroutine(Shift(newSpeedValue, bonusTime));
    }

    private IEnumerator Shift(float newSpeedValue, float bonusTime)
    {
        _moveSpeed = newSpeedValue;
        yield return new WaitForSeconds(bonusTime);
        _moveSpeed = _startSpeed;
    }

    private void Update()
    {
        if (_canMove)
        {
            float horizontalInput = _joystick.Horizontal;
            float verticalInput = _joystick.Vertical;

            Vector3 moveVector = new Vector3(horizontalInput, 0, verticalInput) * _moveSpeed * Time.deltaTime;
            transform.position += moveVector;

            OnPlayerMoved?.Invoke(moveVector);
        }
    }
    
    public void GameEnded()
    {
        _canMove = false;
    }
}
