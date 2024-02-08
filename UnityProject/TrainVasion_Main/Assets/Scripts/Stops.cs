using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stops : MonoBehaviour
{
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Vector3 StopPos = transform.position;
        playerController.Teleport(StopPos);
    }
}

