using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
   [SerializeField] private AudioSource _collectSfx;
   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out IInteractible interactible))
      {
         _collectSfx.Play();
         interactible.PerformAction();
      }
   }
}
