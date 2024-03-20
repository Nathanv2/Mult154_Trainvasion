using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField]
   public GameObject[] tracks;
    public GameObject[] straightStop;
    public GameObject[] leftStop;
    public GameObject[] rightStop;

    public GameObject SpawnPointTracks;

    public float speed;
    public float maxSpeed = 15f;

    public float maxTime = 15f;
    public float currentTime;

    public void Start()
    {
        currentTime = maxTime;
        SpawnTracks();
    }

    public void SpawnTracks()
    {
        for(int i = 0; i < tracks.Length; i++)
        {
            Instantiate(tracks[i],SpawnPointTracks.transform.position,Quaternion.identity);
            
        }
        
    }
}
