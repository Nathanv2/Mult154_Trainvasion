using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMoving : MonoBehaviour
{
    public float speed = 5f;
    public float time = 10f;
    public Vector3 rightdirection = Vector3.right;
    public Vector3 leftdirection = Vector3.left;
    public bool goRight = false;
    public bool goLeft = false;

    private void Start()
    {
        StartCoroutine(MoveRight());
    }

    // Update is called once per frame
    void Update()
    {
        if (goRight)
        {
            transform.Translate(rightdirection * speed * Time.deltaTime);
        }
        else if(goLeft)
        {
            transform.Translate(leftdirection * speed * Time.deltaTime);
        }
    }

    IEnumerator MoveRight()
    {
        goRight = true;
        yield return new WaitForSeconds(time);
        goRight = false;
        StartCoroutine(MoveLeft());
    }

    IEnumerator MoveLeft()
    {
        goLeft = true;
        yield return new WaitForSeconds(time);
        goLeft = false;
        StartCoroutine(MoveRight());
    }

}
