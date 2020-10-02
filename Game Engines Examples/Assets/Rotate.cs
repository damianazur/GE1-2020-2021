using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public int rotationSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        //transform.RotateAround(target, Vector3.up, 30 * Time.deltaTime);
    }
}
