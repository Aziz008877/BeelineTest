using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _bonuses;
    [SerializeField] private float _bonusSpawnCooldown;
    [SerializeField] private int _minZValue = -4;
    [SerializeField] private int _maxZValue = 4;
    [SerializeField] private int _minXValue = -4;
    [SerializeField] private int _maxXValue = 4;
    private bool _canSpawn = true;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        
        while (_canSpawn)
        {
            var randomBonus = SelectRandomBonus();
            Instantiate(randomBonus, RandomSpawnPosition(), Quaternion.identity);
            yield return new WaitForSeconds(_bonusSpawnCooldown);
        }
    }

    private Vector3 RandomSpawnPosition()
    {
        int xPos = Random.Range(_minXValue, _maxXValue);
        int zPos = Random.Range(_minZValue, _maxZValue);
        return new Vector3(xPos, 1, zPos);
    }
    private GameObject SelectRandomBonus()
    {
        int randomEnemyID = Random.Range(0, _bonuses.Count);
        return _bonuses[randomEnemyID];
    }
    
    public void GameEnded()
    {
        _canSpawn = false;
    }
}
