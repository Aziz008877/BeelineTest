using System;
using UnityEngine;

public class RandomEnemyKillGem : MonoBehaviour, IInteractible
{
    [SerializeField] private float _enemySleepTime;
    private EnemiesController _enemiesController;

    private void Start()
    {
        _enemiesController = FindObjectOfType<EnemiesController>();
    }

    public void PerformAction()
    {
        _enemiesController.AllEnemiesDisabled(_enemySleepTime);
        Destroy(gameObject);
    }
}
