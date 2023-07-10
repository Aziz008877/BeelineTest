using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private List<EnemyAttack> _allEnemies;
    [SerializeField] private float _attackDelay;
    private bool _canShoot = true;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        while (_canShoot)
        {
            Attack();
            yield return new WaitForSeconds(_attackDelay);
            DecreaseDelayTime();
        }
    }

    private void DecreaseDelayTime()
    {
        if (_attackDelay > 0.8f)
        {
            _attackDelay -= 0.2f;
        }
    }
    public void GameEnded()
    {
        _canShoot = false;
    }
    private void Attack()
    {
        var enemyAttack = SelectRandomEnemyAttack();
        enemyAttack.Attack();
    }

    public void AllEnemiesDisabled(float disableTime)
    {
        StartCoroutine(DisableAllEnemies(disableTime));
    }

    private IEnumerator DisableAllEnemies(float disableTime)
    {
        _canShoot = false;

        foreach (var enemy in _allEnemies)
        {
            enemy.Sleep(true);
        }

        yield return new WaitForSeconds(disableTime);
        
        foreach (var enemy in _allEnemies)
        {
            enemy.Sleep(false);
        }
        
        _canShoot = true;
        StartCoroutine(AttackCoroutine());
    }

    private EnemyAttack SelectRandomEnemyAttack()
    {
        int randomEnemyID = Random.Range(0, _allEnemies.Count);
        return _allEnemies[randomEnemyID];
    }
}
