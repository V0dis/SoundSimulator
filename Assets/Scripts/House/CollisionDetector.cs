using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action<bool> OnIntruderEntered;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Enemy>() != null)
            OnIntruderEntered?.Invoke(true);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Enemy>() != null) 
            OnIntruderEntered?.Invoke(false);
    }
}