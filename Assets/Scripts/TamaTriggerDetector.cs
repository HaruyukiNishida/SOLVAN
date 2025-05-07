using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]

public class TamaTriggerDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent onTriggerEnter = new TriggerEvent();
    [SerializeField] private TriggerEvent onTriggerExit = new TriggerEvent();

    private void OnTriggerEnter(Collider collision)
    {
        onTriggerEnter.Invoke(collision);
    }

    private void OnTriggerExit(Collider collision)
    {
        onTriggerExit.Invoke(collision);
    }
}

[Serializable]
public class TriggerEvent : UnityEvent<Collider>
{
}


