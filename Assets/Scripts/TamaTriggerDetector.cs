using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]

public class TamaTriggerDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent<Collider> onTriggerEnter = new TriggerEvent<Collider>();
    [SerializeField] private TriggerEvent<Collider> onTriggerExit = new TriggerEvent<Collider>();


    private void OnTriggerEnter(Collider collider)
    {
        Debug.LogWarning(collider.name);

        onTriggerEnter.Invoke(collider);
    }


    private void OnTriggerExit(Collider collider)
    {
        //    Debug.LogWarning(collider.name);

        onTriggerExit.Invoke(collider);
    }
}

[Serializable]
public class TriggerEvent<Collider> : UnityEvent<Collider>
{
}


