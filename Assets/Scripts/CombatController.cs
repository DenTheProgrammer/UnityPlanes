using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] float fireInitialForce = 10f;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] List<Transform> aimPoints;
    [SerializeField] Collider planeCollider;
    bool shooting = false;
    float lastShotTime = -10000f;

    void Awake()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time - lastShotTime >= timeBetweenShots)
        {
            shooting = true;
            lastShotTime = Time.time;
        }
    }

    void FixedUpdate()
    {
        if (shooting)
        {
            shooting = false;
            Shoot();
        }
    }

    void Shoot()
    {
        foreach (var aimPoint in aimPoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, aimPoint.transform.position, aimPoint.transform.rotation);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        
            bulletRB.AddForce(bulletRB.transform.right * fireInitialForce, ForceMode.Impulse);
            Physics.IgnoreCollision(planeCollider, bulletRB.GetComponent<Collider>());
        }
    }

   
}
