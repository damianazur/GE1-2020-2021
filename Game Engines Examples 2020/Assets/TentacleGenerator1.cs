using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleGenerator1 : MonoBehaviour {
    public int numSegments;
    public GameObject headPrefab;
    public GameObject segmentPrefab;


    // Use this for initialization
    // Generates the tentacle segments in a straight line
    void Awake () {
        for (int i = 0; i < numSegments; i++)
        {
            Vector3 pos = -i * Vector3.forward * 1.1f; // Head created first and then everything else behind
            GameObject prefab = (i == 0) ? headPrefab : segmentPrefab; // if first segment then it is the head, otherwise it is a body
            GameObject segment = GameObject.Instantiate<GameObject>(prefab); // Instantiate the segment

            // Rotate the position by the transforms rotation and add the position
            // Doing TransformPoint without including scale
            // The position of the segment is local to this object
            segment.transform.position = (transform.rotation * pos) + transform.position;
            
            segment.transform.rotation = transform.rotation;
            segment.transform.parent = this.transform;
            segment.GetComponent<Renderer>().material.color =
                Color.HSVToRGB(i / (float)numSegments, 1, 1);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
