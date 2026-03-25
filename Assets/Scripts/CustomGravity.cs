using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    Transform floor;

    void Start()
    {
        floor = GetComponent<Transform>();
        //set as default the floor direction gravity 
        Physics.gravity = -floor.up * 9.81f;
    }
}
