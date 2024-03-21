using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrackMovement : MonoBehaviour
{
    public TrackManager TM;

    // Start is called before the first frame update
    void Start()
    {
        TM = GameObject.Find("TrackManager").GetComponent<TrackManager>();
        TM.maxYVal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, TM.maxYVal), TM.speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            TM.maxYVal = -15;
        }

        if (transform.position.z == -15)
        {
            Destroy(gameObject);
        }
    }
}

