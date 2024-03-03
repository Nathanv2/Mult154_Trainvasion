using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streetcar : MonoBehaviour
{
    // Stores a reference to the waypoint system this object will use
    [SerializeField] private Waypoints waypoints;

    [SerializeField] private float moveSpeed = 5f;

    [Range(0f, 15f)] //How fast the agent will rotate once it reaches its waypoint
    /*[SerializeField] private float rotateSpeed = 10f;*/

    [SerializeField] private float distanceThreshold = 0.1f;

    //The current waypoint target what the object is moving towards
    private Transform currentWaypoint;


    // The rotation tartget for the current frame
    private Quaternion rotationGoal;
    // The direction to the next waypoint that the agent needs to rotate towards
    private Vector3 directionToWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial position to the first waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        // Set the next waypoint target
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            //transform.LookAt(currentWaypoint);
        }
        /*RotateTowardsWaypoint();*/
    }

    // Will slowly rotate the agent towards the current waypoint it is moving towards
    /*private void RotateTowardsWaypoint()
    {
        directionToWaypoint = (currentWaypoint.position - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }*/
}
