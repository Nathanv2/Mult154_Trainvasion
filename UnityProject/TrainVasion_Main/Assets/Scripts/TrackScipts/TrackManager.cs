using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] tracks;
    public GameObject[] straightStop;
    public GameObject[] leftStop;
    public GameObject[] rightStop;
    public GameObject[] SpawnPointTracks;
    public GameObject[] SpawnPointTracksOfStop;

    public float speed;
    public float maxSpeed = 15f;

    public float maxTime = 15f;
    public float currentTime;

    public bool isMoving = false;

    public float maxYVal;
    public float minYVal;



    public void Start()
    {
        currentTime = maxTime;
      

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            isMoving = true;
            Debug.Log("You are moving");
            SpawnStraightTracks();
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            isMoving = false;
            Debug.Log("You are arriving at a stop");
            SpawnStraightTracks();
            SpawnStraightStop();
        }
    }

    public void SpawnStraightTracks()
    {
        for(int i = 0; i < tracks.Length; i++)
        {
            Instantiate(tracks[i], SpawnPointTracks[i].transform.position,Quaternion.identity);
        }
    }

    public void SpawnStraightStop()
    {
        for (int i = 0; i < straightStop.Length; i++)
        {
            Instantiate(straightStop[i], SpawnPointTracksOfStop[i].transform.position, Quaternion.identity);
        }
    }
}
