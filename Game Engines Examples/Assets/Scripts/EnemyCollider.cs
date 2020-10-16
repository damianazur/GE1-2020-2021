using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{

    private Collider m_Collider;
    public float destroyVelocityStart = -10f;
    public float destroyVelocityEnd = 0f;

    void OnCollisionEnter(Collision c)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.drag = 1;

        Debug.Log("Collison: " +  c.gameObject.tag);
        if (c.gameObject.tag == "PlayerBullet")
        {
            m_Collider.enabled = false;
            foreach (Transform child in transform) {
                Collider child_Collider = child.GetComponent<Collider>();

                Rigidbody child_rb = child.gameObject.AddComponent<Rigidbody>();

                child_rb.useGravity = true;
                child_rb.isKinematic = false;

                float x = Random.Range(destroyVelocityStart, destroyVelocityEnd);
                float y = Random.Range(destroyVelocityStart, destroyVelocityEnd);
                float z = Random.Range(destroyVelocityStart, destroyVelocityEnd);

                child_rb.angularVelocity = new Vector3(x, y, z);
                
                child_rb.velocity = new Vector3(x, Math.Abs(y), z);

                child_Collider.enabled = true;
            }

            Destroy(this.gameObject, 7);
        }
    }

    void OnCollisionStay(Collision c)
    {
        //Debug.Log("Collision Stay");
    }

    void OnCollisionExit(Collision c)
    {
        //Debug.Log("Collision Exit");
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
