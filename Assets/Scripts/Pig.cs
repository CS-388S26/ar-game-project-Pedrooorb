using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    GameObject ScoreManagerobj;
    ScoreController Scorecon;

    public float deathForce;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManagerobj = GameObject.Find("ScoreManager");
        Scorecon = ScoreManagerobj.GetComponent<ScoreController>();
    }

    void OnCollisionEnter(Collision collision)
    {
        float impact = collision.relativeVelocity.magnitude;

        if (impact > deathForce)
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
