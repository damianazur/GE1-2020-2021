using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotating : MonoBehaviour
{
    Quaternion start;
    Quaternion end;

    float t;
    public float time = 5.0f;
    public float speed = 20.0f;
    bool playerWithinSight = false;
    public GameObject bulletPrefab; 
    public Transform spawnPoint; 
    public Transform target;
    public float fireRate = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Shoot()
    {
        GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
        bullet.transform.position = spawnPoint.position;
        bullet.transform.rotation = this.transform.rotation;
    }

    System.Collections.IEnumerator ShootingCoroutine()
    {
        while(true)
        {
            if (playerWithinSight == true)
            {
                Shoot();
                yield return new WaitForSeconds(1.0f / fireRate);
            }
            yield return null;
        }
    }
    void OnEnable()
    {
        StartCoroutine(ShootingCoroutine());
    }

    void OnTriggerEnter(Collider c)
    {
        Debug.Log("Triggered with: " + c.gameObject.tag);
    }

    void OnTriggerStay(Collider c)
    {
        Vector3 toTarget = target.transform.position - transform.position;
        toTarget.Normalize();
        end = Quaternion.LookRotation(toTarget);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, end, speed * Time.deltaTime);
    }

    void Update()
    {
        Vector3 toTarget = target.transform.position - transform.position;
        toTarget.Normalize();

        float angle = Mathf.Acos(Vector3.Dot(transform.forward, toTarget) / toTarget.magnitude) * Mathf.Rad2Deg;
        if (angle < 10) {
            playerWithinSight = true;
        } else {
            playerWithinSight = false;
        }
    }
}
