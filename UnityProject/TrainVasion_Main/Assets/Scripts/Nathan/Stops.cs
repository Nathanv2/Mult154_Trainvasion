using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stops : MonoBehaviour
{
    public PlayerController playerController;
    private float maxClickDistance = 7f;
    public bool canclick = true;

    public Material Glow;
    public Material Red;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnMouseDown()
    {
        float distanceToStop = Vector3.Distance(playerController.transform.position, transform.position);
        if (distanceToStop <= maxClickDistance && canclick)
        {
            Vector3 stopPos = transform.position;
            playerController.Transition(stopPos);
        }
        else if (distanceToStop > maxClickDistance && canclick)
        {
            Debug.Log("Stop is too far to click!");
        }
        else if (canclick == false)
        {
            Debug.Log("Choose your options!");
        }
    }

    private void OnMouseEnter()
    {
        float distanceToStop = Vector3.Distance(playerController.transform.position, transform.position);
        if (distanceToStop <= maxClickDistance)
        {
            GetComponent<Renderer>().material = Glow;
        }
    }

    private void OnMouseExit()
    {
        float distanceToStop = Vector3.Distance(playerController.transform.position, transform.position);
        if(distanceToStop <= maxClickDistance)
        {
            GetComponent<Renderer>().material = Red;
        }
    }
}

