using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform shootLocation;
    public GameObject inkProjectile;
    public GameObject player;
    public float shootRate = 2f;
    public Material startMat;

    private ThirdPersonController controller;
    private float nextShootTime = 0f;
    private InkProjectile inkProj;

    private void Start()
    {
        controller = player.GetComponent<ThirdPersonController>();
        inkProjectile.GetComponent<MeshRenderer>().material = startMat;
        inkProj = inkProjectile.GetComponent<InkProjectile>();
        inkProj.ColorChangeGround(startMat);
    }

    void Update()
    {
        if (controller.IsShooting())
        {
            if (Time.time >= nextShootTime)
            {
                Shoot();
                nextShootTime = Time.time + 1f / shootRate;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(inkProjectile, shootLocation.position, shootLocation.rotation);
    }

    public void ColorChange(Material newMaterial)
    {
        inkProj.ColorChangeGround(newMaterial);
        inkProjectile.GetComponent<MeshRenderer>().material = newMaterial;
        inkProj.groundHeight += 0.0001f;
    }
}
