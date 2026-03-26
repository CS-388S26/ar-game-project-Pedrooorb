using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    GameObject ScoreManagerobj;
    ScoreController Scorecon;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManagerobj = GameObject.Find("ScoreManager");
        Scorecon = ScoreManagerobj.GetComponent<ScoreController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            Die();
        }
    }

    void Die()
    {
        Scorecon.AddScore(100); // give points
        Destroy(gameObject);
    }
}
