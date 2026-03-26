using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPhysics : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        DisablePhysics();
    }

    public void EnablePhysics()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    public void DisablePhysics()
    {
        // Disable gravity
        rb.useGravity = false;

        // Freeze physics
        rb.isKinematic = true;
    }
}
