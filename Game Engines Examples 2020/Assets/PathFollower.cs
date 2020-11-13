using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Path path;
    public int currentWaypoint;
    public Vector3 velocity;
    public Vector3 acceleration;
    public float max = 5;
    public Vector3 force;
    public float mass  = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }
    public Vector3 Seek(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= max;

        return desired - velocity;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = this.path.waypoints[currentWaypoint];

        Vector3 toTarget = target - transform.position;
        if (toTarget.magnitude < 1)
        {
            currentWaypoint = (currentWaypoint + 1) % path.numwaypoints;
        }

        force = Seek(target);

        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        if (velocity.magnitude > 0)
        {
            transform.forward = velocity;
            transform.position += velocity * Time.deltaTime;
        }
    }
}
