/**
 * @file
 *  Bullet.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  26/03/2026
 * @brief
 *  Controls the bullet behaviour
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // strength of the shot
    public float force = 500f;   
    private Rigidbody rb;

    /**
    * @brief Called when game starts
    */
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Shoot forward (based on bullet orientation)
        rb.AddForce(transform.up * force);
    }
}
