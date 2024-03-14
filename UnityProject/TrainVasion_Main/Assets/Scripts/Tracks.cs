using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracks : MonoBehaviour
{

    public GameObject povCamera;
    public GameObject tracks;
    public GameObject[] spawner;
    public float speed;
    public float time;
    private bool toggle;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawningTrack", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            CancelInvoke("SpawningTrack");
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            InvokeRepeating("SpawningTrack", 0, 1f);
        }


    }
   void SpawningTrack()
    {
        Instantiate(tracks, spawner[0].transform.position, Quaternion.identity);
        Instantiate(tracks, spawner[1].transform.position, Quaternion.identity);
        Instantiate(tracks, spawner[2].transform.position, Quaternion.identity);
        Instantiate(tracks, spawner[3].transform.position, Quaternion.identity);
    }
}
