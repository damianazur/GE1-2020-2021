using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public int numwaypoints = 10;
    public float radius = 12;
    public List<Vector3> waypoints = new List<Vector3>();

    // Start is called before the first frame update
    void Awake() 
    {
        MakeWaypoints();
    }

    void MakeWaypoints()
    {
        waypoints.Clear();
        float thetaInc = (Mathf.PI * 2) / numwaypoints;
        for (int i = 0; i < numwaypoints; i++)
        {
            float theta = i * thetaInc;
            Vector3 pos = new Vector3(Mathf.Sin(theta) * radius, 0, Mathf.Cos(theta) * radius);
            pos = transform.TransformPoint(pos);
            waypoints.Add(pos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
