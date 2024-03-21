using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMovement : MonoBehaviour
{
   
    public TrackManager TM;
    
    // Start is called before the first frame update
    void Start()
    {
        TM = GameObject.Find("TrackManager").GetComponent<TrackManager>();
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = Vector3.MoveTowards(transform.position, new Vector3(0 , 0 , -15),  TM.speed * Time.deltaTime);

        if(transform.position.z == -15)
        {
            Destroy(gameObject);
        }
    }
}
