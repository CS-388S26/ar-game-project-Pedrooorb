/**
 * @file
 *  Pig.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  26/03/2026
 * @brief
 *  Controls and manages the pigs behaviour
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    GameObject ScoreManagerobj;
    ScoreController Scorecon;

    /**
    * @brief Called when game starts
    */
    void Start()
    {
        ScoreManagerobj = GameObject.Find("ScoreManager");
        Scorecon = ScoreManagerobj.GetComponent<ScoreController>();
    }
    /**
    * @brief Called to recognize if collided with triggerzone
    */
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            Die();
        }
    }
    /**
    * @brief Destroys the pig and adds points to our score
    */
    void Die()
    {
        Scorecon.AddScore(100); // give points
        Destroy(gameObject);
    }
}
