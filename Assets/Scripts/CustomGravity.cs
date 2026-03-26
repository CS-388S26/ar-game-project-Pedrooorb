using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    Transform floor;

    public float smoothSpeed = 5f;

    private Vector3 currentGravity;

    void Start()
    {
        floor = GetComponent<Transform>();
        currentGravity = Physics.gravity;
    }

    void Update()
    {
        Vector3 targetGravity = -floor.up * 9.81f;
        currentGravity = Vector3.Lerp(currentGravity, targetGravity, smoothSpeed * Time.deltaTime);
        Physics.gravity = currentGravity;
    }
}
