using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowableController : MonoBehaviour
{
    [SerializeField] private float _slowTime;
    private List<ISlowable> _allSlowables = new List<ISlowable>();

    private void Start()
    {
        FreezeGem.OnSlowedTime += FindAllSlowables;
    }

    private void FindAllSlowables()
    {
        MonoBehaviour[] allObjects = FindObjectsOfType<MonoBehaviour>();
        
        foreach (MonoBehaviour obj in allObjects)
        {
            if (obj.TryGetComponent(out ISlowable slowable))
            {
                _allSlowables.Add(slowable);
            }
        }

        StartCoroutine(SlowTime());
    }

    private IEnumerator SlowTime()
    {
        foreach (var slowable in _allSlowables)
        {
            slowable.Slow();
        }

        yield return new WaitForSeconds(_slowTime);
        
        foreach (var slowable in _allSlowables)
        {
            slowable.Unslow();
        }
    }
}
