/**
 * @file
 *  TargetController.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  26/03/2026
 * @brief
 *  Manages the physics of the game objects depending on the target status
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetController : MonoBehaviour
{
    private ObserverBehaviour observerBehaviour;
    /**
    * @brief Called when game starts
    */
    void Start()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();

        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }
    /**
    * @brief Called when the target is destroyed
    */
    private void OnDestroy()
    {
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
    /**
    * @brief Called when the target status changes
    */
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
    /**
    * @brief Enables physics for all its children
    */
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
    /**
    * @brief Disables physics for all its children
    */
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
