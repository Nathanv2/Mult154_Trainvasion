using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject stop;
    public Vector3 Player;
    public Vector3 newDirection;
    public float rayRange;

    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        newDirection = Quaternion.Euler(0, 180, 0) * transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        Player = transform.position;
        ray = new Ray(Player, newDirection);

        if (Physics.Raycast(ray, out hit, rayRange))
        {
            if (hit.collider.tag == "1 People" || hit.collider.tag == "5 People" || hit.collider.tag == "10 People" || hit.collider.tag == "Rescued" || hit.collider.tag == "Blockade" || hit.collider.tag == "Blockade Removed" || hit.collider.tag == "The End")
            {
                stop = hit.collider.gameObject;
            }
        }
    }

    public void RayCast(GameObject other)
    {
        if (Physics.Raycast(ray, out hit, rayRange))
        {
            if (hit.collider.tag == "1 People" || hit.collider.tag == "5 People" || hit.collider.tag == "10 People" || hit.collider.tag == "Rescued" || hit.collider.tag == "Blockade" || hit.collider.tag == "Blockade Removed" || hit.collider.tag == "The End")
            {
                stop = other.gameObject;
                Vector3 stopPos = other.transform.position;
                playerController.Transition(stopPos);
            }
        }
    }

    public void ActivateMovement()
    {
        RayCast(stop);
    }

    public void RotateRay(int test, int test1)
    {
        if(test == 0)
        {
            newDirection = Quaternion.Euler(0, -90, 0) * transform.forward;
        }
        else if(test1 == 1)
        {
            newDirection = Quaternion.Euler(0, 90, 0) * transform.forward;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(Player, ray.direction * rayRange);
    }


}
