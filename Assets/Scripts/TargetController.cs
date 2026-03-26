using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetController : MonoBehaviour
{
    private ObserverBehaviour observerBehaviour;

    void Start()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();

        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnDestroy()
    {
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        // Check if target is being tracked
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            EnableChildrenPhysics();
        }
        else
        {
            DisableChildrenPhysics();
        }
    }

    void EnableChildrenPhysics()
    {
        foreach (Transform child in transform)
        {
            SetPhysics toggle = child.GetComponent<SetPhysics>();

            if (toggle != null)
            {
                toggle.EnablePhysics();
            }
        }
    }    
    void DisableChildrenPhysics()
    {
        foreach (Transform child in transform)
        {
            SetPhysics toggle = child.GetComponent<SetPhysics>();

            if (toggle != null)
            {
                toggle.DisablePhysics();
            }
        }
    }
}
