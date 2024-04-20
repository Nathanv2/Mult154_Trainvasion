using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Clouds;
    private float zPosRange = 300;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnClouds", 1f, 2f);
    }

    private void SpawnClouds()
    {
        float randZPos = Random.Range(-zPosRange, zPosRange);
        int CloudsIndex = Random.Range(0, Clouds.Length);
        Vector3 randPos = new Vector3(-415, 13, randZPos);
        Instantiate(Clouds[CloudsIndex], randPos, Clouds[CloudsIndex].transform.rotation);
    }
}
