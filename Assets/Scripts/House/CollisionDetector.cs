using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action<bool> IntruderEntered;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Enemy>() != null)
            IntruderEntered?.Invoke(true);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Enemy>() != null) 
            IntruderEntered?.Invoke(false);
    }
}