using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pathway : MonoBehaviour
{
    

    // Array to store the waypoints
    public Transform[] waypoints;
    // Index of the current waypoint
    private int currentWaypointIndex = 0;
    // Flag to track if the object is currently moving
    private bool isMoving = false;

    // Speed of movement
    public float moveSpeed = 5f;
    // Distance at which the object stops at a waypoint
    public float stoppingDistance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the object's position to the first waypoint
        transform.position = waypoints[currentWaypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Move towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);
            // Check if the object has reached the current waypoint
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) <= stoppingDistance)
            {
                // If it has, stop moving
                isMoving = false;
            }
        }
    }

    // Method to start moving the object
    public void StartMoving()
    {
        isMoving = true;
    }

    // Method to stop the object at the current waypoint
    public void StopAtWaypoint()
    {
        isMoving = false;
    }

    // Method to stop the object at the current waypoint
    public void MoveToNextWaypoint()
    {
        if (currentWaypointIndex < waypoints.Length - 1)
        {
            currentWaypointIndex++;
            StartMoving();
        }
    }

    // Method to move to the previous waypoint
    public void MoveToPreviousWaypoint()
    {
        if (currentWaypointIndex > 0)
        {
            currentWaypointIndex--;
            StartMoving();
        }
    }

}
