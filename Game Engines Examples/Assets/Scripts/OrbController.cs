using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    TankController tankControllerScript;
    Shooting shootingScript;
    AITank aiTankScript;
    RotateSeat rotateSeatScript;
    FPSController fpsControllerScript;

    void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.gameObject.tag);
        if (c.gameObject.tag == "MainCamera")
        {
            Debug.Log("Collides with MainCamera");

            tankControllerScript = this.transform.parent.GetComponent<TankController>();
            shootingScript = this.transform.parent.GetComponent<Shooting>();
            aiTankScript = this.transform.parent.GetComponent<AITank>();
            rotateSeatScript = this.GetComponent<RotateSeat>();
            fpsControllerScript = c.gameObject.GetComponent<FPSController>();

            fpsControllerScript.enabled = false;
            aiTankScript.enabled = false;
            rotateSeatScript.enabled = false;
            tankControllerScript.enabled = true;
            shootingScript.enabled = true;
        }
    }

    private void OnTriggerStay(Collider c)
    {
        if (c.CompareTag("MainCamera"))
        {
            c.transform.position = Vector3.Lerp(c.transform.position, transform.position, 10 * Time.deltaTime);

            Quaternion toRot = Quaternion.LookRotation(this.transform.parent.transform.forward);
            c.transform.rotation = Quaternion.Slerp(c.transform.rotation, toRot, 2 * Time.deltaTime);

            if (Input.GetKey(KeyCode.Space))
            {
                fpsControllerScript.enabled = true;
                tankControllerScript.enabled = false;
                aiTankScript.enabled = true;
                rotateSeatScript.enabled = true;
                shootingScript.enabled = false;

                this.GetComponent<Collider>().enabled = false;
                Invoke("ReEnableCollider", 2);
            }
        }
    }

    private void ReEnableCollider()
    {
        this.GetComponent<Collider>().enabled = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] cameras = GameObject.FindGameObjectsWithTag("MainCamera");
        GameObject cam = cameras[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
