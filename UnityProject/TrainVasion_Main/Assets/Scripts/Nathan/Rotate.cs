using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float rotationSpeed = 45f;

    public void RotatePlayerLeft()
    {
        StartCoroutine(RotateObjectLeft(90f, rotationSpeed));
    }

    public void RotatePlayerRight()
    {
        StartCoroutine(RotateObjectRight(90f, rotationSpeed));
    }

    IEnumerator RotateObjectLeft(float targetAngle, float speed)
    {
        float currentAngle = 0f;

        while (currentAngle < targetAngle)
        {
            float rotation = speed * Time.deltaTime;
            transform.Rotate(Vector3.down, rotation);
            currentAngle += rotation;
            yield return null;
        }
    }

    IEnumerator RotateObjectRight(float targetAngle, float speed)
    {
        float currentAngle = 0f;

        while (currentAngle < targetAngle)
        {
            float rotation = speed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotation);
            currentAngle += rotation;
            yield return null;
        }
    }
}
