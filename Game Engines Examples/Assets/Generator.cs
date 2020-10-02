using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int rings = 9;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int r = 1; r < rings; r++) {
            int circum = (int) (2 * Mathf.PI * r);
            print(circum);
            int elem = circum;
            float theta = Mathf.PI * 2.0f / (float) elem;
            for(int i = 0 ; i < elem; i++)
            {
                GameObject sp = Instantiate(prefab);
                Vector3 pos = new Vector3(Mathf.Sin(theta * i) * r, 0, Mathf.Cos(theta * i) * r);
                sp.transform.position = transform.TransformPoint(pos);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
