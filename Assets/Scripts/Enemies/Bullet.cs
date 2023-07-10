using System;
using UnityEngine;

public class Bullet : MonoBehaviour, ISlowable
{
    [SerializeField] private float _speed, _damage;

    private void Start()
    {
        Invoke(nameof(Die), 4);
    }

    private void Update()
    {
        Vector3 newPosition = transform.position + transform.forward * _speed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out PlayerHp playerHp))
        {
            playerHp.DecreaseHp(_damage);
            Destroy(gameObject);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void Slow()
    {
        _speed = 5;
    }

    public void Unslow()
    {
        _speed = 10;
    }
}
