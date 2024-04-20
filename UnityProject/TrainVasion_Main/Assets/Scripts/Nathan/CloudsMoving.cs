using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMoving : MonoBehaviour
{
    public float speed = 5f;
    public float time = 10f;
    public Vector3 direction = Vector3.right;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if(transform.position.x >= 400)
        {
            Destroy(gameObject);
        }
    }

}
