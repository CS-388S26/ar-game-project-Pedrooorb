/**
 * @file
 *  CustomGravity.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  26/03/2026
 * @brief
 *  Controls the gravity of the game
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    Transform floor;

    public float smoothSpeed = 5f;

    private Vector3 currentGravity;
    /**
    * @brief Called when game starts
    */
    void Start()
    {
        floor = GetComponent<Transform>();
        currentGravity = Physics.gravity;
    }
    /**
    * @brief Updates the gravity direction in order to keep all attached to our floor target
    */
    void Update()
    {
        Vector3 targetGravity = -floor.up * 9.81f;
        currentGravity = Vector3.Lerp(currentGravity, targetGravity, smoothSpeed * Time.deltaTime);
        Physics.gravity = currentGravity;
    }
}
