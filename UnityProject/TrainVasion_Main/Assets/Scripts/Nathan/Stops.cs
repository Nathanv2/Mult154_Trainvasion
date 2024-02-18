using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stops : MonoBehaviour
{
    public PlayerController playerController;
    private float maxClickDistance = 7f;

    private void OnMouseDown()
    {
        float distanceToStop = Vector3.Distance(playerController.transform.position, transform.position);

        if (distanceToStop <= maxClickDistance)
        {
            Vector3 stopPos = transform.position;
            playerController.Transition(stopPos);
        }
        else
        {
            Debug.Log("Stop is too far to click.");
        }
    }
}

