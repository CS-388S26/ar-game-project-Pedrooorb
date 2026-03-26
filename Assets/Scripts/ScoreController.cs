/**
 * @file
 *  ScoreController.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  26/03/2026
 * @brief
 *  Controls the score of the game
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoretext;

    private int score;

    /**
    * @brief Called when game starts
    */
    void Start()
    {
        score = 0;
        UpdateScore();
    }
    /**
    * @brief Adds score to our accumulated score
    */
    public void AddScore(int scoretoadd)
    {
        score += scoretoadd;
        UpdateScore();
    }
    /**
    * @brief Updates the text with the current score count
    */
    void UpdateScore()
    {
        scoretext.text = "Score: " + score;
    }
}
