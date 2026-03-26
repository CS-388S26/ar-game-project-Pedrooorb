using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoretext;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
    }

    public void AddScore(int scoretoadd)
    {
        score += scoretoadd;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoretext.text = "Score: " + score;
    }
}
