/**
 * @file
 *  SetPhysics.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  26/03/2026
 * @brief
 *  Controls and manages the physics behaviour
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPhysics : MonoBehaviour
{
    private Rigidbody rb;
    /**
    * @brief Called when game starts
    */
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        DisablePhysics();
    }
    /**
    * @brief Sets original physics
    */
    public void EnablePhysics()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }
    /**
    * @brief Freezes physics
    */
    public void DisablePhysics()
    {
        // Disable gravity
        rb.useGravity = false;

        // Freeze physics
        rb.isKinematic = true;
    }
}
