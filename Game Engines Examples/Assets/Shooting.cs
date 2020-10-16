﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab; 

    public float fireRate = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable() {
        StartCoroutine(ShootCoroutine());
    }

    System.Collections.IEnumerator ShootCoroutine()
    {
        while (true) {
            Shoot();
            yield return new WaitForSeconds(1.0f / (float) fireRate);
        }

        yield return null;
    }
    // Update is called once per frame
    void Update()
    {

    }

    void Shoot() {
        if (Input.GetButton("Fire1")) {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
            bullet.transform.position = spawnPoint.position;
            bullet.transform.rotation = this.transform.rotation;
        }
    }
}
