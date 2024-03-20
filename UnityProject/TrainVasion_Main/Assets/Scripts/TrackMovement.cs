using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMovement : MonoBehaviour
{
    
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = Vector3.MoveTowards(transform.position, new Vector3(0 , 0 , -15), speed * Time.deltaTime);

        if(transform.position.z == -15)
        {
            Destroy(gameObject);
        }
    }
}
