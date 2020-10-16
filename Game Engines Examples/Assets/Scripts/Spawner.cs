using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public float radius = 10;

    public int spawnRate = 5;

    public int max = 10;

    public GameObject spawnObject;

    void Spawn()
    {
        GameObject cube = GameObject.Instantiate<GameObject>(spawnObject);
        // cube.GetComponent<Renderer>().material.color = 
        //     Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
        Vector3 pos = new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));

        cube.AddComponent<Rigidbody>();
        cube.transform.position = transform.TransformPoint(pos);

        cube.transform.parent = this.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Spawn", 5);
    }

    void OnEnable()
    {
        StartCoroutine(SpawnCoroutine());
    }

    int count = 0;

    System.Collections.IEnumerator SpawnCoroutine()
    {
        while(true)
        {
            
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("BlueTank");
            print(cubes.Length);
            if (cubes.Length < max)
            {
                Spawn();
            }
            yield return new WaitForSeconds(1.0f / (float)spawnRate); 
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
