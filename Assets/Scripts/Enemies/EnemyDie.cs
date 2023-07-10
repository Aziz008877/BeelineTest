using System;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    [SerializeField] private ParticleSystem _enemyDieParticles;

    public void Die()
    {
        _enemyDieParticles.Play();
        _enemyDieParticles.transform.SetParent(null);
    }
}
