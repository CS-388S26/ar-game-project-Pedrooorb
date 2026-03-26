/**
 * @file
 *  Pistol.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  26/03/2026
 * @brief
 *  Controls the pistol and adds some animation
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnpt;

    public Transform barrelguard;

    public float cooldown = 0.5f;
    private float lastShotTime = 0f;

    public float recoilAngle = 45f;
    public float recoilTime = 0.1f;

    private Quaternion originalRotation;
    private Vector3 barrelguardStartPos;
    /**
    * @brief Called when game starts
    */
    void Start()
    {
        //set original pos and rot
        originalRotation = transform.localRotation;
        barrelguardStartPos = barrelguard.localPosition;
    }
    /**
    * @brief Called every iteration
    */
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            TryShoot();
        }

        if (Input.GetMouseButtonDown(0))
        {
            TryShoot();
        }
    }
    /**
    * @brief Checks if possible to shoot again
    */
    void TryShoot()
    {
        //check if able to shoot again
        if (Time.time >= lastShotTime + cooldown)
        {
            Shoot();
            StartCoroutine(Recoil());
            lastShotTime = Time.time;
        }
    }
    /**
    * @brief Spawns bullet in the direction of our pistol
    */
    void Shoot()
    {
        Instantiate(bullet, spawnpt.position, spawnpt.rotation);
    }
    /**
    * @brief Adds some cool animation to the pistol in order to give feedback when shooting
    */
    IEnumerator Recoil()
    {
        //target rotation (tilt up)
        Quaternion recoilRot = originalRotation * Quaternion.Euler(-recoilAngle, 0f, 0f);

        float t = 0f;

        //Rotate up
        while (t < recoilTime)
        {
            t += Time.deltaTime;
            transform.localRotation = Quaternion.Lerp(originalRotation, recoilRot, t / recoilTime);

            //Move barrelguard back
            barrelguard.localPosition = barrelguardStartPos + new Vector3(0, 0, -0.05f * (t / recoilTime));

            yield return null;
        }

        t = 0f;

        //Rotate back down
        while (t < recoilTime)
        {
            t += Time.deltaTime;
            transform.localRotation = Quaternion.Lerp(recoilRot, originalRotation, t / recoilTime);

            //Move barrelguard forward
            barrelguard.localPosition = Vector3.Lerp(
                barrelguardStartPos + new Vector3(0, 0, -0.05f),
                barrelguardStartPos,
                t / recoilTime
            );

            yield return null;
        }

        //Ensure exact reset
        transform.localRotation = originalRotation;
        barrelguard.localPosition = barrelguardStartPos;
    }
}
