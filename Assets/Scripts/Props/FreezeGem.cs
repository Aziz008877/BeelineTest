using System;
using UnityEngine;

public class FreezeGem : MonoBehaviour, IInteractible
{
    public static event Action OnSlowedTime;
    public void PerformAction()
    {
        OnSlowedTime?.Invoke();
        Destroy(gameObject);
    }
}
