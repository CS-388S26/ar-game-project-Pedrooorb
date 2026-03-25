using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force = 500f;   // strength of the shot
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Shoot forward (based on bullet orientation)
        rb.AddForce(transform.up * force);
    }
}
