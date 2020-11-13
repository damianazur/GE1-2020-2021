using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab7Spawner : MonoBehaviour
{
    public GameObject cube;
    public Path path;
    
    public 
    // Start is called before the first frame update
    void Start()
    {
        int numWaypoints = path.numwaypoints;

        for (int i = 0; i < numWaypoints; i++) {
            GameObject c =  GameObject.Instantiate<GameObject>(cube);
            c.GetComponent<PathFollower>().path = path;
            c.GetComponent<PathFollower>().currentWaypoint = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
