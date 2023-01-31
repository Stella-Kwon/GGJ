using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
  
    public float bulletForce = 20f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))//fire1 is default as mouse 1. you can change it if you want.
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //instantiate is kind fo explain abstucted image with what object , which position to start and where to get?
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //access to bullet object and get the component feature.
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        //giving some details of force to the object.
    }
}
