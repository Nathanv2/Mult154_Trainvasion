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
      
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(SpawnTracks());
        }
        
      
    }
    IEnumerator SpawnTracks()
    {
        for(int i = 0; i< 1; i++)
        {
            Instantiate(tracks, spawner[0].transform.position, Quaternion.identity);
            Instantiate(tracks, spawner[1].transform.position, Quaternion.identity);
            Instantiate(tracks, spawner[2].transform.position, Quaternion.identity);
            Instantiate(tracks, spawner[3].transform.position, Quaternion.identity);
            Instantiate(tracks, spawner[4].transform.position, Quaternion.identity);
        }
        yield return null;
       
    }
}
